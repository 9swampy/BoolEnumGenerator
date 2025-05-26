namespace FluentAssertions;

using Another;

public static class IsValidBinaryEnumThreeExtensions
{
  public static IsValidBinaryEnumThreeAssertions Should(this IsValidBinaryEnumThree instance)
  {
    return new IsValidBinaryEnumThreeAssertions(instance);
  }
}
