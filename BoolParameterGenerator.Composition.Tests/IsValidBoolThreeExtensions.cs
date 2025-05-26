namespace FluentAssertions;

using Another;

public static class IsValidBoolThreeExtensions
{
  public static IsValidBoolThreeAssertions Should(this IsValidBoolThree instance)
  {
    return new IsValidBoolThreeAssertions(instance);
  }
}
