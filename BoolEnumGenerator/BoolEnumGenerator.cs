namespace BoolEnumGenerator;

using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

[Generator]
public class BoolEnumGenerator : ISourceGenerator
{
  public void Initialize(GeneratorInitializationContext context)
  {
    context.RegisterForSyntaxNotifications(() => new BoolEnumSyntaxReceiver());
  }

  public void Execute(GeneratorExecutionContext context)
  {
    context.ReportDiagnostic(Diagnostic.Create(
        new DiagnosticDescriptor("BEG001", "Info", "BoolEnumGenerator is running", "SourceGen", DiagnosticSeverity.Warning, true),
        Location.None));

    // Check if the receiver is properly set up and receiving candidates
    if (context.SyntaxReceiver is not BoolEnumSyntaxReceiver receiver)
    {
      context.ReportDiagnostic(Diagnostic.Create(
          new DiagnosticDescriptor("BEG002", "Warning", "Syntax receiver is not registered or not of the expected type.", "SourceGen", DiagnosticSeverity.Warning, true),
          Location.None));
      return;
    }

    if (receiver.Candidates.Count == 0)
    {
      context.ReportDiagnostic(Diagnostic.Create(
          new DiagnosticDescriptor("BEG003", "Warning", "No classes found to process.", "SourceGen", DiagnosticSeverity.Warning, true),
          Location.None));
    }

    foreach (var classDeclaration in receiver.Candidates)
    {
      var enumName = classDeclaration.Identifier.Text;
      foreach (var attribute in classDeclaration.AttributeLists.SelectMany(o => o.Attributes))
      {
        var name = attribute.Name.ToString();
        if (name != "SharedGenerator.GenerateBoolEnum")
        {
          context.ReportDiagnostic(Diagnostic.Create(
              new DiagnosticDescriptor("BEG006", "Warning", $"Attribute {name} is not supported.", "SourceGen", DiagnosticSeverity.Warning, true),
              Location.None));
          continue;
        }
      }

      var namespaceAttribute = classDeclaration.AttributeLists
            .SelectMany(al => al.Attributes)
            .FirstOrDefault(a => a.Name.ToString() == "BoolEnumNamespace");

      var namespaceName = namespaceAttribute?.ArgumentList?.Arguments.First().ToString().Trim('"') ?? "PrimS";

      // Check if the struct is already defined
      if (context.Compilation.GetTypeByMetadataName($"{namespaceName}.{enumName}") != null)
      {
        context.ReportDiagnostic(Diagnostic.Create(
            new DiagnosticDescriptor("BEG005", "Warning", $"Type {namespaceName}.{enumName} is already defined.", "SourceGen", DiagnosticSeverity.Warning, true),
            Location.None));
        continue;
      }

      var source = GenerateStruct(enumName, namespaceName);
      context.AddSource($"{enumName}.g.cs", SourceText.From(source, Encoding.UTF8));
      source = GenerateAssertions(enumName, namespaceName);
      context.AddSource($"{enumName}Assertions.g.cs", SourceText.From(source, Encoding.UTF8));
      source = GenerateTests(enumName, namespaceName);
      context.AddSource($"{enumName}Tests.g.cs", SourceText.From(source, Encoding.UTF8));

      // Log the generation
      context.ReportDiagnostic(Diagnostic.Create(
                new DiagnosticDescriptor("BEG004", "Info", $"Generated code for class: {enumName}", "SourceGen", DiagnosticSeverity.Warning, true),
                Location.None));
    }
  }

  private static string GenerateStruct(string name, string namespaceName)
  {
    return $@"
namespace {namespaceName}
{{
  using System;

  public readonly struct {name}
  {{
      private readonly bool _value;

      public static {name} True {{ get; }} = new {name}(true);

      public static {name} False {{ get; }} = new {name}(false);

      private {name}(bool value)
      {{
          _value = value;
      }}

      public static implicit operator bool({name} boolEnum)
      {{
          return boolEnum._value;
      }}

      public static implicit operator {name}(bool value) => value ? True : False;

      public static bool operator ==({name} left, {name} right) => left._value == right._value;

      public static bool operator !=({name} left, {name} right) => left._value != right._value;

      public override bool Equals(object obj) => obj is {name} other && this == other;

      public override int GetHashCode() => _value.GetHashCode();

      public override string ToString()
      {{
          return _value.ToString();
      }}
  }}
}}
";
  }

  private static string GenerateAssertions(string name, string namespaceName)
  {
    return $@"
namespace {namespaceName}
{{
  using System;
  using FluentAssertions.Execution;
  using FluentAssertions.Primitives;
  using FluentAssertions;

  public class {name}Assertions : ReferenceTypeAssertions<{name}, {name}Assertions>
  {{
      public {name}Assertions({name} instance) : base(instance) {{ }}

      protected override string Identifier => ""{name}"";

      public AndConstraint<{name}Assertions> BeTrue(string because = """", params object[] becauseArgs)
      {{
          Execute.Assertion
              .ForCondition(Subject == true)
              .BecauseOf(because, becauseArgs)
              .FailWith(""Expected {{context:{name}}} to be true but found {{0}}."", Subject);

          return new AndConstraint<{name}Assertions>(this);
      }}

      public AndConstraint<{name}Assertions> BeFalse(string because = """", params object[] becauseArgs)
      {{
          Execute.Assertion
              .ForCondition(Subject == false)
              .BecauseOf(because, becauseArgs)
              .FailWith(""Expected {{context:{name}}} to be false but found {{0}}."", Subject);

          return new AndConstraint<{name}Assertions>(this);
      }}

      public AndConstraint<{name}Assertions> NotBe({name} unexpected, string because = """", params object[] becauseArgs)
      {{
          return NotBe(unexpected == {name}.True, because, becauseArgs);
      }}

      public AndConstraint<{name}Assertions> NotBe(bool unexpected, string because = """", params object[] becauseArgs)
      {{
          Execute.Assertion
              .ForCondition(!Subject.Equals(unexpected))
              .BecauseOf(because, becauseArgs)
              .FailWith(""Expected {{context:{name}}} to not be {{0}} but found {{1}}."", unexpected, Subject);

          return new AndConstraint<{name}Assertions>(this);
      }}

      public AndConstraint<{name}Assertions> Be({name} expected, string because = """", params object[] becauseArgs)
      {{
          return Be(expected == {name}.True, because, becauseArgs);
      }}

      public AndConstraint<{name}Assertions> Be(bool expected, string because = """", params object[] becauseArgs)
      {{
          Execute.Assertion
              .ForCondition(!Subject.Equals(expected))
              .BecauseOf(because, becauseArgs)
              .FailWith(""Expected {{context:{name}}} to be {{0}} but found {{1}}."", expected, Subject);

          return new AndConstraint<{name}Assertions>(this);
      }}
  }}

  public static class {name}Extensions
  {{
      public static {name}Assertions Should(this {name} instance)
      {{
          return new {name}Assertions(instance);
      }}
  }}
}}";
  }

  private static string GenerateTests(string name, string namespaceName)
  {
    var camelCaseName = ToCamelCase(name);
    return $@"
namespace {namespaceName}
{{
  using Xunit;
  using FluentAssertions;
  using {namespaceName};

  public class {name}Tests
  {{
    [Fact]
    public void Given{name}TrueShouldBeTrue()
    {{
        var {camelCaseName} = {name}.True;
        {camelCaseName}.Should().BeTrue();
    }}

    [Fact]
    public void Given{name}FalseShouldBeFalse()
    {{
        var {camelCaseName} = {name}.False;
        {camelCaseName}.Should().BeFalse();
    }}

    [Fact]
    public void Given{name}TrueWhenCastBoolShouldBeTrue()
    {{
        var {camelCaseName} = {name}.True;
        ((bool){camelCaseName}).Should().BeTrue();
    }}

    [Fact]
    public void Given{name}FalseWhenCastBoolShouldBeFalse()
    {{
        var {camelCaseName} = {name}.False;
        ((bool){camelCaseName}).Should().BeFalse();
    }}

    [Fact]
    public void Given{name}TrueShouldBe{name}True()
    {{
        var {camelCaseName} = {name}.True;
        {camelCaseName}.Should().Be({name}.True);
    }}

    [Fact]
    public void Given{name}FalseShouldBe{name}False()
    {{
        var {camelCaseName} = {name}.False;
        {camelCaseName}.Should().Be({name}.False);
    }}

    [Fact]
    public void Given{name}TrueShouldBeBoolTrue()
    {{
        var {camelCaseName} = {name}.True;
        {camelCaseName}.Should().Be(true);
    }}

    [Fact]
    public void Given{name}FalseShouldBeBoolFalse()
    {{
        var {camelCaseName} = {name}.False;
        {camelCaseName}.Should().Be(false);
    }}

    [Fact]
    public void Given{name}TrueShouldNotBeFalse()
    {{
        var {camelCaseName} = {name}.True;
        {camelCaseName}.Should().NotBe(false);
    }}

    [Fact]
    public void Given{name}TrueShouldNotBe{name}False()
    {{
        var {camelCaseName} = {name}.True;
        {camelCaseName}.Should().NotBe({name}.False);
    }}

    [Fact]
    public void ShouldCtor()
    {{
      var {camelCaseName} = new {name}();

      {camelCaseName}.Should().NotBeNull();
    }}

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
    {{
      {name} {camelCaseName} = false;

      {camelCaseName}.Should().BeFalse();
    }}

    [Fact]
    public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
    {{
      {name} {camelCaseName} = true;

      {camelCaseName}.Should().BeTrue();
    }}

    [Fact]
    public void GivenBoolFalseWhenImplicitAssign{name}ParameterShouldBeFalse()
    {{
      {name} {camelCaseName} = false;

      {name}Parameter({camelCaseName}).Should().BeFalse();
    }}

    [Fact]
    public void GivenBoolTrueWhenImplicitAssign{name}ParameterShouldBeTrue()
    {{
      {name} {camelCaseName} = true;

      {name}Parameter({camelCaseName}).Should().BeTrue();
    }}

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
    {{
      IsBoolParameter(false).Should().BeFalse();
    }}

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBe{name}False()
    {{
      IsBoolParameter(false).Should().Be({name}.False);
    }}

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
    {{
      IsBoolParameter(true).Should().BeTrue();
    }}

    [Fact]
    public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBe{name}True()
    {{
      IsBoolParameter(true).Should().Be({name}.True);
    }}

    [Fact]
    public void GivenBoolTrueShouldEqual{name}()
    {{
      ({name}.True == true).Should().BeTrue();
    }}

    [Fact]
    public void GivenBoolFalseShouldEqual{name}()
    {{
      ({name}.False == false).Should().BeTrue();
    }}

    [Fact]
    public void GivenBoolTrueShouldNotEqualOpposite{camelCaseName}()
    {{
      ({name}.True == false).Should().BeFalse();
    }}

    [Fact]
    public void GivenBoolFalseShouldNotEqualOpposite{name}()
    {{
      ({name}.False == true).Should().BeFalse();
    }}

    private static {name} IsBoolParameter(bool value)
    {{
      return value;
    }}

    private static bool {name}Parameter({name} value)
    {{
      return value;
    }}
  }}
}}";
  }

  private static string ToCamelCase(string input)
  {
    if (string.IsNullOrEmpty(input) || !char.IsUpper(input[0]))
    {
      return input;
    }

    char[] chars = input.ToCharArray();
    for (int i = 0; i < chars.Length; i++)
    {
      if (i == 0 || (i > 0 && char.IsUpper(chars[i]) && !char.IsUpper(chars[i - 1])))
      {
        chars[i] = char.ToLower(chars[i]);
      }
      else
      {
        break;
      }
    }

    return new string(chars);
  }
}