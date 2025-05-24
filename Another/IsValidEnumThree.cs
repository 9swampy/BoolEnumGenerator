//namespace Another;

//using PrimS.BoolParameterGenerator;
//using System;

//public partial class IsValidEnumThree : SmartEnumWrapper<IsValidEnumThree, ProxyEnum>, IEquatable<ProxyEnum>, IComparable<ProxyEnum>, IEquatable<ProxyEnumWrapper<IsValidEnumThree, ProxyEnum>>, IComparable<ProxyEnumWrapper<IsValidEnumThree, ProxyEnum>>
//{
//  public static readonly IsValidEnumThree No = new IsValidEnumThree(nameof(No), ProxyEnum.False);
//  public static readonly IsValidEnumThree Yes = new IsValidEnumThree(nameof(Yes), ProxyEnum.True);

//  public bool BoolValue => ProxyValue == ProxyEnum.True;

//  public static IsValidEnumThree FromValue(ProxyEnum value) => value switch
//  {
//    ProxyEnum.False => No,
//    ProxyEnum.True => Yes,
//    _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unhandled value for IsValidEnumThree")
//  };

//  public static IsValidEnumThree FromValue(bool value) => value switch
//  {
//    false => No,
//    true => Yes
//  };

//  private IsValidEnumThree(string name, ProxyEnum value) : base(name, value)
//  { }

//  public static implicit operator bool(IsValidEnumThree value) => value.Value == ProxyEnum.True;

//  public static implicit operator IsValidEnumThree(bool value) => value ? Yes : No;

//  public static bool operator ==(IsValidEnumThree left, IsValidEnumThree right) => left.Value.Value == right.Value.Value;

//  public static bool operator ==(IsValidEnumThree left, bool right) => left.Value == (right ? ProxyEnum.True : ProxyEnum.False);

//  public static bool operator ==(IsValidEnumThree left, int right) => (int)left.Value.Value == right;

//  public static bool operator ==(bool left, IsValidEnumThree right) => (left ? 1 : 0) == (int)right.Value.Value;

//  public static bool operator !=(IsValidEnumThree left, IsValidEnumThree right) => left.Value.Value != right.Value.Value;

//  public static bool operator !=(IsValidEnumThree left, bool right) => (int)left.Value.Value != (right ? 1 : 0);

//  public static bool operator !=(IsValidEnumThree left, int right) => (int)left.Value.Value != right;

//  public static bool operator !=(bool left, IsValidEnumThree right) => (left ? 1 : 0) != (int)right.Value.Value;

//  public static implicit operator IsValidEnumThree(ProxyEnum value) => FromValue(value);

//  public override bool Equals(object obj) => obj is IsValidEnumThree other && this == other;

//  public override int GetHashCode() => Value.GetHashCode();

//  public bool Equals(ProxyEnum other) => Equals(FromValue(other));

//  public int CompareTo(ProxyEnum other) => CompareTo(FromValue(other));

//  public int CompareTo(ProxyEnumWrapper<IsValidEnumThree, ProxyEnum>? other) => Value.CompareTo(other?.Value);

//  public bool Equals(ProxyEnumWrapper<IsValidEnumThree, ProxyEnum>? other) => Value.Equals(other?.Value);
//}
