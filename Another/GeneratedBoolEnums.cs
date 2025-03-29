#pragma warning disable CA1050 // Declare types in namespaces

[PrimS.BoolParameterGenerator.GenerateBinaryStruct("Another")]
public class IsValidTwo
{ }

[PrimS.BoolParameterGenerator.GenerateBinaryStruct("Another", "Yes", "No")]
public class IsValidThree
{ }

[PrimS.BoolParameterGenerator.GenerateBinaryEnum("Another", "Yes", "No")]
public class IsValidEnumTwo
{ }

[PrimS.BoolParameterGenerator.GenerateBinaryEnum("Another", "Yes", "No")]
public class IsValidEnumThree
{ }

[PrimS.BoolParameterGenerator.GenerateBoolEnum("Another", "Yes", "No")]
public class IsValidBoolTwo
{ }

[PrimS.BoolParameterGenerator.GenerateBoolEnum("Another", "Yes", "No")]
public class IsValidBoolThree
{ }