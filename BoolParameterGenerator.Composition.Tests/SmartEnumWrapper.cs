namespace PrimS.BoolParameterGenerator;

using System;

internal sealed class SmartEnumWrapper<TEnum, TValue>
    where TEnum : notnull
    where TValue : notnull, Enum
{
  public string Name { get; }

  public TValue ProxyValue { get; }

  public SmartEnumWrapper(string name, TValue value)
  {
    Name = name;
    ProxyValue = value;
  }

  // Equality based on ProxyValue
  public override bool Equals(object? obj)
  {
    if (obj is SmartEnumWrapper<TEnum, TValue> other)
    {
      return ProxyValue.Equals(other.ProxyValue);
    }

    return false;
  }

  public override int GetHashCode() => ProxyValue.GetHashCode();
}
