namespace BoolEnumGenerator;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

internal class BoolEnumSyntaxReceiver : ISyntaxReceiver
{
  public List<ClassDeclarationSyntax> Candidates { get; } = [];

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
  {
    if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
        classDeclarationSyntax.AttributeLists
          .SelectMany(al => al.Attributes)
          .Any(a => a.Name.ToString() == "SharedGenerator.GenerateBoolEnum"))
    {
      Candidates.Add(classDeclarationSyntax);
    }
  }
}