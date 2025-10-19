# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

BoolParameterGenerator is a Roslyn analyzer and source generator that creates strongly-typed replacements for boolean parameters in C# code. The project addresses analyzer rules (SonarAnalyzer S1133, Roslynator RCS1155) that discourage raw `bool` parameters by generating descriptive, type-safe alternatives.

## Codebase Navigation
Key files to understand project structure and functionality:
  - `readme-codebase-map.md`: JSON-formatted structural index of all C# files showing classes,
  interfaces, exports, dependencies, and responsibilities - read this to quickly locate type
  definitions or understand cross-file relationships without searching through source code.

## Architecture

### Two-Package Structure

The project is split into two NuGet packages with an interdependency:

1. **BoolParameterGenerator** (main package)
   - Contains the Roslyn source generators and analyzers
   - Targets `netstandard2.0` for Roslyn compatibility
   - Must be packed **after** BoolParameterGenerator.Shared
   - Includes analyzer DLL in `analyzers/dotnet/cs/` package path

2. **BoolParameterGenerator.Shared** (attribute package)
   - Defines attributes (`GenerateBinaryEnum`, `GenerateBoolEnum`) consumed by user code
   - Must be built and packed **first**
   - Version must match exactly between packages during build (controlled by `ParameterNugetVersion`)

### Generator Implementation

All generators inherit from `BaseGenerator` abstract class:
- `BinaryEnumGenerator`: Generates binary enum types
- `BoolEnumGenerator`: Generates struct-backed bool wrapper types

The `BaseGenerator` class (BoolParameterGenerator/BaseGenerator.cs) implements `IIncrementalGenerator` and provides:
- Attribute detection and candidate class finding
- Namespace resolution (handles file-scoped and block-scoped namespaces)
- Source generation scaffolding
- Diagnostic reporting infrastructure

Abstract methods that concrete generators must implement:
- `GenerateType()`: Core type generation logic
- `GenerateExtensions()`: Optional extension methods
- `GenerateAssertions()`: Optional test assertions (FluentAssertions support planned)

## Build Commands

### Clean Build Sequence

When working with the generator projects, always follow this sequence to avoid stale analyzer issues:

```bash
# Clean everything
dotnet clean BoolParameterGenerator.sln

# Build Shared package first (required dependency)
dotnet build BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj --configuration Release

# Build main generator package
dotnet build BoolParameterGenerator/BoolParameterGenerator.csproj --configuration Release

# Pack to solution .nupkgs (CRITICAL: use explicit --output)
dotnet pack BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj \
  --configuration Release \
  --no-build \
  --output .nupkgs

dotnet pack BoolParameterGenerator/BoolParameterGenerator.csproj \
  --configuration Release \
  --no-build \
  --output .nupkgs

# Build test project (tests generator output)
# NOTE: Test project uses RestoreSources pointing to $(SolutionDir)/.nupkgs
dotnet build BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj --configuration Release
```

**IMPORTANT**: When making changes to generator source code during local development:
1. The test project caches packages in the global NuGet folder (`~/.nuget/packages/`)
2. Even with `--no-cache --force`, NuGet prioritizes cached versions with the same version number
3. **Required steps before building test project**:
   ```bash
   # Clear global NuGet cache
   rm -rf ~/.nuget/packages/boolparametergenerator.shared/1.0.0
   rm -rf ~/.nuget/packages/boolparametergenerator/1.0.0

   # Delete test project build artifacts to force regeneration
   rm -rf BoolParameterGenerator.Pack.Tests/obj
   rm -rf BoolParameterGenerator.Pack.Tests/bin
   ```

**If changes not detected**: Add `--no-incremental` flag to build commands when editing source files.

**Troubleshooting**: See [`.claude/local-development-build-guide.md`](./.claude/local-development-build-guide.md) for detailed explanation of why these steps are necessary and what happens if you skip them.

### Running Tests

```bash
# Run all tests
dotnet test BoolParameterGenerator.sln

# Run specific test project
dotnet test BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj

# Run with coverage (uses coverlet.collector)
dotnet test BoolParameterGenerator.sln --collect:"XPlat Code Coverage"
```

### Packing for NuGet

The build system uses GitVersion for semantic versioning:

```bash
# Local pack with version override
dotnet pack BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj --configuration Release --output ./.nupkgs /p:PackageVersion=1.0.0-local
dotnet pack BoolParameterGenerator/BoolParameterGenerator.csproj --configuration Release --output ./.nupkgs /p:PackageVersion=1.0.0-local

# Packages output to ./.nupkgs directory
```

**Critical:** The `ParameterNugetVersion` property must match between projects during build. CI/CD handles this automatically via GitVersion.

### Testing Generator Changes Locally

After packing, Visual Studio projects configured with `RestoreSources` will consume local `.nupkgs`:

```xml
<PropertyGroup Condition="'$(BuildingInsideVisualStudio)' == 'true'">
  <RestoreSources>$(RestoreSources);$(SolutionDir)/.nupkgs</RestoreSources>
</PropertyGroup>
```

Rebuild test projects to pick up new analyzer versions. If diagnostics don't appear:
1. Open the file in Visual Studio (triggers analyzer loading)
2. Rebuild solution
3. Check `Dependencies > Analyzers > BoolParameterGenerator` for generated files

## Development Setup for Contributing

From README.md section "Confirmed Working Build/Contribution Setup":

1. Checkout latest `master` branch
2. Open only generator projects (`BoolParameterGenerator`, `BoolParameterGenerator.Shared`) and test project (`BoolParameterGenerator.Pack.Tests`)
3. Clean solution
4. Rebuild `BoolParameterGenerator.Pack.Tests`
5. If analyzer references appear unresolved, open a file to trigger Visual Studio resolution
6. Rebuild again if necessary
7. Verify `BEG004` diagnostics appear (confirms analyzer is active)

## Version Control and Branching

Follows GitFlow with GitVersion semantic versioning:

- `master`: Production releases (patch increment)
- `develop`: Integration branch (minor increment)
- `feature/*`: Feature branches (minor increment, source: develop)
- `release`: Release preparation (no increment, source: develop)
- `hotfix/*`: Production fixes (patch increment, source: master)

Commit message version control:
- `+semver: major` or `+semver: breaking`: Major version bump
- `+semver: minor` or `+semver: feature`: Minor version bump
- `+semver: patch` or `+semver: fix`: Patch version bump
- `+semver: none` or `+semver: skip`: No version bump

## CI/CD Pipeline

GitHub Actions workflow (`.github/workflows/nuget-publish.yml`) handles:

1. GitVersion calculation and JSON output parsing
2. Sequential build: Shared → Generator
3. NuGet pack with GitVersion-derived version
4. Publish to GitHub Packages (all branches)
5. Publish to NuGet.org (master only)
6. Git tagging with version (format: `vX.Y.Z`)

**Environment requirements:**
- Secrets: `PUBLISH_TO_GITHUB_PACKAGES`, `NUGET_GITHUBACTIONS`
- .NET SDK 8.0.x
- GitVersion 6.x

## Code Generation Details

### Viewing Generated Code

Generated files appear under `Dependencies > Analyzers > BoolParameterGenerator` in Visual Studio Solution Explorer.

**Troubleshooting:** If only `Heartbeat.g.cs` appears:
- Verify partial class declaration
- Check attribute arguments are valid strings
- Rebuild project to trigger regeneration

### Namespace Caveat

Generated classes must be in the **same namespace** as the triggering partial class. Cross-namespace generation may fail silently. The `GetNamespace()` method in BaseGenerator handles both:
- Block-scoped: `namespace Foo.Bar { }`
- File-scoped: `namespace Foo.Bar;`

## Testing Framework

All test projects use:
- **xUnit** as test framework
- **AwesomeAssertions** for fluent assertion syntax (not standard FluentAssertions)
- **Microsoft.CodeAnalysis** packages for Roslyn testing
- Shared test configuration in `CommonTest.props`

Test project pattern: Projects reference generator package as `PrivateAssets="all"` to test analyzer behavior in isolation.

## Project Properties

### Common Settings (Directory.build.props)

```xml
<EmitCompilerGeneratedFiles>true</EmitCompilerGeneratedFiles>
```

This enables viewing generated source in Solution Explorer.

### Generator-Specific Requirements

- `IsRoslynAnalyzer`: true
- `EnforceExtendedAnalyzerRules`: true
- Target framework: `netstandard2.0` (Roslyn requirement)
- `LangVersion`: Latest
- `ImplicitUsings`: disabled (explicit using statements)
- `Nullable`: enabled
