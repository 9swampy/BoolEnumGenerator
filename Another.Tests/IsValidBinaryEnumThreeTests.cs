namespace Another.Tests;

using FluentAssertions;
using PrimS.BoolParameterGenerator;

public class IsValidBinaryEnumThreeTests
{
  [Fact]
  public void GivenIsValidBinaryEnumThreeYesShouldBeTrue()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeFalseShouldBeFalse()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.No;
    isValidBinaryEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeTrueWhenCastBoolShouldBeTrue()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeNoWhenCastBoolShouldBeFalse()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.No;
    isValidBinaryEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeYesShouldBeisValidBinaryEnumThreeYes()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().Be(IsValidBinaryEnumThree.Yes);
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeNoShouldBeisValidBinaryEnumThreeNo()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.No;
    isValidBinaryEnumThree.Should().Be(IsValidBinaryEnumThree.No);
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeYesShouldBeBoolTrue()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().Be(true);
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeFalseShouldBeBoolFalse()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.No;
    isValidBinaryEnumThree.Should().Be(false);
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeYesShouldNotBeFalse()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().NotBe(false);
  }

  [Fact]
  public void GivenIsValidBinaryEnumThreeYesShouldNotBeisValidBinaryEnumThreeFalse()
  {
    var isValidBinaryEnumThree = IsValidBinaryEnumThree.Yes;
    isValidBinaryEnumThree.Should().NotBe(IsValidBinaryEnumThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
  {
    IsValidBinaryEnumThree isValidBinaryEnumThree = false;

    isValidBinaryEnumThree.Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
  {
    IsValidBinaryEnumThree isValidBinaryEnumThree = true;

    isValidBinaryEnumThree.Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignisValidBinaryEnumThreeParameterShouldBeFalse()
  {
    IsValidBinaryEnumThree isValidBinaryEnumThree = false;

    IsValidBinaryEnumThreeParameter(isValidBinaryEnumThree).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignisValidBinaryEnumThreeParameterShouldBeTrue()
  {
    IsValidBinaryEnumThree isValidBinaryEnumThree = true;

    IsValidBinaryEnumThreeParameter(isValidBinaryEnumThree).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
  {
    IsBoolParameter(false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeisValidBinaryEnumThreeNo()
  {
    false.Should().Be(IsValidBinaryEnumThree.No);
    IsBoolParameter(false).Should().Be(IsValidBinaryEnumThree.No);
  }

  [Fact]
  public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
  {
    IsBoolParameter(true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBeisValidBinaryEnumThreeTrue()
  {
    true.Should().Be(IsValidBinaryEnumThree.Yes);
    IsBoolParameter(true).Should().Be(IsValidBinaryEnumThree.Yes);
  }

  [Fact]
  public void GivenBoolTrueShouldEqualisValidBinaryEnumThree()
  {
    (IsValidBinaryEnumThree.Yes == true).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolFalseShouldEqualisValidBinaryEnumThree()
  {
    (IsValidBinaryEnumThree.No == false).Should().BeTrue();
  }

  [Fact]
  public void GivenBoolTrueShouldNotEqualOppositeisValidBinaryEnumThree()
  {
    (IsValidBinaryEnumThree.Yes == false).Should().BeFalse();
  }

  [Fact]
  public void GivenBoolFalseShouldNotEqualOppositeisValidBinaryEnumThree()
  {
    (IsValidBinaryEnumThree.No == true).Should().BeFalse();
  }

  [Fact]
  public void ShouldHaveTwoValues()
  {
    IsValidBinaryEnumThree.List.Should().HaveCount(2);
  }

  private static IsValidBinaryEnumThree IsBoolParameter(bool value)
  {
    return value;
  }

  private static bool IsValidBinaryEnumThreeParameter(IsValidBinaryEnumThree value)
  {
    return value;
  }

//  [Theory]
//  [InlineData(BinaryEnum.True, true)]
//  [InlineData(BinaryEnum.False, false)]
//  public void FromBinaryEnumShouldMatchCastBool(BinaryEnum expected, bool value)
//  {
//#pragma warning disable IDE0002 
//    // Don't simplify member access - it's sometimes helpful 
//    // to see that Another namespace hasn't even been generated.
//    var actual = Another.IsValidBinaryEnumThree.FromValue(expected);
//#pragma warning restore IDE0002 // Simplify Member Access
//    actual.Should().Be((IsValidBinaryEnumThree)value);
//  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldMatchBool(bool expected)
  {
    var actual = IsValidBinaryEnumThree.FromValue(expected);
    actual.BoolValue.Should().Be(expected);
  }

  //[Theory]
  //[InlineData(BinaryEnum.True, true)]
  //[InlineData(BinaryEnum.False, false)]
  //public void FromBinaryEnumShouldMatchBool(BinaryEnum expected, bool value)
  //{
  //  var actual = IsValidBinaryEnumThree.FromValue(expected);
  //  actual.BoolValue.Should().Be(value);
  //}

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void IfShouldImplicitlyBehaveAsBool(bool expected)
  {
    IsValidBinaryEnumThree actual = expected;
    if (actual)
    {
      actual.Should().BeTrue();
    }
    else
    {
      actual.Should().BeFalse();
    }
  }

  //[Theory]
  //[InlineData(BinaryEnum.True)]
  //[InlineData(BinaryEnum.False)]
  //public void FromBinaryEnumShouldMatchBinaryEnum(BinaryEnum expected)
  //{
  //  var actual = IsValidBinaryEnumThree.FromValue(expected);
  //  actual.Should().Be(expected);
  //}

  //[Theory]
  //[InlineData(BinaryEnum.True)]
  //[InlineData(BinaryEnum.False)]
  //public void FromBinaryEnumShouldMatchInt(BinaryEnum expected)
  //{
  //  var actual = IsValidBinaryEnumThree.FromValue(expected);
  //  (actual == (int)expected).Should().BeTrue();
  //}

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldMatchFromBool(bool expected)
  {
    var actual = IsValidBinaryEnumThree.FromValue(expected);
    (expected == actual).Should().BeTrue();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void BoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidBinaryEnumThree.FromValue(left);
    (left != right).Should().BeFalse();
  }

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void FromBoolShouldNotBeNotEqualToFromBool(bool left)
  {
    var right = IsValidBinaryEnumThree.FromValue(left);
    (IsValidBinaryEnumThree.FromValue(left) != right).Should().BeFalse();
  }

  //[Theory]
  //[InlineData(BinaryEnum.True)]
  //[InlineData(BinaryEnum.False)]
  //public void HopedItWouldntButWillStillHighlightMissedMember(BinaryEnum value)
  //{
  //  IsValidBinaryEnumThree cast = value;
  //  switch (cast.ProxyValue)
  //  {
  //    case BinaryEnum.True:
  //      break;
  //    case BinaryEnum.False:
  //      break;
  //    //default:
  //    //  break;
  //  }
  //}

  [Theory]
  [InlineData(true)]
  [InlineData(false)]
  public void ShouldNotHighlightMissedBoolMember(bool value)
  {
    IsValidBinaryEnumThree cast = value;
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
  public void ToStringShouldBeBinaryEnumMemberName(bool value, string expected)
  {
    IsValidBinaryEnumThree cast = value;
    cast.ToString().Should().Be(expected);
  }
}
