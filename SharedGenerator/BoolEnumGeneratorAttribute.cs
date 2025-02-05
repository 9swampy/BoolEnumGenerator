namespace SharedGenerator;

using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public class GenerateBoolEnumAttribute(string namespaceName) : Attribute
{
  public string NamespaceName { get; } = namespaceName;
}
