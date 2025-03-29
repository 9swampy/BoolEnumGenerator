
namespace FluentAssertions
{
  using System;
  using FluentAssertions.Execution;
  using FluentAssertions.Primitives;
  using Another;

  public static class IsValidThreeExtensions
  {
      public static IsValidThreeAssertions Should(this IsValidThree instance)
      {
          return new IsValidThreeAssertions(instance);
      }
  }
}