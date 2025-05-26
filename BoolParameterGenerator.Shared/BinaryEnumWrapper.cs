namespace PrimS.BoolParameterGenerator;

using System;
using Ardalis.SmartEnum;

public class BinaryEnumWrapper<TEnum, TValue>(TValue value) : IComparable<TValue>, IEquatable<TValue>, IComparable<BinaryEnumWrapper<TEnum, TValue>>, IEquatable<BinaryEnumWrapper<TEnum, TValue>>
  where TValue : notnull, Enum
  where TEnum : SmartEnum<TEnum, BinaryEnumWrapper<TEnum, TValue>>, IEquatable<TValue>, IComparable<TValue>
{
  public static implicit operator TValue(BinaryEnumWrapper<TEnum, TValue> wrapper) => wrapper.Value;
  public static implicit operator BinaryEnumWrapper<TEnum, TValue>(TValue value) => new BinaryEnumWrapper<TEnum, TValue>(value);

  public TValue Value { get; } = value;

  public int CompareTo(TValue? other) => Value.CompareTo(other);

  public int CompareTo(BinaryEnumWrapper<TEnum, TValue>? other) => Value.CompareTo(other);

  public bool Equals(TValue? other) => Value.Equals(other);

  public bool Equals(BinaryEnumWrapper<TEnum, TValue>? other) => Value.Equals(other);

  public override bool Equals(object? obj) => obj is TValue other && Equals(other);

  public override int GetHashCode() => Value.GetHashCode();

  public static bool operator ==(BinaryEnumWrapper<TEnum, TValue> left, TValue right) => left.Equals(right);

  public static bool operator !=(BinaryEnumWrapper<TEnum, TValue> left, TValue right) => !left.Equals(right);

  public static bool operator ==(BinaryEnum right, BinaryEnumWrapper<TEnum, TValue> left) => left.Equals(right);

  public static bool operator !=(BinaryEnum right, BinaryEnumWrapper<TEnum, TValue> left) => !left.Equals(right);

  public override string ToString() => Value.ToString();
}
