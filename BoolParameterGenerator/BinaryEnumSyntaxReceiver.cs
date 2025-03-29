namespace PrimS.BoolParameterGenerator;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class BinaryEnumSyntaxReceiver : ISyntaxReceiver, ICandidateSyntaxReceiver
{
  public List<ClassDeclarationSyntax> Candidates { get; } = [];

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
  {
    if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
        classDeclarationSyntax.AttributeLists
          .SelectMany(al => al.Attributes)
          .Any(a => a.Name.ToString() == "PrimS.BoolParameterGenerator.GenerateBinaryEnum"))
    {
      Candidates.Add(classDeclarationSyntax);
    }
  }
}