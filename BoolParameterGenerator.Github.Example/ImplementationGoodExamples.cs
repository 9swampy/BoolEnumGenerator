namespace BoolParameterGenerator.Github.Example;

/// <summary>
/// Cleaner implementation using Setting proxy everywhere for clarity and safety.
/// </summary>
public class ImplementationGoodExamples
{
  public ExampleFeatureSwitchSetting Setting { get; private set; }

  /// <summary>
  /// Uses strongly typed Setting for clear assignment.
  /// </summary>
  public void Set(ExampleFeatureSwitchSetting value)
  {
    Setting = value;
  }

  /// <summary>
  /// Generated ExampleSetting values are not compile-time constants, so they cannot be used as
  /// default parameter values. Regardless optional parameters with non-constant defaults
  /// are generally considered an antipattern while method overloads provide a clean, explicit
  /// and highly recommended alternative.
  ///
  /// Looking ahead, we are exploring approaches like source generators or language improvements
  /// that may allow strongly-typed enums as default parameters, enhancing API ergonomics without
  /// sacrificing type safety.
  ///
  /// We would welcome input on specific use cases or scenarios where this limitation impacts you,
  /// to help guide future improvements.
  /// </summary>
  public void Initialize() => Initialize(ExampleFeatureSwitchSetting.Disabled);

  /// <summary>
  /// Initializes diagnostics with the specified setting.
  /// </summary>
  /// <param name="diagnostics">The diagnostics setting to use.</param>
  public static void Initialize(ExampleFeatureSwitchSetting diagnostics)
  {
    if (diagnostics == ExampleFeatureSwitchSetting.Enabled)
    {
      Console.WriteLine("Diagnostics initialized.");
    }
  }

  /// <summary>
  /// Toggling setting with a helper method improves readability.
  /// </summary>
  public void Toggle()
  {
    Setting = Setting == ExampleFeatureSwitchSetting.Enabled ? ExampleFeatureSwitchSetting.Disabled : ExampleFeatureSwitchSetting.Enabled;
  }

  /// <summary>
  /// Sets from environment variable cleanly using Setting proxy.
  /// </summary>
  public void SetFromEnvironment()
  {
    var env = Environment.GetEnvironmentVariable("FEATURE_ENABLED");
    Setting = env?.ToLowerInvariant() switch
    {
      "true" => ExampleFeatureSwitchSetting.Enabled,
      "false" => ExampleFeatureSwitchSetting.Disabled,
      _ => throw new InvalidOperationException("Invalid value for FEATURE_ENABLED")
    };
  }
}
