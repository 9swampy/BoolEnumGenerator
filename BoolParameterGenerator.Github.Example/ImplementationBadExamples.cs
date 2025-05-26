namespace BoolParameterGenerator.Github.Example;

/// <summary>
/// Examples showing implementation code clutter and errors due to manual bool/int conversions.
/// </summary>
public class ImplementationBadExamples
{
  public ExampleSetting Setting { get; private set; }

  /// <summary>
  /// Manual conversion from bool, repeated often and error prone.
  /// </summary>
  public void SetFromBool(bool value)
  {
    Setting = value ? ExampleSetting.Enabled : ExampleSetting.Disabled;
  }

  /// <summary>
  /// Manual int conversions and exception handling at multiple places.
  /// </summary>
  public void SetFromInt(int value)
  {
    if (value == 1)
    {
      Setting = ExampleSetting.Enabled;
    }
    else if (value == 0)
    {
      Setting = ExampleSetting.Disabled;
    }
    else
    {
      throw new ArgumentOutOfRangeException(nameof(value));
    }
  }
}
