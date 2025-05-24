namespace Another.Tests;

using FluentAssertions;
using PrimS.BoolParameterGenerator;

public class IsValidEnumThreeTests
{
  [Fact]
  public void GivenIsValidEnumThreeYesShouldBeTrue()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidEnumThreeFalseShouldBeFalse()
  {
    var isValidEnumThree = IsValidEnumThree.No;
    isValidEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidEnumThreeTrueWhenCastBoolShouldBeTrue()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidEnumThreeNoWhenCastBoolShouldBeFalse()
  {
    var isValidEnumThree = IsValidEnumThree.No;
    isValidEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidEnumThreeYesShouldBeIsValidEnumThreeYes()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().Be(IsValidEnumThree.Yes);
  }

  [Fact]
  public void GivenIsValidEnumThreeNoShouldBeIsValidEnumThreeNo()
  {
    var isValidEnumThree = IsValidEnumThree.No;
    isValidEnumThree.Should().Be(IsValidEnumThree.No);
  }

  [Fact]
  public void GivenIsValidEnumThreeYesShouldBeBoolTrue()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().Be(true);
  }

  [Fact]
  public void GivenIsValidEnumThreeFalseShouldBeBoolFalse()
  {
    var isValidEnumThree = IsValidEnumThree.No;
    isValidEnumThree.Should().Be(false);
  }

  [Fact]
  public void GivenIsValidEnumThreeYesShouldNotBeFalse()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().NotBe(false);
  }

  [Fact]
  public void GivenIsValidEnumThreeYesShouldNotBeIsValidEnumThreeFalse()
  {
    var isValidEnumThree = IsValidEnumThree.Yes;
    isValidEnumThree.Should().NotBe(IsValidEnumThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
  {
    IsValidEnumThree isValidEnumThree = false;

    isValidEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
  {
    IsValidEnumThree isValidEnumThree = true;

    isValidEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsValidEnumThreeParameterShouldBeFalse()
  {
    IsValidEnumThree isValidEnumThree = false;

    IsValidEnumThreeParameter(isValidEnumThree).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignIsValidEnumThreeParameterShouldBeTrue()
  {
    IsValidEnumThree isValidEnumThree = true;

    IsValidEnumThreeParameter(isValidEnumThree).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
  {
    IsBoolParameter(false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeIsValidEnumThreeNo()
  {
    false.Should().Be(IsValidEnumThree.No);
    IsBoolParameter(false).Should().Be(IsValidEnumThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
  {
    IsBoolParameter(true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBeIsValidEnumThreeTrue()
  {
    true.Should().Be(IsValidEnumThree.Yes);
    IsBoolParameter(true).Should().Be(IsValidEnumThree.Yes);
  }

  [Fact]
  public void GivenBoolTrueShouldEqualIsValidEnumThree()
  {
    (IsValidEnumThree.Yes == true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseShouldEqualIsValidEnumThree()
  {
    (IsValidEnumThree.No == false).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueShouldNotEqualOppositeIsValidEnumThree()
  {
    (IsValidEnumThree.Yes == false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseShouldNotEqualOppositeIsValidEnumThree()
  {
    (IsValidEnumThree.No == true).Should().BeFalse();
  }

  [Fact]
  public void ShouldHaveTwoValues()
  {
    IsValidEnumThree.List.Should().HaveCount(2);
  }

  private static IsValidEnumThree IsBoolParameter(bool value)
  {
    return value;
  }

  private static bool IsValidEnumThreeParameter(IsValidEnumThree value)
  {
    return value;
  }

  [Theory]
  [InlineData(ProxyEnum.True, true)]
  [InlineData(ProxyEnum.False, false)]
  public void FromProxyEnumShouldMatchCastBool(ProxyEnum expected, bool value)
  {
#pragma warning disable IDE0002 
    // Don't simplify member access - it's sometimes helpful 
    // to see that Another namespace hasn't even been generated.
    var actual = Another.IsValidEnumThree.FromValue(expected);
#pragma warning restore IDE0002 // Simplify Member Access
    actual.Should().Be((IsValidEnumThree)value);
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldMatchBool(bool expected)
  {
    var actual = IsValidEnumThree.FromValue(expected);
    actual.BoolValue.Should().Be(expected);
  }

  [Theory]
  [InlineData(ProxyEnum.True, true)]
  [InlineData(ProxyEnum.False, false)]
  public void FromProxyEnumShouldMatchBool(ProxyEnum expected, bool value)
  {
    var actual = IsValidEnumThree.FromValue(expected);
    actual.BoolValue.Should().Be(value);
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void IfShouldImplicitlyBehaveAsBool(bool expected)
  {
    IsValidEnumThree actual = expected;
    if (actual)
    {
      actual.Should().BeTrue();
    }
    else
    {
      actual.Should().BeFalse();
    }
  }

  [Theory]
  [InlineData(ProxyEnum.True)]
  [InlineData(ProxyEnum.False)]
  public void FromProxyEnumShouldMatchProxyEnum(ProxyEnum expected)
  {
    var actual = IsValidEnumThree.FromValue(expected);
    actual.Should().Be(expected);
  }

  [Theory]
  [InlineData(ProxyEnum.True)]
  [InlineData(ProxyEnum.False)]
  public void FromProxyEnumShouldMatchInt(ProxyEnum expected)
  {
    var actual = IsValidEnumThree.FromValue(expected);
    (actual == (int)expected).Should().BeTrue();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldMatchFromBool(bool expected)
  {
    var actual = IsValidEnumThree.FromValue(expected);
    (expected == actual).Should().BeTrue();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidEnumThree.FromValue(left);
    (left != right).Should().BeFalse();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidEnumThree.FromValue(left);
    (IsValidEnumThree.FromValue(left) != right).Should().BeFalse();
  }

  [Theory]
  [InlineData(ProxyEnum.True)]
  [InlineData(ProxyEnum.False)]
  public void HopedItWouldntButWillStillHighlightMissedMember(ProxyEnum value)
  {
    IsValidEnumThree cast = value;
    switch (cast.ProxyValue)
    {
      case ProxyEnum.True:
        break;
      case ProxyEnum.False:
        break;
        //default:
        //  break;
    }
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void ShouldNotHighlightMissedBoolMember(bool value)
  {
    IsValidEnumThree cast = value;
    switch (cast.BoolValue)
    {
      case true:
      case false:
        cast.Should().Be(value);
        break;
    }
  }

  [Theory]
  [InlineData(true, "Yes")]
  [InlineData(false, "No")]
  public void ToStringShouldBeProxyEnumMemberName(bool value, string expected)
  {
    IsValidEnumThree cast = value;
    cast.ToString().Should().Be(expected);
  }
}
