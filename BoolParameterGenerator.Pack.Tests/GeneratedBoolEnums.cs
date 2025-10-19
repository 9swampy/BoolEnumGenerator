namespace Another;

using PrimS.BoolParameterGenerator;

[GenerateBinaryEnum("Yes", "No")]
public partial class IsValidBinaryEnumThree
{ }

[GenerateBoolEnum("Yes", "No")]
public partial class IsValidBoolThree
{ }

[PrimS.BoolParameterGenerator.GenerateBinaryEnum("Apple", "Banana")]
public partial class IsValidBinaryEnumFruit
{ }

[PrimS.BoolParameterGenerator.GenerateBoolEnum("Apple", "Banana")]
public partial class IsValidBoolFruit
{ }

[GenerateBinaryEnum("Active", "Inactive", GenerateAssertionExtensions = false)]
public partial class StatusBinaryEnumMinimal
{ }

[GenerateBoolEnum("Enabled", "Disabled", GenerateAssertionExtensions = false)]
public partial class FeatureBoolMinimal
{ }
