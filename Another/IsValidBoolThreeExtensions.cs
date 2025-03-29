
#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace FluentAssertions;

using Another;

public static class IsValidBoolThreeExtensions
{
  public static IsValidBoolThreeAssertions Should(this IsValidBoolThree instance)
  {
    return new IsValidBoolThreeAssertions(instance);
  }
}