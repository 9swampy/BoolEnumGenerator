# BoolParameterGenerator

**BoolParameterGenerator** is a Roslyn analyzer and source generator that automatically creates replacement types for boolean parameters in C# code. This improves readability and maintainability by replacing ambiguous `bool` parameters with strongly typed, descriptive alternatives.

---

## ✨ Features

- Replaces `bool` parameters with source-generated binary types.
- Supports generation of:
  - Binary enums
  - Struct-backed bool wrappers
- Seamless integration with IntelliSense and analyzers.
- Minimal configuration required.

---

## 📦 Installation

Install the main analyzer package via NuGet:

```xml
<PackageReference Include="BoolParameterGenerator" Version="1.0.0" />
```

This will **transitively install** the required helper package `BoolParameterGenerator.Shared`.

✅ Works in:
- .NET SDK-style projects
- Class libraries
- Console apps
- Unit test projects

---

## 🚀 Usage

Annotate a `partial class` with one of the supported generator attributes:

```csharp
using PrimS.BoolParameterGenerator;

[GenerateBinaryEnum("TrueValue", "FalseValue")]
public partial class MyBinaryEnum { }

[GenerateBoolEnum("TrueValue", "FalseValue")]
public partial class MyBoolEnum { }
```

🔧 Requirements:
- The class **must** be `partial`.
- The attribute arguments define the **true/false** semantics of the generated type.

---

## 🔍 Where to Find Generated Code

1. Open your project in **Visual Studio**.
2. Navigate to `Dependencies > Analyzers > BoolParameterGenerator`.
3. Expand the node to find the generated `.g.cs` files (e.g., `MyBinaryEnum.g.cs`).

⚠️ If only `Heartbeat.g.cs` appears:
- Ensure your partial class is declared correctly.
- Verify that attribute arguments are valid.
- Rebuild the project to trigger generation.

---

## 📦 About the Shared Package

Although the attributes (`GenerateBinaryEnum`, `GenerateBoolEnum`) are defined in a separate package `BoolParameterGenerator.Shared`, you do **not** need to reference it manually — it is installed transitively.

There isn't much to choose one type attribute over the other atm. Under the hood the implementation is quite different and we expect the BinaryEnum could prove advantageous; especially with respect to extending to a tri-state "boolean". This is a Work-In-Progres and we would be very happy to receive feedback on useCases that may deviate in interesting ways from our own expectations...

---

## 🧪 Confirmed Working Setup

To validate everything is wired correctly:
1. Open only the generator projects and the test project (`Nuget.Tests`).
2. Clean the solution.
3. Rebuild `Nuget.Tests`.
4. If analyzer references (like `PrimS`) appear unresolved, open the file — Visual Studio will resolve them automatically.
5. Rebuild again if necessary to see diagnostics like `BEG004`.

---

## ⚠️ Namespace Caveat

If the triggering class and the generated class are in **different namespaces**, generation may fail silently. Ensure the partial class declaration and the generated file reside in the same namespace, or adjust your generator logic to support custom namespaces.

---

## 📄 License

MIT — essentially use however you like, just don't sue me if it doesn't work out!

---

## 🧵 See Also

- [BoolParameterGenerator GitHub Repo](https://github.com/9swampy/BoolEnumGenerator)
- [Source Generator Cookbook (Roslyn)](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)
