
namespace Another
{
  using System;

  public readonly struct IsValidThree
  {
      private readonly bool _value;

      public static IsValidThree Yes { get; } = new IsValidThree(true);

      public static IsValidThree No { get; } = new IsValidThree(false);

      private IsValidThree(bool value)
      {
          _value = value;
      }

      public static implicit operator bool(IsValidThree boolEnum)
      {
          return boolEnum._value;
      }

      public static implicit operator IsValidThree(bool value) => value ? Yes : No;

      public static bool operator ==(IsValidThree left, IsValidThree right) => left._value == right._value;

      public static bool operator ==(IsValidThree left, bool right) => left._value == right;

      public static bool operator ==(bool left, IsValidThree right) => left == right._value;

      public static bool operator !=(IsValidThree left, IsValidThree right) => left._value != right._value;

      public static bool operator !=(IsValidThree left, bool right) => left._value != right;

      public static bool operator !=(bool left, IsValidThree right) => left != right._value;

      public override bool Equals(object? obj) => obj is IsValidThree other && this == other;

      public override int GetHashCode() => _value.GetHashCode();

      public override string ToString()
      {
          return _value.ToString();
      }
  }
}
