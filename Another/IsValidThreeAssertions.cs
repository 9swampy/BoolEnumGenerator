namespace Another;

using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;

public partial class IsValidThreeAssertions(IsValidThree instance) : ReferenceTypeAssertions<IsValidThree, IsValidThreeAssertions>(instance)
{
  protected override string Identifier => "IsValidThree";

  public AndConstraint<IsValidThreeAssertions> BeTrue(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == true)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidThree} to be true but found {0}.", Subject);

    return new AndConstraint<IsValidThreeAssertions>(this);
  }

  public AndConstraint<IsValidThreeAssertions> BeFalse(string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == false)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidThree} to be false but found {0}.", Subject);

    return new AndConstraint<IsValidThreeAssertions>(this);
  }

  public AndConstraint<IsValidThreeAssertions> NotBe(IsValidThree unexpected, string because = "", params object[] becauseArgs)
  {
    return NotBe((bool)unexpected, because, becauseArgs);
  }

  public AndConstraint<IsValidThreeAssertions> NotBe(bool unexpected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject != unexpected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidThree} to not be {0} but found {1}.", unexpected, Subject);

    return new AndConstraint<IsValidThreeAssertions>(this);
  }

  public AndConstraint<IsValidThreeAssertions> Be(IsValidThree expected, string because = "", params object[] becauseArgs)
  {
    return Be((bool)expected, because, becauseArgs);
  }

  public AndConstraint<IsValidThreeAssertions> Be(bool expected, string because = "", params object[] becauseArgs)
  {
    Execute.Assertion
        .ForCondition(Subject == expected)
        .BecauseOf(because, becauseArgs)
        .FailWith("Expected {context:IsValidThree} to be {0} but found {1}.", expected, Subject);

    return new AndConstraint<IsValidThreeAssertions>(this);
  }
}