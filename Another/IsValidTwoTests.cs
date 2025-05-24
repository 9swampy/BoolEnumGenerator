
//namespace Another
//{
//  using Xunit;
//  using FluentAssertions;
//  using Another;

//  public partial class IsValidTwoTests
//  {
//    [Fact]
//    public void GivenIsValidTwoTrueShouldBeTrue()
//    {
//      var isValidTwo = IsValidTwo.True;
//      isValidTwo.Should().BeTrue();
//    }

//    [Fact]
//    public void GivenIsValidTwoFalseShouldBeFalse()
//    {
//      var isValidTwo = IsValidTwo.False;
//      isValidTwo.Should().BeFalse();
//    }

//    [Fact]
//    public void GivenIsValidTwoTrueWhenCastBoolShouldBeTrue()
//    {
//      var isValidTwo = IsValidTwo.True;
//      ((bool)isValidTwo).Should().BeTrue();
//    }

//    [Fact]
//    public void GivenIsValidTwoFalseWhenCastBoolShouldBeFalse()
//    {
//      var isValidTwo = IsValidTwo.False;
//      ((bool)isValidTwo).Should().BeFalse();
//    }

//    [Fact]
//    public void GivenIsValidTwoTrueShouldBeIsValidTwoTrue()
//    {
//      var isValidTwo = IsValidTwo.True;
//      isValidTwo.Should().Be(IsValidTwo.True);
//    }

//    [Fact]
//    public void GivenIsValidTwoFalseShouldBeIsValidTwoFalse()
//    {
//      var isValidTwo = IsValidTwo.False;
//      isValidTwo.Should().Be(IsValidTwo.False);
//    }

//    [Fact]
//    public void GivenIsValidTwoTrueShouldBeBoolTrue()
//    {
//      var isValidTwo = IsValidTwo.True;
//      isValidTwo.Should().Be(true);
//    }

//    [Fact]
//    public void GivenIsValidTwoFalseShouldBeBoolFalse()
//    {
//      var isValidTwo = IsValidTwo.False;
//      isValidTwo.Should().Be(false);
//    }

//    [Fact]
//    public void GivenIsValidTwoTrueShouldNotBeFalse()
//    {
//      var isValidTwo = IsValidTwo.True;
//      isValidTwo.Should().NotBe(false);
//    }

//    [Fact]
//    public void GivenIsValidTwoTrueShouldNotBeIsValidTwoFalse()
//    {
//      var isValidTwo = IsValidTwo.True;
//      isValidTwo.Should().NotBe(IsValidTwo.False);
//    }

//    [Fact]
//    public void ShouldCtor()
//    {
//      var isValidTwo = new IsValidTwo();

//      isValidTwo.Should().NotBeNull();
//    }

//    [Fact]
//    public void GivenBoolFalseWhenImplicitAssignShouldBeFalse()
//    {
//      IsValidTwo isValidTwo = false;

//      isValidTwo.Should().BeFalse();
//    }

//    [Fact]
//    public void GivenBoolTrueWhenImplicitAssignShouldBeTrue()
//    {
//      IsValidTwo isValidTwo = true;

//      isValidTwo.Should().BeTrue();
//    }

//    [Fact]
//    public void GivenBoolFalseWhenImplicitAssignIsValidTwoParameterShouldBeFalse()
//    {
//      IsValidTwo isValidTwo = false;

//      IsValidTwoParameter(isValidTwo).Should().BeFalse();
//    }

//    [Fact]
//    public void GivenBoolTrueWhenImplicitAssignIsValidTwoParameterShouldBeTrue()
//    {
//      IsValidTwo isValidTwo = true;

//      IsValidTwoParameter(isValidTwo).Should().BeTrue();
//    }

//    [Fact]
//    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeFalse()
//    {
//      IsBoolParameter(false).Should().BeFalse();
//    }

//    [Fact]
//    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeIsValidTwoFalse()
//    {
//      false.Should().Be(IsValidTwo.False);
//      IsBoolParameter(false).Should().Be(IsValidTwo.False);
//    }

//    [Fact]
//    public void GivenBoolFalseWhenImplicitAssignIsBoolParameterShouldBeTrue()
//    {
//      IsBoolParameter(true).Should().BeTrue();
//    }

//    [Fact]
//    public void GivenBoolTrueWhenImplicitAssignIsBoolParameterShouldBeIsValidTwoTrue()
//    {
//      true.Should().Be(IsValidTwo.True);
//      IsBoolParameter(true).Should().Be(IsValidTwo.True);
//    }

//    [Fact]
//    public void GivenBoolTrueShouldEqualIsValidTwo()
//    {
//      (IsValidTwo.True == true).Should().BeTrue();
//    }

//    [Fact]
//    public void GivenBoolFalseShouldEqualIsValidTwo()
//    {
//      (IsValidTwo.False == false).Should().BeTrue();
//    }

//    [Fact]
//    public void GivenBoolTrueShouldNotEqualOppositeIsValidTwo()
//    {
//      (IsValidTwo.True == false).Should().BeFalse();
//    }

//    [Fact]
//    public void GivenBoolFalseShouldNotEqualOppositeIsValidTwo()
//    {
//      (IsValidTwo.False == true).Should().BeFalse();
//    }

//    private static IsValidTwo IsBoolParameter(bool value)
//    {
//      return value;
//    }

//    private static bool IsValidTwoParameter(IsValidTwo value)
//    {
//      return value;
//    }
//  }
//}
