#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace FluentAssertions;

using Another;

public static partial class IsValidThreeExtensions
{
  public static IsValidThreeAssertions Should(this IsValidThree instance)
  {
    return new IsValidThreeAssertions(instance);
  }
}