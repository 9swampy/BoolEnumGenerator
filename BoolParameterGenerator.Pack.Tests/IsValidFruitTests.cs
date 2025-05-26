namespace Another.Tests;

using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IsValidFruitTests
{
  [Theory]
  [InlineData(true, "Apple")]
  [InlineData(false, "Banana")]
  public void BoolFruitToStringShouldBeGeneratorMemberName(bool value, string expected)
  {
    IsValidBoolFruit cast = value;
    cast.ToString().Should().Be(expected);
  }

  [Theory]
  [InlineData(true, "Apple")]
  [InlineData(false, "Banana")]
  public void EnumFruitToStringShouldBeGeneratorMemberName(bool value, string expected)
  {
    IsValidBinaryEnumFruit cast = value;
    cast.ToString().Should().Be(expected);
  }
}
