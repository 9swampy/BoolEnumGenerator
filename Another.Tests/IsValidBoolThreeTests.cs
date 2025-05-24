namespace Another.Tests;

using FluentAssertions;

public class IsValidBoolThreeTests
{
  [Fact]
  public void GivenIsValidBoolThreeYesShouldBeTrue()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidBoolThreeFalseShouldBeFalse()
  {
    var isValidBoolThree = IsValidBoolThree.No;
    isValidBoolThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidBoolThreeTrueWhenCastBoolShouldBeTrue()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidBoolThreeNoWhenCastBoolShouldBeFalse()
  {
    var isValidBoolThree = IsValidBoolThree.No;
    isValidBoolThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidBoolThreeYesShouldBeIsValidBoolThreeYes()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().Be(IsValidBoolThree.Yes);
  }

  [Fact]
  public void GivenIsValidBoolThreeNoShouldBeIsValidBoolThreeNo()
  {
    var isValidBoolThree = IsValidBoolThree.No;
    isValidBoolThree.Should().Be(IsValidBoolThree.No);
  }

  [Fact]
  public void GivenIsValidBoolThreeYesShouldBeBoolTrue()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().Be(true);
  }

  [Fact]
  public void GivenIsValidBoolThreeFalseShouldBeBoolFalse()
  {
    var isValidBoolThree = IsValidBoolThree.No;
    isValidBoolThree.Should().Be(false);
  }

  [Fact]
  public void GivenIsValidBoolThreeYesShouldNotBeFalse()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().NotBe(false);
  }

  [Fact]
  public void GivenIsValidBoolThreeYesShouldNotBeIsValidBoolThreeFalse()
  {
    var isValidBoolThree = IsValidBoolThree.Yes;
    isValidBoolThree.Should().NotBe(IsValidBoolThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
  {
    IsValidBoolThree isValidBoolThree = false;

    isValidBoolThree.Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
  {
    IsValidBoolThree isValidBoolThree = true;

    isValidBoolThree.Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsValidBoolThreeParameterShouldBeFalse()
  {
    IsValidBoolThree isValidBoolThree = false;

    IsValidBoolThreeParameter(isValidBoolThree).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignIsValidBoolThreeParameterShouldBeTrue()
  {
    IsValidBoolThree isValidBoolThree = true;

    IsValidBoolThreeParameter(isValidBoolThree).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
  {
    IsBoolParameter(false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeIsValidBoolThreeNo()
  {
    false.Should().Be(IsValidBoolThree.No);
    IsBoolParameter(false).Should().Be(IsValidBoolThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
  {
    IsBoolParameter(true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBeIsValidBoolThreeTrue()
  {
    true.Should().Be(IsValidBoolThree.Yes);
    IsBoolParameter(true).Should().Be(IsValidBoolThree.Yes);
  }

  [Fact]
  public void GivenBoolTrueShouldEqualIsValidBoolThree()
  {
    (IsValidBoolThree.Yes == true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseShouldEqualIsValidBoolThree()
  {
    (IsValidBoolThree.No == false).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueShouldNotEqualOppositeIsValidBoolThree()
  {
    (IsValidBoolThree.Yes == false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseShouldNotEqualOppositeIsValidBoolThree()
  {
    (IsValidBoolThree.No == true).Should().BeFalse();
  }

  [Fact]
  public void ShouldHaveTwoValues()
  {
    IsValidBoolThree.List.Should().HaveCount(2);
  }

  private static IsValidBoolThree IsBoolParameter(bool value)
  {
    return value;
  }

  private static bool IsValidBoolThreeParameter(IsValidBoolThree value)
  {
    return value;
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Don't simplify member access - it's sometimes helpful to see that Another namespace hasn't even been generated.")]
  public void FromBoolShouldMatchBool(bool expected)
  {
    // Don't simplify member access - it's sometimes helpful 
    // to see that Another namespace hasn't even been generated.
#pragma warning disable IDE0002 
    var actual = Another.IsValidBoolThree.FromValue(expected);
#pragma warning restore IDE0002 // Simplify Member Access
    actual.Should().Be(expected);
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void IfShouldImplicitlyBehaveAsBool(bool expected)
  {
    IsValidBoolThree actual = expected;
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
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldMatchInt(bool expected)
  {
    var actual = IsValidBoolThree.FromValue(expected);
    (actual == (expected ? 1 : 0)).Should().BeTrue();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldMatchFromBool(bool expected)
  {
    var actual = IsValidBoolThree.FromValue(expected);
    (expected == actual).Should().BeTrue();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidBoolThree.FromValue(left);
    (left != right).Should().BeFalse();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidBoolThree.FromValue(left);
    (IsValidBoolThree.FromValue(left) != right).Should().BeFalse();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void ShouldNotHighlightMissedBoolMember(bool value)
  {
    IsValidBoolThree cast = value;
    switch (cast.Value)
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
    IsValidBoolThree cast = value;
    cast.ToString().Should().Be(expected);
  }
}
