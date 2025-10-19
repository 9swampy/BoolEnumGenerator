# Local Development Build Guide

## Purpose

This document explains build process challenges when developing Roslyn source generators locally and provides the correct workflow. Created during implementation of the `GenerateAssertionExtensions` feature when standard build commands failed.

---

## TL;DR - Correct Local Build Process

```bash
# 1. Clean
dotnet clean BoolParameterGenerator.sln

# 2. Build projects in order
dotnet build BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj --configuration Release
dotnet build BoolParameterGenerator/BoolParameterGenerator.csproj --configuration Release

# 3. Pack with EXPLICIT --output (critical!)
dotnet pack BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj \
  --configuration Release --no-build --output .nupkgs

dotnet pack BoolParameterGenerator/BoolParameterGenerator.csproj \
  --configuration Release --no-build --output .nupkgs

# 4. Clear global NuGet cache (REQUIRED for local dev)
rm -rf ~/.nuget/packages/boolparametergenerator.shared/1.0.0
rm -rf ~/.nuget/packages/boolparametergenerator/1.0.0

# 5. Delete test project build artifacts to force regeneration
rm -rf BoolParameterGenerator.Pack.Tests/obj
rm -rf BoolParameterGenerator.Pack.Tests/bin

# 6. Build and test
dotnet build BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj --configuration Release
dotnet test BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj --configuration Release --no-build
```

---

## Why These Steps Are Necessary

### Problem 1: `$(SolutionDir)` Unreliability

**Issue**: Both projects have `<PackageOutputPath>$(SolutionDir).nupkgs</PackageOutputPath>` but this doesn't work for project-level builds.

**Root Cause**:
- `$(SolutionDir)` is only defined when building from a `.sln` file
- Running `dotnet pack ProjectName.csproj` has **no SolutionDir property**
- Results in unpredictable output paths (project folders, filesystem root, etc.)

**Why CI/CD Doesn't Have This Problem**:
The GitHub Actions workflow uses explicit `--output ./.nupkgs` instead of relying on MSBuild properties.

**Local Dev Solution**:
Always use `--output .nupkgs` when packing individual projects.

**No Configuration Change Needed**:
The `<PackageOutputPath>$(SolutionDir).nupkgs</PackageOutputPath>` setting is fine for Visual Studio builds and solution-level builds. Just override it on the command line.

---

### Problem 2: NuGet Global Cache Persistence

**Issue**: Test project continued using stale cached packages despite rebuild.

**Symptoms**:
- Build errors: `The type or namespace name 'GenerateAssertionExtensions' could not be found`
- Changes to attribute classes not recognized
- Using `--no-cache --force` didn't help

**Root Cause**:
- NuGet restore prioritizes global cache (`~/.nuget/packages/`) over local sources when version numbers match
- `--no-cache` prevents **writing** new cache entries but doesn't **clear** existing ones
- `RestoreSources` configuration pointing to `.nupkgs` folder isn't sufficient

**Why CI/CD Doesn't Have This Problem**:
- Clean runner environment (no global cache pollution)
- GitVersion provides unique version for every build
- No version conflicts

**Local Dev Solution**:
Manually delete global cache before building test project:
```bash
rm -rf ~/.nuget/packages/boolparametergenerator.shared/1.0.0
rm -rf ~/.nuget/packages/boolparametergenerator/1.0.0
```

**Alternative for Future**:
Use versioned dev builds:
```bash
dotnet pack --configuration Release --output .nupkgs \
  /p:PackageVersion=1.0.0-dev$(date +%Y%m%d%H%M%S)
```
Then update test project to use floating version: `<PackageReference Include="BoolParameterGenerator" Version="1.0.0-*" />`

---

### Problem 3: Incremental Build Not Detecting Changes

**Issue**: After editing source files, `dotnet build` showed "Build succeeded" but DLL timestamps didn't change.

**Evidence**:
DLL modified at 02:05, rebuild at 02:12, DLL still shows 02:05 timestamp.

**Root Cause**:
MSBuild incremental build optimization didn't detect source changes (potentially due to generator/analyzer project complexity).

**Local Dev Solution**:
Use `--no-incremental` flag when source has changed:
```bash
dotnet build BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj \
  --configuration Release --no-incremental
```

**Why CI/CD Doesn't Have This Problem**:
Clean build environment every time.

---

## Step-by-Step: What I Had to Do

During implementation of `GenerateAssertionExtensions`, here's the actual troubleshooting sequence:

1. ✅ Modified attribute classes to add `GenerateAssertionExtensions` property
2. ✅ Modified `BaseGenerator.cs` to read property and conditionally generate files
3. ❌ Ran `dotnet build BoolParameterGenerator.Shared/...` → Succeeded but didn't actually rebuild DLL
4. ❌ Ran `dotnet build BoolParameterGenerator.Pack.Tests/...` → Error: `GenerateAssertionExtensions` not found
5. 🔍 Checked DLL timestamp → Still old version
6. ✅ Added `--no-incremental` → DLL actually rebuilt
7. ❌ Test project still erroring with same message
8. 🔍 Found packages in project-specific `.nupkgs` folders, not solution `.nupkgs`
9. ✅ Ran `dotnet pack` with explicit `--output .nupkgs`
10. ❌ Test project still erroring
11. 🔍 Discovered test project using global NuGet cache at `~/.nuget/packages/`
12. ❌ Tried `dotnet restore --no-cache --force` → Didn't clear existing cache
13. ✅ Manually deleted global cache folders
14. ✅ Deleted test project obj/bin folders
15. ✅ **Finally worked!**

---

## Quick Reference: Why Each Step Matters

| Step | Why Necessary | What Happens If Skipped |
|------|--------------|-------------------------|
| Clean solution | Remove stale build artifacts | May use old DLLs/packages |
| Build in order (Shared → Generator) | Generator depends on Shared | Build failure or version mismatch |
| Pack with `--output .nupkgs` | `$(SolutionDir)` undefined for project builds | Packages end up in wrong location |
| Clear global NuGet cache | Cache takes priority over local sources | Test project uses old package version |
| Delete test obj/bin | Force source regeneration | Generated files remain from old generator |
| Restore before build | Pull latest local packages | Uses cached/stale packages |

---

## For Future: Scripted Build

Consider creating `build-local.ps1` or `build-local.sh`:

```bash
#!/bin/bash
set -e

echo "=== Cleaning ==="
dotnet clean BoolParameterGenerator.sln

echo "=== Building Shared ==="
dotnet build BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj \
  --configuration Release --no-incremental

echo "=== Building Generator ==="
dotnet build BoolParameterGenerator/BoolParameterGenerator.csproj \
  --configuration Release

echo "=== Packing to .nupkgs ==="
dotnet pack BoolParameterGenerator.Shared/BoolParameterGenerator.Shared.csproj \
  --configuration Release --no-build --output .nupkgs
dotnet pack BoolParameterGenerator/BoolParameterGenerator.csproj \
  --configuration Release --no-build --output .nupkgs

echo "=== Clearing global NuGet cache ==="
rm -rf ~/.nuget/packages/boolparametergenerator.shared/1.0.0
rm -rf ~/.nuget/packages/boolparametergenerator/1.0.0

echo "=== Cleaning test project ==="
rm -rf BoolParameterGenerator.Pack.Tests/obj
rm -rf BoolParameterGenerator.Pack.Tests/bin

echo "=== Building and testing ==="
dotnet build BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj \
  --configuration Release
dotnet test BoolParameterGenerator.Pack.Tests/BoolParameterGenerator.Pack.Tests.csproj \
  --configuration Release --no-build

echo "=== ✅ Build and test complete ==="
```

---

## Comparison: Local vs CI/CD

| Aspect | Local Development | CI/CD (GitHub Actions) |
|--------|------------------|------------------------|
| **Environment** | Persistent, cached | Clean slate every run |
| **NuGet cache** | Global folder polluted | No cache pollution |
| **SolutionDir** | Undefined for project builds | Explicit `--output` parameter |
| **Versioning** | Same version (1.0.0) | Unique GitVersion per build |
| **Build artifacts** | Accumulate across builds | Deleted between runs |
| **Why it works** | Manual cache clearing needed | Automatically clean |

This explains why CI/CD "just works" while local development requires these extra steps.
