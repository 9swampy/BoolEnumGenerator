namespace PrimS.BoolParameterGenerator;

using System;
using Ardalis.SmartEnum;

public class SmartEnumWrapper<TEnum, TValue>(string name, TValue value)
  : SmartEnum<TEnum, BinaryEnumWrapper<TEnum, TValue>>(name, new BinaryEnumWrapper<TEnum, TValue>(value))
  where TEnum : SmartEnum<TEnum, BinaryEnumWrapper<TEnum, TValue>>, IEquatable<TValue>, IComparable<TValue>, IEquatable<BinaryEnumWrapper<TEnum, TValue>>, IComparable<BinaryEnumWrapper<TEnum, TValue>> //BinaryEnumWrapper<TEnum, TValue>>
  where TValue : notnull, Enum
{
  public TValue ProxyValue => Value;
}
