﻿namespace PrimS.BoolParameterGenerator;
using Microsoft.CodeAnalysis;

[Generator]
public class BoolEnumGenerator() : BaseGenerator(nameof(BoolEnumGenerator), nameof(GenerateBoolEnumAttribute))
{
  protected override string GenerateType(string typeName, string namespaceName, string trueMember, string falseMember)
  {
    return $@"{NamespaceBlockOrEmpty(namespaceName)}
#nullable enable

using Ardalis.SmartEnum;
  
public partial class {typeName} : SmartEnum<{typeName}, bool>
{{
  public static readonly {typeName} {falseMember} = new {typeName}(nameof({falseMember}), false);
  public static readonly {typeName} {trueMember} = new {typeName}(nameof({trueMember}), true);

  private {typeName}(string name, bool value) : base(name, value)
  {{ }}

  public static implicit operator bool({typeName} value) => value.Value;

  private int IntValue => Value ? 1 : 0;

  public static implicit operator {typeName}(bool value) => value ? {trueMember} : {falseMember};

  public static bool operator ==({typeName} left, {typeName} right) => left.Value == right.Value;

  public static bool operator ==({typeName} left, bool right) => left.Value == right;

  public static bool operator ==({typeName} left, int right) => left.IntValue == right;

  public static bool operator ==(bool left, {typeName} right) => (left ? 1 : 0) == right.IntValue;

  public static bool operator !=({typeName} left, {typeName} right) => left.Value != right.Value;

  public static bool operator !=({typeName} left, bool right) => left.IntValue != (right ? 1 : 0);

  public static bool operator !=({typeName} left, int right) => left.IntValue != right;

  public static bool operator !=(bool left, {typeName} right) => (left ? 1 : 0) != right.IntValue;

  public override bool Equals(object obj) => obj is {typeName} other && this == other;

  public override int GetHashCode() => Value.GetHashCode();
}}";
  }

  protected override string GenerateAssertions(string typeName, string namespaceName, string trueMember, string falseMember)
  {
    return $@"{NamespaceBlockOrEmpty(namespaceName)}
using FluentAssertions.Primitives;
using FluentAssertions;

public class {typeName}Assertions({typeName} instance) : BooleanAssertions<{typeName}Assertions>(instance)
{{
  public AndConstraint<{typeName}Assertions> NotBe({typeName} unexpected, string because = """", params object[] becauseArgs)
  {{
    return base.NotBe(unexpected.Value, because, becauseArgs);
  }}

  public AndConstraint<{typeName}Assertions> Be({typeName} expected, string because = """", params object[] becauseArgs)
  {{
    return base.Be(expected.Value, because, becauseArgs);
  }}
}}";
  }

  protected override string GenerateExtensions(string typeName, string namespaceName)
  {
    var nsUsing = string.IsNullOrEmpty(namespaceName) ? string.Empty : $"using {namespaceName};";
    return $@"{NamespaceBlockOrEmpty("FluentAssertions")}
{nsUsing}

public static class {typeName}Extensions
{{
  public static {typeName}Assertions Should(this {typeName} instance)
  {{
    return new {typeName}Assertions(instance);
  }}
}}";
  }
}
