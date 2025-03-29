namespace FluentAssertions;

using Another;

public static class IsValidEnumThreeExtensions
{
  public static IsValidEnumThreeAssertions Should(this IsValidEnumThree instance)
  {
    return new IsValidEnumThreeAssertions(instance);
  }
}