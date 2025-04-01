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