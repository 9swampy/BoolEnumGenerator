#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace PrimS.BoolParameterGenerator;

using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenerateBoolEnumAttribute(string trueMember, string falseMember) : Attribute
{
  public GenerateBoolEnumAttribute()
    : this("True", "False")
  { }

  public string TrueMember { get; } = trueMember;

  public string FalseMember { get; } = falseMember;
}
