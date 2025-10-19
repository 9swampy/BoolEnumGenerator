# Codebase Map

This file contains a comprehensive map of the codebase structure, dependencies, and responsibilities.

Generated: 2025-10-19T01:31:41.558098

## JSON Data

```json
{
  "analysis_metadata": {
    "generation_timestamp": "2025-10-19T01:31:41.558098",
    "analyzer_version": "1.1.0",
    "files_analyzed": 31,
    "languages_detected": [
      "csharp"
    ]
  },
  "codeMap": {
    "Another/GeneratedBoolEnums.cs": {
      "classes": [
        "IsValidBinaryEnumTwo",
        "IsValidBinaryEnumThree",
        "IsValidBoolTwo",
        "IsValidBoolThree"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBinaryEnumThree",
        "IsValidBinaryEnumTwo",
        "IsValidBoolThree",
        "IsValidBoolTwo"
      ],
      "dependencies": [],
      "responsibility": "Contains 4 C# classes: IsValidBinaryEnumTwo, IsValidBinaryEnumThree, IsValidBoolTwo"
    },
    "Another/IsValidBinaryEnumThree.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "Another/IsValidBinaryEnumThreeAssertions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "Another/IsValidBinaryEnumThreeExtensions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "Another/IsValidBoolThree.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "Another/IsValidBoolThreeAssertions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "Another/IsValidBoolThreeExtensions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# namespace with utility classes"
    },
    "BoolParameterGenerator.Composition.Tests/BinaryEnum.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# utility module"
    },
    "BoolParameterGenerator.Composition.Tests/BinaryEnumWrapper.cs": {
      "classes": [
        "BinaryEnumWrapper"
      ],
      "interfaces": [],
      "exports": [],
      "dependencies": [
        "System"
      ],
      "responsibility": "C# namespace with utility classes"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBinaryEnumThree.cs": {
      "classes": [
        "IsValidBinaryEnumThree"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBinaryEnumThree"
      ],
      "dependencies": [
        "PrimS.BoolParameterGenerator",
        "System"
      ],
      "responsibility": "Provides partial IsValidBinaryEnumThree class implementation"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBinaryEnumThreeAssertions.cs": {
      "classes": [
        "IsValidBinaryEnumThreeAssertions"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBinaryEnumThreeAssertions"
      ],
      "dependencies": [
        "FluentAssertions",
        "FluentAssertions.Execution",
        "FluentAssertions.Primitives",
        "System"
      ],
      "responsibility": "Provides IsValidBinaryEnumThreeAssertions class implementation"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBinaryEnumThreeExtensions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [
        "Another"
      ],
      "responsibility": "Static utility class with helper methods"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBoolThree.cs": {
      "classes": [
        "IsValidBoolThree"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBoolThree"
      ],
      "dependencies": [
        "Ardalis.SmartEnum"
      ],
      "responsibility": "Provides partial IsValidBoolThree class implementation"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBoolThreeAssertions.cs": {
      "classes": [
        "IsValidBoolThreeAssertions"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBoolThreeAssertions"
      ],
      "dependencies": [
        "FluentAssertions",
        "FluentAssertions.Primitives"
      ],
      "responsibility": "Provides IsValidBoolThreeAssertions class implementation"
    },
    "BoolParameterGenerator.Composition.Tests/IsValidBoolThreeExtensions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [
        "Another"
      ],
      "responsibility": "Static utility class with helper methods"
    },
    "BoolParameterGenerator.Composition.Tests/SmartEnumWrapper.cs": {
      "classes": [
        "SmartEnumWrapper"
      ],
      "interfaces": [],
      "exports": [],
      "dependencies": [
        "System"
      ],
      "responsibility": "C# namespace with utility classes"
    },
    "BoolParameterGenerator.Github.Example/CallerIntellisenseBadExamples.cs": {
      "classes": [
        "CallerIntellisenseBadExamples"
      ],
      "interfaces": [],
      "exports": [
        "CallerIntellisenseBadExamples"
      ],
      "dependencies": [],
      "responsibility": "Provides CallerIntellisenseBadExamples class implementation"
    },
    "BoolParameterGenerator.Github.Example/CallerIntellisenseGoodExamples.cs": {
      "classes": [
        "CallerIntellisenseGoodExamples"
      ],
      "interfaces": [],
      "exports": [
        "CallerIntellisenseGoodExamples"
      ],
      "dependencies": [],
      "responsibility": "Provides CallerIntellisenseGoodExamples class implementation"
    },
    "BoolParameterGenerator.Github.Example/ExampleSetting.cs": {
      "classes": [
        "ExampleFeatureSwitchSetting",
        "ExampleStatusSetting"
      ],
      "interfaces": [],
      "exports": [
        "ExampleFeatureSwitchSetting",
        "ExampleStatusSetting"
      ],
      "dependencies": [
        "PrimS.BoolParameterGenerator"
      ],
      "responsibility": "Contains 2 C# classes: ExampleFeatureSwitchSetting, ExampleStatusSetting"
    },
    "BoolParameterGenerator.Github.Example/ImplementationBadExamples.cs": {
      "classes": [
        "ImplementationBadExamples"
      ],
      "interfaces": [],
      "exports": [
        "ImplementationBadExamples"
      ],
      "dependencies": [],
      "responsibility": "Provides ImplementationBadExamples class implementation"
    },
    "BoolParameterGenerator.Github.Example/ImplementationGoodExamples.cs": {
      "classes": [
        "ImplementationGoodExamples"
      ],
      "interfaces": [],
      "exports": [
        "ImplementationGoodExamples"
      ],
      "dependencies": [],
      "responsibility": "Provides ImplementationGoodExamples class implementation"
    },
    "BoolParameterGenerator.Pack.Tests/GeneratedBoolEnums.cs": {
      "classes": [
        "IsValidBinaryEnumThree",
        "IsValidBoolThree",
        "IsValidBinaryEnumFruit",
        "IsValidBoolFruit"
      ],
      "interfaces": [],
      "exports": [
        "IsValidBinaryEnumFruit",
        "IsValidBinaryEnumThree",
        "IsValidBoolFruit",
        "IsValidBoolThree"
      ],
      "dependencies": [
        "PrimS.BoolParameterGenerator"
      ],
      "responsibility": "Contains 4 C# classes: IsValidBinaryEnumThree, IsValidBoolThree, IsValidBinaryEnumFruit"
    },
    "BoolParameterGenerator.Shared/BinaryEnum.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "C# utility module"
    },
    "BoolParameterGenerator.Shared/BinaryEnumWrapper.cs": {
      "classes": [
        "BinaryEnumWrapper"
      ],
      "interfaces": [],
      "exports": [
        "BinaryEnumWrapper"
      ],
      "dependencies": [
        "Ardalis.SmartEnum",
        "System"
      ],
      "responsibility": "Provides BinaryEnumWrapper class implementation"
    },
    "BoolParameterGenerator.Shared/GenerateBinaryEnumAttribute.cs": {
      "classes": [
        "GenerateBinaryEnumAttribute"
      ],
      "interfaces": [],
      "exports": [
        "GenerateBinaryEnumAttribute"
      ],
      "dependencies": [
        "System"
      ],
      "responsibility": "Provides GenerateBinaryEnumAttribute class implementation"
    },
    "BoolParameterGenerator.Shared/GenerateBoolEnumAttribute.cs": {
      "classes": [
        "GenerateBoolEnumAttribute"
      ],
      "interfaces": [],
      "exports": [
        "GenerateBoolEnumAttribute"
      ],
      "dependencies": [
        "System"
      ],
      "responsibility": "Provides GenerateBoolEnumAttribute class implementation"
    },
    "BoolParameterGenerator.Shared/SmartEnumWrapper.cs": {
      "classes": [
        "SmartEnumWrapper"
      ],
      "interfaces": [],
      "exports": [
        "SmartEnumWrapper"
      ],
      "dependencies": [
        "Ardalis.SmartEnum",
        "System"
      ],
      "responsibility": "Provides SmartEnumWrapper class implementation"
    },
    "BoolParameterGenerator/BaseGenerator.cs": {
      "classes": [
        "BaseGenerator"
      ],
      "interfaces": [],
      "exports": [
        "BaseGenerator"
      ],
      "dependencies": [
        "Microsoft.CodeAnalysis",
        "Microsoft.CodeAnalysis.CSharp.Syntax",
        "Microsoft.CodeAnalysis.Text",
        "System",
        "System.Linq",
        "System.Text",
        "System.Threading"
      ],
      "responsibility": "Provides abstract BaseGenerator class implementation"
    },
    "BoolParameterGenerator/BinaryEnumGenerator.cs": {
      "classes": [
        "BinaryEnumGenerator"
      ],
      "interfaces": [],
      "exports": [
        "BinaryEnumGenerator"
      ],
      "dependencies": [
        "FluentAssertions",
        "FluentAssertions.Execution",
        "FluentAssertions.Primitives",
        "Microsoft.CodeAnalysis",
        "PrimS.BoolParameterGenerator",
        "System"
      ],
      "responsibility": "Provides partial static BinaryEnumGenerator class implementation"
    },
    "BoolParameterGenerator/BoolEnumGenerator.cs": {
      "classes": [
        "BoolEnumGenerator"
      ],
      "interfaces": [],
      "exports": [
        "BoolEnumGenerator"
      ],
      "dependencies": [
        "Ardalis.SmartEnum",
        "FluentAssertions",
        "FluentAssertions.Primitives",
        "Microsoft.CodeAnalysis"
      ],
      "responsibility": "Provides partial static BoolEnumGenerator class implementation"
    },
    "BoolParameterGenerator/StringExtensions.cs": {
      "classes": [],
      "interfaces": [],
      "exports": [],
      "dependencies": [],
      "responsibility": "Static utility class with helper methods"
    }
  },
  "languageProfile": {
    "languages": [
      "csharp"
    ],
    "generation_timestamp": "2025-10-19T01:31:41.558098"
  }
}
```
