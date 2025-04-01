
namespace Another;

using FluentAssertions.Primitives;
using FluentAssertions;

public partial class IsValidBoolThreeAssertions(IsValidBoolThree instance) : BooleanAssertions<IsValidBoolThreeAssertions>(instance)
{
  public AndConstraint<IsValidBoolThreeAssertions> NotBe(IsValidBoolThree unexpected, string because = "", params object[] becauseArgs)
  {
    return base.NotBe(unexpected.Value, because, becauseArgs);
  }

  public AndConstraint<IsValidBoolThreeAssertions> Be(IsValidBoolThree expected, string because = "", params object[] becauseArgs)
  {
    return base.Be(expected.Value, because, becauseArgs);
  }
}