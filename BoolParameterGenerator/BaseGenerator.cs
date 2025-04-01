namespace PrimS.BoolParameterGenerator;

using System;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

public abstract class BaseGenerator(string generatorName, string attributeName) : IIncrementalGenerator
{
  private readonly string _generatorName = generatorName;
  private readonly string _attributeName = attributeName;

  public void Initialize(IncrementalGeneratorInitializationContext context)
  {
    var classDeclarations = context.SyntaxProvider
        .CreateSyntaxProvider(
            predicate: static (node, _) => node is ClassDeclarationSyntax cds && cds.AttributeLists.Count > 0,
            transform: (ctx, _) => GetCandidateClass(ctx, _attributeName))
        .Where(static c => c is not null)
        .Collect();

    context.RegisterSourceOutput(classDeclarations, (spc, candidates) =>
    {
      // BEG001: Generator is running
      ReportDiagnostic(spc, "BEG001", "Info", $"{_generatorName} is running", Location.None);

      if (candidates.Length == 0)
      {
        spc.AddSource("GeneratorHeartbeat.g.cs", SourceText.From("// Generator ran successfully", Encoding.UTF8));
        ReportDiagnostic(spc, "BEG003", "Info", "No classes found to process.", Location.None);
        return;
      }

      foreach (var candidate in candidates!)
      {
        if (candidate is not (ClassDeclarationSyntax classDeclaration, GeneratorSyntaxContext model))
        {
          continue;
        }

        var binaryEnumName = classDeclaration.Identifier.Text;

        var symbol = model.SemanticModel.GetDeclaredSymbol(classDeclaration, CancellationToken.None);
        if (symbol == null)
        {
          ReportDiagnostic(spc, "BEG006", "Warning", $"Symbol not found for {binaryEnumName}.", classDeclaration);
          continue;
        }

        var attrName = $"PrimS.BoolParameterGenerator.{_attributeName}";
        var attrNameShort = attrName.EndsWith("Attribute", StringComparison.Ordinal)
                ? attrName.Substring(0, attrName.Length - "Attribute".Length)
                : attrName;

        var attributeData = symbol.GetAttributes()
                .FirstOrDefault(attr =>
                    string.Compare(attr.AttributeClass?.ToDisplayString(), attrName, StringComparison.Ordinal) == 0 ||
                    string.Compare(attr.AttributeClass?.ToDisplayString(), attrNameShort, StringComparison.Ordinal) == 0);

        if (attributeData == null)
        {
          ReportDiagnostic(spc, "BEG007", "Warning", $"Attribute not found on {binaryEnumName}.", classDeclaration);
          continue;
        }

        var namespaceName = GetNamespace(classDeclaration);
        var trueMember = GetTrueMember(attributeData);
        var falseMember = GetFalseMember(attributeData);

        var fullTypeName = string.IsNullOrEmpty(namespaceName)
            ? binaryEnumName
            : $"{namespaceName}.{binaryEnumName}";

        var existingType = model.SemanticModel.Compilation.GetTypeByMetadataName(fullTypeName);
        if (existingType != null && !existingType.DeclaringSyntaxReferences.Any(syntaxRef =>
        {
          var syntax = syntaxRef.GetSyntax(CancellationToken.None);
          return syntax is ClassDeclarationSyntax cds && cds.Modifiers.Any(m => m.IsKind(Microsoft.CodeAnalysis.CSharp.SyntaxKind.PartialKeyword));
        }))
        {
          ReportDiagnostic(spc, "BEG005", "Info", $"Type {fullTypeName} is already defined.", classDeclaration);
          continue;
        }

        var source = GenerateType(binaryEnumName, namespaceName, trueMember, falseMember);
        spc.AddSource($"{binaryEnumName}.g.cs", SourceText.From(source, Encoding.UTF8));
        source = GenerateAssertions(binaryEnumName, namespaceName, trueMember, falseMember);
        spc.AddSource($"{binaryEnumName}Assertions.g.cs", SourceText.From(source, Encoding.UTF8));
        source = GenerateExtensions(binaryEnumName, namespaceName);
        spc.AddSource($"{binaryEnumName}Extensions.g.cs", SourceText.From(source, Encoding.UTF8));

        ReportDiagnostic(spc, "BEG004", "Info", $"Generated code for class: {binaryEnumName}", classDeclaration);
      }
    });
  }

  protected abstract string GenerateExtensions(string typeName, string namespaceName);

  protected abstract string GenerateAssertions(string typeName, string namespaceName, string trueMember, string falseMember);

  protected abstract string GenerateType(string typeName, string namespaceName, string trueMember, string falseMember);

  protected static string NamespaceBlockOrEmpty(string namespaceName)
  {
    return string.IsNullOrEmpty(namespaceName)
            ? string.Empty
            : $"namespace {namespaceName};";
  }

  private static bool IsAttributeTypeMissing(INamedTypeSymbol? attributeSymbol)
  {
    return attributeSymbol == null;
  }

  private static (ClassDeclarationSyntax, GeneratorSyntaxContext)? GetCandidateClass(GeneratorSyntaxContext context, string attributeName)
  {
    if (context.Node is not ClassDeclarationSyntax classDecl)
    {
      return null;
    }

    var symbol = context.SemanticModel.GetDeclaredSymbol(classDecl, CancellationToken.None);
    if (symbol == null)
    {
      return null;
    }

    var compilation = context.SemanticModel.Compilation;
    var expectedAttrSymbol = compilation.GetTypeByMetadataName($"PrimS.BoolParameterGenerator.{attributeName}");
    if (IsAttributeTypeMissing(expectedAttrSymbol))
    {
      return null;
    }

    var hasAttribute = symbol.GetAttributes().Any(attr =>
      SymbolEqualityComparer.Default.Equals(attr.AttributeClass, expectedAttrSymbol));

    return hasAttribute ? (classDecl, context) : null;
  }

  private static string GetTrueMember(AttributeData attributeData)
  {
    if (attributeData.ConstructorArguments.Length > 0 && attributeData.ConstructorArguments[0].Value is string value)
    {
      return value;
    }
    else
    {
      return "True";
    }
  }

  private static string GetFalseMember(AttributeData attributeData)
  {
    if (attributeData.ConstructorArguments.Length > 1 && attributeData.ConstructorArguments[1].Value is string value)
    {
      return value;
    }
    else
    {
      return "False";
    }
  }

  private static void ReportDiagnostic(SourceProductionContext context, string id, string category, string message, Location location)
  {
    context.ReportDiagnostic(Diagnostic.Create(
        new DiagnosticDescriptor(id, category, message, "SourceGen", DiagnosticSeverity.Info, true),
        location));
  }

  private static void ReportDiagnostic(SourceProductionContext context, string id, string category, string message, ClassDeclarationSyntax classDeclaration)
  {
    ReportDiagnostic(context, id, category, message, classDeclaration.GetLocation());
  }

  private static string GetNamespace(ClassDeclarationSyntax classDeclaration)
  {
    try
    {
      SyntaxNode? parent = classDeclaration.Parent;
      while (parent is not null and not NamespaceDeclarationSyntax and not FileScopedNamespaceDeclarationSyntax)
      {
        parent = parent.Parent;
      }

      return parent switch
      {
        NamespaceDeclarationSyntax ns => ns.Name.ToString(),
        FileScopedNamespaceDeclarationSyntax fs => fs.Name.ToString(),
        _ => string.Empty // global namespace
      };
    }
    catch (Exception ex)
    {
      return ex.Message;
    }
  }
}
