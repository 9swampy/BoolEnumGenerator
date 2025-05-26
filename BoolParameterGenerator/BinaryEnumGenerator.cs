namespace PrimS.BoolParameterGenerator;
using Microsoft.CodeAnalysis;

[Generator]
public class BinaryEnumGenerator() : BaseGenerator(nameof(BinaryEnumGenerator), nameof(GenerateBinaryEnumAttribute))
{
  protected override string GenerateType(string typeName, string namespaceName, string trueMember, string falseMember)
  {
    return $@"{NamespaceBlockOrEmpty(namespaceName)}
#nullable enable

using System;
using PrimS.BoolParameterGenerator;

public partial class {typeName} : SmartEnumWrapper<{typeName}, BinaryEnum>, IEquatable<BinaryEnum>, IComparable<BinaryEnum>, IEquatable<BinaryEnumWrapper<{typeName}, BinaryEnum>>, IComparable<BinaryEnumWrapper<{typeName}, BinaryEnum>>
{{
  public static readonly {typeName} {falseMember} = new {typeName}(nameof({falseMember}), BinaryEnum.False);
  public static readonly {typeName} {trueMember} = new {typeName}(nameof({trueMember}), BinaryEnum.True);

  public bool BoolValue => ProxyValue == BinaryEnum.True;

  public static {typeName} FromValue(BinaryEnum value) => value switch
  {{
    BinaryEnum.False => {falseMember},
    BinaryEnum.True => {trueMember},
    _ => throw new ArgumentOutOfRangeException(nameof(value), value, ""Unhandled value for {typeName}"")
  }};

  public static {typeName} FromValue(bool value) => value switch
  {{
    false => {falseMember},
    true => {trueMember}
  }};

  private {typeName}(string name, BinaryEnum value) : base(name, value)
  {{ }}

  public static implicit operator bool({typeName} value)
  {{
    return value.Value == BinaryEnum.True;
  }}

  public static implicit operator {typeName}(bool value) => value ? {trueMember} : {falseMember};

  public static bool operator ==({typeName} left, {typeName} right) => left.Value.Value == right.Value.Value;

  public static bool operator ==({typeName} left, bool right) => left.Value == (right ? BinaryEnum.True : BinaryEnum.False);

  public static bool operator ==({typeName} left, int right) => (int)left.Value.Value == right;

  public static bool operator ==(bool left, {typeName} right) => (left ? 1 : 0) == (int)right.Value.Value;

  public static bool operator !=({typeName} left, {typeName} right) => left.Value.Value != right.Value.Value;

  public static bool operator !=({typeName} left, bool right) => (int)left.Value.Value != (right ? 1 : 0);

  public static bool operator !=({typeName} left, int right) => (int)left.Value.Value != right;

  public static bool operator !=(bool left, {typeName} right) => (left ? 1 : 0) != (int)right.Value.Value;

  public static implicit operator {typeName}(BinaryEnum value) => {typeName}.FromValue(value);

  public override bool Equals(object obj) => obj is {typeName} other && this == other;

  public override int GetHashCode() => Value.GetHashCode();

  public bool Equals(BinaryEnum other) => Equals(FromValue(other));

  public int CompareTo(BinaryEnum other) => CompareTo(FromValue(other));

  public int CompareTo(BinaryEnumWrapper<{typeName}, BinaryEnum>? other) => Value.CompareTo(other?.Value);

  public bool Equals(BinaryEnumWrapper<{typeName}, BinaryEnum>? other) => Value.Equals(other?.Value);
}}";
  }

  protected override string GenerateAssertions(string typeName, string namespaceName, string trueMember, string falseMember)
  {
    return $@"{NamespaceBlockOrEmpty(namespaceName)}
using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;

public class {typeName}Assertions : ReferenceTypeAssertions<{typeName}, {typeName}Assertions>
{{
  public {typeName}Assertions({typeName} instance) : base(instance) {{ }}

  protected override string Identifier => ""{typeName}"";

  public AndConstraint<{typeName}Assertions> BeTrue(string because = """", params object[] becauseArgs)
  {{
    Execute.Assertion
        .ForCondition(Subject == {typeName}.{trueMember})
        .BecauseOf(because, becauseArgs)
        .FailWith(""Expected {{context:{typeName}}} to be true but found {{0}}."", Subject);

    return new AndConstraint<{typeName}Assertions>(this);
  }}

  public AndConstraint<{typeName}Assertions> BeFalse(string because = """", params object[] becauseArgs)
  {{
    Execute.Assertion
        .ForCondition(Subject == {typeName}.{falseMember})
        .BecauseOf(because, becauseArgs)
        .FailWith(""Expected {{context:{typeName}}} to be false but found {{0}}."", Subject);

    return new AndConstraint<{typeName}Assertions>(this);
  }}

  public AndConstraint<{typeName}Assertions> {falseMember}tBe({typeName} unexpected, string because = """", params object[] becauseArgs)
  {{
    return {falseMember}tBe((int)unexpected.Value.Value, because, becauseArgs);
  }}

  public AndConstraint<{typeName}Assertions> {falseMember}tBe(bool expected, string because = """", params object[] becauseArgs)
  {{
    return {falseMember}tBe(expected ? 0x1 : 0x0, because, becauseArgs);
  }}

  public AndConstraint<{typeName}Assertions> {falseMember}tBe(int unexpected, string because = """", params object[] becauseArgs)
  {{
    Execute.Assertion
        .ForCondition((int)Subject.Value.Value != unexpected)
        .BecauseOf(because, becauseArgs)
        .FailWith(""Expected {{context:{typeName}}} to not be {{0}} but found {{1}}."", unexpected, Subject);

    return new AndConstraint<{typeName}Assertions>(this);
  }}

  public AndConstraint<{typeName}Assertions> Be({typeName} expected, string because = """", params object[] becauseArgs)
  {{
    return Be((int)expected.Value.Value, because, becauseArgs);
  }}

  public AndConstraint<{typeName}Assertions> Be(bool expected, string because = """", params object[] becauseArgs)
  {{
    return Be(expected ? 0x1 : 0x0, because, becauseArgs);
  }}

  public AndConstraint<{typeName}Assertions> Be(int expected, string because = """", params object[] becauseArgs)
  {{
    Execute.Assertion
        .ForCondition((int)Subject.Value.Value == expected)
        .BecauseOf(because, becauseArgs)
        .FailWith(""Expected {{context:{typeName}}} to be {{0}} but found {{1}}."", expected, Subject);

    return new AndConstraint<{typeName}Assertions>(this);
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
