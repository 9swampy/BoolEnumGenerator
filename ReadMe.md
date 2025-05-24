# BoolParameterGenerator

BoolParameterGenerator is a source generator that automatically generates replacement types for boolean parameters.

## Features

- Generates replacement types for boolean parameters.
- Supports binary enums and binary structs.
- Easy to use with minimal configuration.

## Installation

To install BoolParameterGenerator, add the following package reference to your project:
<PackageReference Include="BoolParameterGenerator" Version="1.0.0" />

## Usage

To use BoolParameterGenerator, apply the appropriate attributes to your classes:
using PrimS.BoolParameterGenerator;
[GenerateBinaryStruct("Namespace", "TrueValue", "FalseValue")] public class MyBinaryStruct { }
[GenerateBinaryEnum("Namespace", "TrueValue", "FalseValue")] public class MyBinaryEnum { }
[GenerateBoolEnum("Namespace", "TrueValue", "FalseValue")] public class MyBoolEnum { }

## License

This project is licensed under the MIT License.

### How to regenerate every time 
(or not when you need to update the templates)

If you need to do a comparison:
1. Unhide the generated folder (in Another.csproj),
1. Compare two with three files, 
1. Make changes to the three file
1. When happy replicate the changes in the generator template
1. Delete the two file you expect to get modified to it'll be regenerated
1. Regenerate the files, rinse repeat and then finally...
1. When you're 100% happy reinstate the csproj to hide the generated folder.

### Confirmed working state
1. Load only the generator projects and the Nuget.Tests.
1. Clean the BoolParameterGenerator project.
1. Build the BoolParameterGenerator project.
1. Pack the BoolParameterGenerator project.
1. This will have cleared the nuget cache so PrimS.BoolParameterGenerator.Nuget.Tests may be complaining; don't worry.
1. Clean the Nuget.Tests project.
1. Delete the Nuget.Tests bin and obj folders.
1. Delete the folders inside Nuget.Tests\Generated leaving BinaryEnumGenerator to last.
1. Delete the Nuget.Tests\Generated folder.
1. Redelete the Nuget.Tests bin and obj folders if they've reappeared.
1. Clean the Nuget.Tests project again; packages likely will have bangs, but don't worry.
1. Build the Nuget.Tests project.
1. You may get PrimS reference errors, open the file erroring and the errors will go away when Visual Studio catches up with Nuget availability.
1. You should now have a happily building solution with no errors and content in the Generated folder. However the namespace of the triggering GeneratedBoolEnums doesn't match the generated code; is that a problem? I'd expect to move the GeneratedBoolEnums in to the Another namespace so the triggering partial would match with the generated files but if i do that then the files don't generate.