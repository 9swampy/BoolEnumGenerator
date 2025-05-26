namespace Another;

#nullable enable

using System;
using PrimS.BoolParameterGenerator;

public partial class IsValidBinaryEnumThree : IEquatable<bool>, IComparable<bool>
{
  private readonly SmartEnumWrapper<IsValidBinaryEnumThree, BinaryEnum> _wrapper;

  public static readonly IsValidBinaryEnumThree No = new IsValidBinaryEnumThree(nameof(No), BinaryEnum.False);
  public static readonly IsValidBinaryEnumThree Yes = new IsValidBinaryEnumThree(nameof(Yes), BinaryEnum.True);

  public bool BoolValue => _wrapper.ProxyValue == BinaryEnum.True;

  public static IReadOnlyCollection<IsValidBinaryEnumThree> List => [No, Yes];

  public BinaryEnum Value => _wrapper.ProxyValue;

  private IsValidBinaryEnumThree(string name, BinaryEnum value)
  {
    _wrapper = new SmartEnumWrapper<IsValidBinaryEnumThree, BinaryEnum>(name, value);
  }

  public static IsValidBinaryEnumThree FromValue(BinaryEnum value) => value switch
  {
    BinaryEnum.False => No,
    BinaryEnum.True => Yes,
    _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unhandled value for isValidBinaryEnumThree")
  };

  public static IsValidBinaryEnumThree FromValue(bool value) => value ? Yes : No;

  // Implicit conversions between bool and isValidBinaryEnumThree
  public static implicit operator bool(IsValidBinaryEnumThree value) => value.BoolValue;

  public static implicit operator IsValidBinaryEnumThree(bool value) => value ? Yes : No;

  // Equality and comparison against bool only
  public bool Equals(bool other) => BoolValue == other;

  public int CompareTo(bool other) => BoolValue.CompareTo(other);

  public override bool Equals(object? obj) => obj switch
  {
    bool b => Equals(b),
    IsValidBinaryEnumThree other => _wrapper.Equals(other._wrapper),
    _ => false,
  };

  public override int GetHashCode() => _wrapper.GetHashCode();

  // Additional bool operators for convenience
  public static bool operator ==(IsValidBinaryEnumThree left, IsValidBinaryEnumThree right) => left._wrapper.Equals(right._wrapper);

  public static bool operator !=(IsValidBinaryEnumThree left, IsValidBinaryEnumThree right) => !left._wrapper.Equals(right._wrapper);

  public static bool operator ==(IsValidBinaryEnumThree left, bool right) => left.BoolValue == right;

  public static bool operator !=(IsValidBinaryEnumThree left, bool right) => left.BoolValue != right;

  public static bool operator ==(bool left, IsValidBinaryEnumThree right) => left == right.BoolValue;

  public static bool operator !=(bool left, IsValidBinaryEnumThree right) => left != right.BoolValue;

  public override string ToString()
  {
    return _wrapper.Name;
  }
}
