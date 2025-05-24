namespace PrimS.BoolParameterGenerator;

using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenerateBinaryEnumAttribute(string trueMember, string falseMember) : Attribute
{
  public GenerateBinaryEnumAttribute()
    : this("True", "False")
  { }

  public string TrueMember { get; } = trueMember;

  public string FalseMember { get; } = falseMember;
}
