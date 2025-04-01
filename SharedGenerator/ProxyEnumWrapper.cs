#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace PrimS.BoolParameterGenerator;

using System;
using Ardalis.SmartEnum;

public class ProxyEnumWrapper<TEnum, TValue>(TValue value) : IComparable<TValue>, IEquatable<TValue>, IComparable<ProxyEnumWrapper<TEnum, TValue>>, IEquatable<ProxyEnumWrapper<TEnum, TValue>>
  where TValue : notnull, Enum
  where TEnum : SmartEnum<TEnum, ProxyEnumWrapper<TEnum, TValue>>, IEquatable<TValue>, IComparable<TValue>
{
  public static implicit operator TValue(ProxyEnumWrapper<TEnum, TValue> wrapper) => wrapper.Value;
  public static implicit operator ProxyEnumWrapper<TEnum, TValue>(TValue value) => new ProxyEnumWrapper<TEnum, TValue>(value);

  public TValue Value { get; } = value;

  public int CompareTo(TValue? other) => Value.CompareTo(other);

  public int CompareTo(ProxyEnumWrapper<TEnum, TValue>? other) => Value.CompareTo(other);

  public bool Equals(TValue? other) => Value.Equals(other);

  public bool Equals(ProxyEnumWrapper<TEnum, TValue>? other) => Value.Equals(other);

  public override bool Equals(object? obj) => obj is TValue other && Equals(other);

  public override int GetHashCode() => Value.GetHashCode();

  public static bool operator ==(ProxyEnumWrapper<TEnum, TValue> left, TValue right) => left.Equals(right);

  public static bool operator !=(ProxyEnumWrapper<TEnum, TValue> left, TValue right) => !left.Equals(right);

  public static bool operator ==(ProxyEnum right, ProxyEnumWrapper<TEnum, TValue> left) => left.Equals(right);

  public static bool operator !=(ProxyEnum right, ProxyEnumWrapper<TEnum, TValue> left) => !left.Equals(right);

  public override string ToString() => Value.ToString();
}
