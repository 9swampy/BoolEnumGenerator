//namespace Another;

//using PrimS.BoolParameterGenerator;
//using System;

//public partial class isValidBinaryEnumThree : SmartEnumWrapper<isValidBinaryEnumThree, BinaryEnum>, IEquatable<BinaryEnum>, IComparable<BinaryEnum>, IEquatable<BinaryEnumWrapper<isValidBinaryEnumThree, BinaryEnum>>, IComparable<BinaryEnumWrapper<isValidBinaryEnumThree, BinaryEnum>>
//{
//  public static readonly isValidBinaryEnumThree No = new isValidBinaryEnumThree(nameof(No), BinaryEnum.False);
//  public static readonly isValidBinaryEnumThree Yes = new isValidBinaryEnumThree(nameof(Yes), BinaryEnum.True);

//  public bool BoolValue => ProxyValue == BinaryEnum.True;

//  public static isValidBinaryEnumThree FromValue(BinaryEnum value) => value switch
//  {
//    BinaryEnum.False => No,
//    BinaryEnum.True => Yes,
//    _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unhandled value for isValidBinaryEnumThree")
//  };

//  public static isValidBinaryEnumThree FromValue(bool value) => value switch
//  {
//    false => No,
//    true => Yes
//  };

//  private isValidBinaryEnumThree(string name, BinaryEnum value) : base(name, value)
//  { }

//  public static implicit operator bool(isValidBinaryEnumThree value) => value.Value == BinaryEnum.True;

//  public static implicit operator isValidBinaryEnumThree(bool value) => value ? Yes : No;

//  public static bool operator ==(isValidBinaryEnumThree left, isValidBinaryEnumThree right) => left.Value.Value == right.Value.Value;

//  public static bool operator ==(isValidBinaryEnumThree left, bool right) => left.Value == (right ? BinaryEnum.True : BinaryEnum.False);

//  public static bool operator ==(isValidBinaryEnumThree left, int right) => (int)left.Value.Value == right;

//  public static bool operator ==(bool left, isValidBinaryEnumThree right) => (left ? 1 : 0) == (int)right.Value.Value;

//  public static bool operator !=(isValidBinaryEnumThree left, isValidBinaryEnumThree right) => left.Value.Value != right.Value.Value;

//  public static bool operator !=(isValidBinaryEnumThree left, bool right) => (int)left.Value.Value != (right ? 1 : 0);

//  public static bool operator !=(isValidBinaryEnumThree left, int right) => (int)left.Value.Value != right;

//  public static bool operator !=(bool left, isValidBinaryEnumThree right) => (left ? 1 : 0) != (int)right.Value.Value;

//  public static implicit operator isValidBinaryEnumThree(BinaryEnum value) => FromValue(value);

//  public override bool Equals(object obj) => obj is isValidBinaryEnumThree other && this == other;

//  public override int GetHashCode() => Value.GetHashCode();

//  public bool Equals(BinaryEnum other) => Equals(FromValue(other));

//  public int CompareTo(BinaryEnum other) => CompareTo(FromValue(other));

//  public int CompareTo(BinaryEnumWrapper<isValidBinaryEnumThree, BinaryEnum>? other) => Value.CompareTo(other?.Value);

//  public bool Equals(BinaryEnumWrapper<isValidBinaryEnumThree, BinaryEnum>? other) => Value.Equals(other?.Value);
//}
