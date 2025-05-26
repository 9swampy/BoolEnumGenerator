namespace Another;

using System;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;

public class IsValidBinaryEnumThreeAssertions : ReferenceTypeAssertions<IsValidBinaryEnumThree, IsValidBinaryEnumThreeAssertions>
{
  public IsValidBinaryEnumThreeAssertions(IsValidBinaryEnumThree instance) : base(instance) { }

  protected override string Identifier => "isValidBinaryEnumThree";

  public AndConstraint<IsValidBinaryEnumThreeAssertions> BeTrue(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == IsValidBinaryEnumThree.Yes)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:isValidBinaryEnumThree} to be true but found {0}.", Subject);

    return new AndConstraint<IsValidBinaryEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> BeFalse(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == IsValidBinaryEnumThree.No)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:isValidBinaryEnumThree} to be false but found {0}.", Subject);

    return new AndConstraint<IsValidBinaryEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> NotBe(IsValidBinaryEnumThree unexpected, string because = "", params object[] becauseArgs)
  {
    return NotBe((int)unexpected.Value, because, becauseArgs);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> NotBe(bool expected, string because = "", params object[] becauseArgs)
  {
    return NotBe(expected ? 0x1 : 0x0, because, becauseArgs);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> NotBe(int unexpected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition((int)Subject.Value != unexpected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:isValidBinaryEnumThree} to not be {0} but found {1}.", unexpected, Subject);

    return new AndConstraint<IsValidBinaryEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> Be(IsValidBinaryEnumThree expected, string because = "", params object[] becauseArgs)
  {
    return Be((int)expected.Value, because, becauseArgs);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> Be(bool expected, string because = "", params object[] becauseArgs)
  {
    return Be(expected ? 0x1 : 0x0, because, becauseArgs);
  }

  public AndConstraint<IsValidBinaryEnumThreeAssertions> Be(int expected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition((int)Subject.Value == expected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:isValidBinaryEnumThree} to be {0} but found {1}.", expected, Subject);

    return new AndConstraint<IsValidBinaryEnumThreeAssertions>(this);
  }
}
