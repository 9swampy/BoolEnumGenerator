namespace BoolParameterGenerator.Github.Example;

using PrimS.BoolParameterGenerator;

/// <summary>
/// Generates a binary enum proxy for bool with the values Disabled and Enabled.
/// Improves readability and type safety over raw bool usage.
/// </summary>
[GenerateBinaryEnum("Disabled", "Enabled")]
public partial class ExampleSetting;
