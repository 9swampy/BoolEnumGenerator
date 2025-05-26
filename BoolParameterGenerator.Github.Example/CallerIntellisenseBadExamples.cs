namespace BoolParameterGenerator.Github.Example;

/// <summary>
/// Examples showing how callers see confusing or ambiguous intellisense with raw bool/int parameters.
/// </summary>
public class CallerIntellisenseBadExamples
{
  /// <summary>
  /// Caller must know what "true" or "false" mean with no context.
  /// Overloads not possible, variant method names required.
  /// </summary>
  public static void SetFeatureEnabled(bool enabled)
  {
    // ambiguous from call site: SetFeatureEnabled(true);
  }

  /// <summary>
  /// Caller must know that 0 means disabled and 1 means enabled.
  /// Error prone and unclear at call site.
  /// Overloads not possible, variant method names required.
  /// </summary>
  public static void SetFeatureEnabledInt(int enabled)
  {
    if (enabled != 0 && enabled != 1)
    {
      throw new ArgumentOutOfRangeException(nameof(enabled));
    }
  }
}
