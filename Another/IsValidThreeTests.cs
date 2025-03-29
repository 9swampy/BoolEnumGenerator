
namespace Another
{
  using Xunit;
  using FluentAssertions;
  using Another;

  public class IsValidThreeTests
  {
    [Fact]
    public void GivenIsValidThreeYesShouldBeTrue()
    {
      var isValidThree = IsValidThree.Yes;
      isValidThree.Should().BeTrue();
    }

    [Fact]
    public void GivenIsValidThreeFalseShouldBeFalse()
    {
      var isValidThree = IsValidThree.No;
      isValidThree.Should().BeFalse();
    }

    [Fact]
    public void GivenIsValidThreeTrueWhenCastBoolShouldBeTrue()
    {
      var isValidThree = IsValidThree.Yes;
      ((bool)isValidThree).Should().BeTrue();
    }

    [Fact]
    public void GivenIsValidThreeNoWhenCastBoolShouldBeFalse()
    {
      var isValidThree = IsValidThree.No;
      ((bool)isValidThree).Should().BeFalse();
    }

    [Fact]
    public void GivenIsValidThreeYesShouldBeIsValidThreeYes()
    {
      var isValidThree = IsValidThree.Yes;
      isValidThree.Should().Be(IsValidThree.Yes);
    }

    [Fact]
    public void GivenIsValidThreeNoShouldBeIsValidThreeNo()
    {
      var isValidThree = IsValidThree.No;
      isValidThree.Should().Be(IsValidThree.No);
    }

    [Fact]
    public void GivenIsValidThreeYesShouldBeBoolTrue()
    {
      var isValidThree = IsValidThree.Yes;
      isValidThree.Should().Be(true);
    }

    [Fact]
    public void GivenIsValidThreeFalseShouldBeBoolFalse()
    {
      var isValidThree = IsValidThree.No;
      isValidThree.Should().Be(false);
    }

    [Fact]
    public void GivenIsValidThreeYesShouldNotBeFalse()
    {
      var isValidThree = IsValidThree.Yes;
      isValidThree.Should().NotBe(false);
    }

    [Fact]
    public void GivenIsValidThreeYesShouldNotBeIsValidThreeFalse()
    {
      var isValidThree = IsValidThree.Yes;
      isValidThree.Should().NotBe(IsValidThree.No);
    }

    [Fact]
    public void ShouldCtor()
    {
      var isValidThree = new IsValidThree();

      isValidThree.Should().NotBeNull();
    }

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
    {
      IsValidThree isValidThree = false;

      isValidThree.Should().BeFalse();
    }

    [Fact]
    public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
    {
      IsValidThree isValidThree = true;

      isValidThree.Should().BeTrue();
    }

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsValidThreeParameterShouldBeFalse()
    {
      IsValidThree isValidThree = false;

      IsValidThreeParameter(isValidThree).Should().BeFalse();
    }

    [Fact]
    public void GivenBoolTrueWhenImplicitAssignIsValidThreeParameterShouldBeTrue()
    {
      IsValidThree isValidThree = true;

      IsValidThreeParameter(isValidThree).Should().BeTrue();
    }

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
    {
      IsBoolParameter(false).Should().BeFalse();
    }

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeIsValidThreeNo()
    {
      false.Should().Be(IsValidThree.No);
      IsBoolParameter(false).Should().Be(IsValidThree.No);
    }

    [Fact]
    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
    {
      IsBoolParameter(true).Should().BeTrue();
    }

    [Fact]
    public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBeIsValidThreeTrue()
    {
      true.Should().Be(IsValidThree.Yes);
      IsBoolParameter(true).Should().Be(IsValidThree.Yes);
    }

    [Fact]
    public void GivenBoolTrueShouldEqualIsValidThree()
    {
      (IsValidThree.Yes == true).Should().BeTrue();
    }

    [Fact]
    public void GivenBoolFalseShouldEqualIsValidThree()
    {
      (IsValidThree.No == false).Should().BeTrue();
    }

    [Fact]
    public void GivenBoolTrueShouldNotEqualOppositeisValidThree()
    {
      (IsValidThree.Yes == false).Should().BeFalse();
    }

    [Fact]
    public void GivenBoolFalseShouldNotEqualOppositeIsValidThree()
    {
      (IsValidThree.No == true).Should().BeFalse();
    }

    private static IsValidThree IsBoolParameter(bool value)
    {
      return value;
    }

    private static bool IsValidThreeParameter(IsValidThree value)
    {
      return value;
    }
  }
}