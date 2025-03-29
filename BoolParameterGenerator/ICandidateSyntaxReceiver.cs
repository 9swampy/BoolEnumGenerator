namespace PrimS.BoolParameterGenerator;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

public interface ICandidateSyntaxReceiver
{
  List<ClassDeclarationSyntax> Candidates { get; }

  //void OnVisitSyntaxNode(SyntaxNode syntaxNode);
}