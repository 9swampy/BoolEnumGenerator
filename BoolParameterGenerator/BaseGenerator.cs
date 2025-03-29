namespace PrimS.BoolParameterGenerator;

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

public abstract class BaseGenerator<TReceiver>(string generatorName, string attributeName) : ISourceGenerator
  where TReceiver : ISyntaxReceiver, ICandidateSyntaxReceiver, new()
{
  private string GeneratorName { get; } = generatorName;

  public void Initialize(GeneratorInitializationContext context)
  {
    context.RegisterForSyntaxNotifications(() => new TReceiver());
  }

  public void Execute(GeneratorExecutionContext context)
  {
    context.ReportDiagnostic(Diagnostic.Create(
        new DiagnosticDescriptor("BEG001", "Info", $"{GeneratorName} is running", "SourceGen", DiagnosticSeverity.Info, true),
        Location.None));

    // Check if the receiver is properly set up and receiving candidates
    if (context.SyntaxReceiver is not TReceiver receiver)
    {
      context.ReportDiagnostic(Diagnostic.Create(
          new DiagnosticDescriptor("BEG002", "Warning", "Syntax receiver is not registered or not of the expected type.", "SourceGen", DiagnosticSeverity.Warning, true),
          Location.None));
      return;
    }

    if (receiver.Candidates.Count == 0)
    {
      context.ReportDiagnostic(Diagnostic.Create(
          new DiagnosticDescriptor("BEG003", "Warning", "No classes found to process.", "SourceGen", DiagnosticSeverity.Info, true),
          Location.None));
    }

    foreach (var classDeclaration in receiver.Candidates)
    {
      var binaryEnumName = classDeclaration.Identifier.Text;
      foreach (var attribute in classDeclaration.AttributeLists.SelectMany(o => o.Attributes))
      {
        var name = attribute.Name.ToString();
        if (name != FullAttributeName)
        {
          context.ReportDiagnostic(Diagnostic.Create(
              new DiagnosticDescriptor("BEG006", "Warning", $"Attribute {name} is not supported.", "SourceGen", DiagnosticSeverity.Warning, true),
              Location.None));
          continue;
        }
      }

      var generateAttribute = classDeclaration.AttributeLists
            .SelectMany(al => al.Attributes)
            .FirstOrDefault(a => a.Name.ToString() == FullAttributeName);
      var namespaceName = EnsureNamespaceNameSet(context, generateAttribute);
      var trueMember = GetTrueMember(context, generateAttribute);
      var falseMember = GetFalseMember(context, generateAttribute);

      // Check if the struct is already defined
      if (context.Compilation.GetTypeByMetadataName($"{namespaceName}.{binaryEnumName}") != null)
      {
        context.ReportDiagnostic(
          Diagnostic.Create(
            new DiagnosticDescriptor(
              "BEG005",
              "Warning",
              $"Type {namespaceName}.{binaryEnumName} is already defined.",
              "SourceGen",
              DiagnosticSeverity.Info,
              true),
            Location.None));
        continue;
      }

      var source = GenerateType(binaryEnumName, namespaceName, trueMember, falseMember);
      context.AddSource($"{binaryEnumName}.g.cs", SourceText.From(source, Encoding.UTF8));
      source = GenerateAssertions(binaryEnumName, namespaceName, trueMember, falseMember);
      context.AddSource($"{binaryEnumName}Assertions.g.cs", SourceText.From(source, Encoding.UTF8));
      source = GenerateExtensions(binaryEnumName, namespaceName);
      context.AddSource($"{binaryEnumName}Extensions.g.cs", SourceText.From(source, Encoding.UTF8));

      // Log the generation
      context.ReportDiagnostic(Diagnostic.Create(
                new DiagnosticDescriptor("BEG004", "Info", $"Generated code for class: {binaryEnumName}", "SourceGen", DiagnosticSeverity.Info, true),
                Location.None));
    }
  }

  private string FullAttributeName => $"PrimS.BoolParameterGenerator.{attributeName.TrimEnd("Attribute")}";

  protected abstract string GenerateExtensions(string typeName, string namespaceName);

  protected abstract string GenerateAssertions(string typeName, string namespaceName, string trueMember, string falseMember);

  protected abstract string GenerateType(string typeName, string namespaceName, string trueMember, string falseMember);

  private static string EnsureNamespaceNameSet(GeneratorExecutionContext context, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax generateAttribute)
  {
    var namespaceName = generateAttribute?.ArgumentList?.Arguments.ElementAtOrDefault(0)?.ToString().Trim('"') ?? "True";
    if (string.IsNullOrWhiteSpace(namespaceName))
    {
      context.ReportDiagnostic(Diagnostic.Create(
          new DiagnosticDescriptor("BEG007", "Warning", "Namespace is not provided.", "SourceGen", DiagnosticSeverity.Warning, true),
          Location.None));
    }

    return namespaceName ?? "UnspecifiedNamespace";
  }

  private static string GetTrueMember(GeneratorExecutionContext context, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax generateAttribute)
  {
    return generateAttribute?.ArgumentList?.Arguments.ElementAtOrDefault(1)?.ToString().Trim('"') ?? "True";
  }

  private static string GetFalseMember(GeneratorExecutionContext context, Microsoft.CodeAnalysis.CSharp.Syntax.AttributeSyntax generateAttribute)
  {
    return generateAttribute?.ArgumentList?.Arguments.ElementAtOrDefault(2)?.ToString().Trim('"') ?? "False";
  }
}
