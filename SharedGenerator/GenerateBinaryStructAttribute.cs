#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace PrimS.BoolParameterGenerator;

using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenerateBinaryStructAttribute(string namespaceName, string trueMember, string falseMember) : Attribute
{
  public GenerateBinaryStructAttribute(string namespaceName)
    : this(namespaceName, "True", "False")
  { }

  public string NamespaceName { get; } = namespaceName;

  public string TrueMember { get; } = trueMember;

  public string FalseMember { get; } = falseMember;
}
