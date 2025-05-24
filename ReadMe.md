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
[GenerateBinaryEnum("TrueValue", "FalseValue")] public partial class MyBinaryEnum { }
[GenerateBoolEnum("TrueValue", "FalseValue")] public partial class MyBoolEnum { }
It is essential for the class to be partial, because the source generator will create the content for the class in another file.
The generated content can be found by expanding the Dependencies->Analyzers->BoolParameterGenerator node.
If you only find a Heartbeat.g.cs in the generated content then check the instructions above have been followed correctly.

Note that the GenerateBinaryEnum/GenerateBoolEnum attributes actually come from the dependency Nuget package BoolParameterGenerator.Shared.

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
1. Clean solution
1. Rebuild the Nuget.Tests project
1. You may get PrimS reference errors, open the file erroring and the errors will go away when Visual Studio catches up with Nuget availability.
1. If you don't see BEG004 in Error List then rebuild the NugetTests project.
1. You should now have a happily building solution with no errors and content in the Generated folder. However the namespace of the triggering GeneratedBoolEnums doesn't match the generated code; is that a problem? I'd expect to move the GeneratedBoolEnums in to the Another namespace so the triggering partial would match with the generated files but if i do that then the files don't generate.