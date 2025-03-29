﻿namespace PrimS.BoolParameterGenerator;

using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenerateBoolEnumAttribute(string namespaceName, string trueMember, string falseMember) : Attribute
{
  public GenerateBoolEnumAttribute(string namespaceName)
    : this(namespaceName, "True", "False")
  { }

  public string NamespaceName { get; } = namespaceName;

  public string TrueMember { get; } = trueMember;

  public string FalseMember { get; } = falseMember;
}
