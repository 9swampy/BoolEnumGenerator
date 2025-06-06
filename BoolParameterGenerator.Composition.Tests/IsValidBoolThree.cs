﻿namespace Another;

#nullable enable

using Ardalis.SmartEnum;

public partial class IsValidBoolThree : SmartEnum<IsValidBoolThree, bool>
{
  public static readonly IsValidBoolThree No = new IsValidBoolThree(nameof(No), false);
  public static readonly IsValidBoolThree Yes = new IsValidBoolThree(nameof(Yes), true);

  private IsValidBoolThree(string name, bool value) : base(name, value)
  { }

  public static implicit operator bool(IsValidBoolThree value) => value.Value;

  private int IntValue => Value ? 1 : 0;

  public static implicit operator IsValidBoolThree(bool value) => value ? Yes : No;

  public static bool operator ==(IsValidBoolThree left, IsValidBoolThree right) => left.Value == right.Value;

  public static bool operator ==(IsValidBoolThree left, bool right) => left.Value == right;

  public static bool operator ==(IsValidBoolThree left, int right) => left.IntValue == right;

  public static bool operator ==(bool left, IsValidBoolThree right) => (left ? 1 : 0) == right.IntValue;

  public static bool operator !=(IsValidBoolThree left, IsValidBoolThree right) => left.Value != right.Value;

  public static bool operator !=(IsValidBoolThree left, bool right) => left.IntValue != (right ? 1 : 0);

  public static bool operator !=(IsValidBoolThree left, int right) => left.IntValue != right;

  public static bool operator !=(bool left, IsValidBoolThree right) => (left ? 1 : 0) != right.IntValue;

  public override bool Equals(object obj) => obj is IsValidBoolThree other && this == other;

  public override int GetHashCode() => Value.GetHashCode();
}
