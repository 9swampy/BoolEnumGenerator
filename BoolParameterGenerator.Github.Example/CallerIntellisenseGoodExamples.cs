namespace BoolParameterGenerator.Github.Example;

/// <summary>
/// Better caller intellisense: callers see meaningful Setting values instead of raw bool/int.
/// </summary>
public class CallerIntellisenseGoodExamples
{
  /// <summary>
  /// Clear call site: SetFeatureState(ExampleSetting.Enabled);
  /// No guessing required, overloads provide clarity.
  /// </summary>
  public static void SetFeatureState(ExampleFeatureSwitchSetting state)
  {
    if (state == ExampleFeatureSwitchSetting.Enabled)
    {
      Console.WriteLine("Feature enabled");
    }
    else
    {
      Console.WriteLine("Feature disabled");
    }
  }
}
