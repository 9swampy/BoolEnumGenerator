namespace PrimS.BoolParameterGenerator;

using System;

internal sealed class BinaryEnumWrapper<TEnum, TValue>
    where TValue : notnull, Enum
    where TEnum : notnull
{
  public TValue Value { get; }

  public BinaryEnumWrapper(TValue value)
  {
    Value = value;
  }

  public override bool Equals(object? obj)
  {
    if (obj is BinaryEnumWrapper<TEnum, TValue> other)
    {
      return Value.Equals(other.Value);
    }

    return false;
  }

  public override int GetHashCode() => Value.GetHashCode();
}
