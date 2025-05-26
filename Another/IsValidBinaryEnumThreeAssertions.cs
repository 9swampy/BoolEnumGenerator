//namespace Another;

//using FluentAssertions.Execution;
//using FluentAssertions.Primitives;
//using FluentAssertions;

//public partial class isValidBinaryEnumThreeAssertions(isValidBinaryEnumThree instance) : ReferenceTypeAssertions<isValidBinaryEnumThree, isValidBinaryEnumThreeAssertions>(instance)
//{
//  protected override string Identifier => "isValidBinaryEnumThree";

//  public AndConstraint<isValidBinaryEnumThreeAssertions> BeTrue(string because = "", params object[] becauseArgs)
//  {
//    Execute.Assertion
//        .ForCondition(Subject == isValidBinaryEnumThree.Yes)
//        .BecauseOf(because, becauseArgs)
//        .FailWith("Expected {context:isValidBinaryEnumThree} to be true but found {0}.", Subject);

//    return new AndConstraint<isValidBinaryEnumThreeAssertions>(this);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> BeFalse(string because = "", params object[] becauseArgs)
//  {
//    Execute.Assertion
//        .ForCondition(Subject == isValidBinaryEnumThree.No)
//        .BecauseOf(because, becauseArgs)
//        .FailWith("Expected {context:isValidBinaryEnumThree} to be false but found {0}.", Subject);

//    return new AndConstraint<isValidBinaryEnumThreeAssertions>(this);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> NotBe(isValidBinaryEnumThree unexpected, string because = "", params object[] becauseArgs)
//  {
//    return NotBe((int)unexpected.Value.Value, because, becauseArgs);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> NotBe(bool expected, string because = "", params object[] becauseArgs)
//  {
//    return NotBe(expected ? 0x1 : 0x0, because, becauseArgs);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> NotBe(int unexpected, string because = "", params object[] becauseArgs)
//  {
//    Execute.Assertion
//        .ForCondition((int)Subject.Value.Value != unexpected)
//        .BecauseOf(because, becauseArgs)
//        .FailWith("Expected {context:isValidBinaryEnumThree} to not be {0} but found {1}.", unexpected, Subject);

//    return new AndConstraint<isValidBinaryEnumThreeAssertions>(this);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> Be(isValidBinaryEnumThree expected, string because = "", params object[] becauseArgs)
//  {
//    return Be((int)expected.Value.Value, because, becauseArgs);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> Be(bool expected, string because = "", params object[] becauseArgs)
//  {
//    return Be(expected ? 0x1 : 0x0, because, becauseArgs);
//  }

//  public AndConstraint<isValidBinaryEnumThreeAssertions> Be(int expected, string because = "", params object[] becauseArgs)
//  {
//    Execute.Assertion
//        .ForCondition((int)Subject.Value.Value == expected)
//        .BecauseOf(because, becauseArgs)
//        .FailWith("Expected {context:isValidBinaryEnumThree} to be {0} but found {1}.", expected, Subject);

//    return new AndConstraint<isValidBinaryEnumThreeAssertions>(this);
//  }
//}
