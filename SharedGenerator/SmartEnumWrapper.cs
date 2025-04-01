#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace PrimS.BoolParameterGenerator;

using System;
using Ardalis.SmartEnum;

public class SmartEnumWrapper<TEnum, TValue>(string name, TValue value)
  : SmartEnum<TEnum, ProxyEnumWrapper<TEnum, TValue>>(name, new ProxyEnumWrapper<TEnum, TValue>(value))
  where TEnum : SmartEnum<TEnum, ProxyEnumWrapper<TEnum, TValue>>, IEquatable<TValue>, IComparable<TValue>, IEquatable<ProxyEnumWrapper<TEnum, TValue>>, IComparable<ProxyEnumWrapper<TEnum, TValue>> //ProxyEnumWrapper<TEnum, TValue>>
  where TValue : notnull, Enum
{
  public TValue ProxyValue => Value;
}
