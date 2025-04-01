namespace Another;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;

public partial class IsValidEnumThreeAssertions(IsValidEnumThree instance) : ReferenceTypeAssertions<IsValidEnumThree, IsValidEnumThreeAssertions>(instance)
{
  protected override string Identifier => "IsValidEnumThree";

  public AndConstraint<IsValidEnumThreeAssertions> BeTrue(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == IsValidEnumThree.Yes)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidEnumThree} to be true but found {0}.", Subject);

    return new AndConstraint<IsValidEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidEnumThreeAssertions> BeFalse(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == IsValidEnumThree.No)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidEnumThree} to be false but found {0}.", Subject);

    return new AndConstraint<IsValidEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidEnumThreeAssertions> NotBe(IsValidEnumThree unexpected, string because = "", params object[] becauseArgs)
  {
    return NotBe((int)unexpected.Value.Value, because, becauseArgs);
  }

  public AndConstraint<IsValidEnumThreeAssertions> NotBe(bool expected, string because = "", params object[] becauseArgs)
  {
    return NotBe(expected ? 0x1 : 0x0, because, becauseArgs);
  }

  public AndConstraint<IsValidEnumThreeAssertions> NotBe(int unexpected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition((int)Subject.Value.Value != unexpected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidEnumThree} to not be {0} but found {1}.", unexpected, Subject);

    return new AndConstraint<IsValidEnumThreeAssertions>(this);
  }

  public AndConstraint<IsValidEnumThreeAssertions> Be(IsValidEnumThree expected, string because = "", params object[] becauseArgs)
  {
    return Be((int)expected.Value.Value, because, becauseArgs);
  }

  public AndConstraint<IsValidEnumThreeAssertions> Be(bool expected, string because = "", params object[] becauseArgs)
  {
    return Be(expected ? 0x1 : 0x0, because, becauseArgs);
  }

  public AndConstraint<IsValidEnumThreeAssertions> Be(int expected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition((int)Subject.Value.Value == expected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidEnumThree} to be {0} but found {1}.", expected, Subject);

    return new AndConstraint<IsValidEnumThreeAssertions>(this);
  }
}