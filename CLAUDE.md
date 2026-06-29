# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**MarcusMedina.Maths.Algebra** - A C# NuGet package providing a fluent API for building algebraic expressions, symbolic mathematics, and equation manipulation.

- **Language:** C# 14.0
- **Framework:** .NET 10.0+
- **Pattern:** Fluent Builder API
- **License:** MIT

## Quick Commands

### Development
```bash
# Restore and build
cd csharp
dotnet restore
dotnet build --configuration Release

# Run tests
dotnet test --configuration Release

# Pack NuGet package
dotnet pack src/MarcusMedina.Maths.Algebra/MarcusMedina.Maths.Algebra.csproj --configuration Release

# Run single test
dotnet test --filter ClassName.MethodName
```

### Release & Publishing
```bash
# Create version tag (triggers GitHub Actions)
git tag -a v0.2.0 -m "Release v0.2.0"
git push origin v0.2.0

# The multi-stage GitHub Actions pipeline will:
# 1. Build and test
# 2. Run CodeQL security analysis
# 3. Sign packages with certificate
# 4. Publish to NuGet.org
```

## Architecture

### Core Components

**Expression System** (`Expressions/`)
- `IAlgebraExpression` - Core interface for all expressions
- `VariableExpression` - Represents variables (x, y, z)
- `ConstantExpression` - Represents numeric constants
- `BinaryExpression` - Binary operations (+, -, *, /, ^)
- `FunctionExpression` - Mathematical functions (sin, cos, sqrt, etc.)

**Builders** (`Builders/`)
- `AlgebraBuilder` - Main fluent builder for expressions
- Provides chainable methods: `.Add()`, `.Multiply()`, `.Square()`, `.Sin()`, etc.

**Extensions** (`Extensions/`)
- `MathExtensions` - Extension methods for math functions on expressions
- `AlgebraEvaluator` - Single-variable evaluation extension
- `AlgebraFormatter` - LaTeX and string formatting extensions

**Parser** (`Parsers/`)
- `AlgebraParser` - Recursive descent expression parser
- Parses strings like `"2*x^2 + 3*x + 1"` into expression trees
- Handles operator precedence and function calls

### Key Patterns

**Fluent Interface:**
```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);
```

**Variable Substitution:**
```csharp
var expr = Algebra.X.Multiply(2).Add(Algebra.Y);
double result = expr.Evaluate(new Dictionary<string, double> { ["x"] = 3, ["y"] = 5 });
```

**Expression Parsing:**
```csharp
var expr = AlgebraParser.Parse("sin(x) + sqrt(y)");
```

### File Structure
```
csharp/
├── src/MarcusMedina.Maths.Algebra/
│   ├── Builders/              # Fluent builder implementation
│   ├── Expressions/           # Core expression classes
│   ├── Extensions/            # Extension methods
│   ├── Interfaces/            # IAlgebraExpression contract
│   ├── Parsers/               # String expression parser
│   └── GlobalUsings.cs        # Global namespace imports
└── tests/MarcusMedina.Maths.Algebra.Tests/
    └── *Tests.cs              # xUnit test suite
```

## Testing Strategy

- **Framework:** xUnit with FluentAssertions
- **Coverage:** 85%+ target
- **Approach:** Comprehensive unit tests for all expression types and operations
- Tests verify:
  - Expression evaluation correctness
  - LaTeX formatting output
  - Variable substitution
  - Parser functionality and edge cases
  - Simplification rules

## GitHub Actions Workflow

**Release Pipeline** (`.github/workflows/release.yml`)

Triggers on: `git push` with `v*` tags or to `main`/`release` branches

4-stage pipeline:
1. **Build & Test** - Restore, build, test, pack (produces unsigned packages)
2. **Quality Gate** - CodeQL analysis, vulnerability scanning
3. **Package Signing** - Sign packages, verify signatures, generate SHA256 checksums
4. **Publish to NuGet** - Only runs on version tags (refs/tags/v*)

**Required Secrets:**
- `NUGET_API_KEY` - NuGet.org API key
- `NUGET_SIGNING_CERT` - Base64-encoded signing certificate (.pfx)
- `NUGET_SIGNING_CERT_PASSWORD` - Certificate password

## Important Implementation Details

### Mathematical Functions

All math functions use .NET's `Math` class internally:
- **Trigonometric:** Sin, Cos, Tan, ArcSin, ArcCos, ArcTan
- **Roots/Exponential:** Sqrt, Exp
- **Logarithmic:** Log (natural), Log10
- **Rounding:** Floor, Ceiling
- **Other:** AbsoluteValue

Functions are wrapped in `FunctionExpression` which stores the function name and argument, then delegates evaluation to the .NET Math class.

### Expression Parser

Recursive descent parser with proper operator precedence:
1. Unary operators (-, +)
2. Power operator (^) - right-associative
3. Multiplication/Division (*, /)
4. Addition/Subtraction (+, -)
5. Function calls (sin, cos, sqrt, etc.)

Parser supports:
- Variables with arbitrary names
- Numeric literals (integers and decimals)
- Parenthesized expressions
- Nested function calls

### NuGet Package Configuration

Key settings in `.csproj`:
- **Version:** Bumped via git tags in CI
- **Package ID:** `MarcusMedina.Maths.Algebra`
- **Description:** Fluent API for algebraic expressions
- **License:** MIT (requires LICENSE file in root)
- **Repository:** GitHub repository URL
- **Project URL:** Links to documentation

## Documentation

- **README.md** - Quick start, features, installation
- **CHANGELOG.md** - Version history with breaking changes
- **Manual/** - Comprehensive user guide and examples
- **LICENSE** - MIT License file (required for NuGet)

## Common Issues & Solutions

**Build Fails on Test Project:**
- Verify path in test .csproj: `../../src/MarcusMedina.Maths.Algebra/MarcusMedina.Maths.Algebra.csproj`

**Parser Not Working:**
- Ensure `AlgebraParser` is in global usings
- Functions are case-insensitive

**LaTeX Output Issues:**
- Special characters are escaped with backslashes
- Fractions use `\frac{numerator}{denominator}`
- Powers use `^{exponent}` notation

**GitHub Actions Workflow Fails:**
- Check that `csharp/` folder structure matches workflow paths
- Verify secrets are configured in repository settings
- Ensure .NET 10.0.x is available in ubuntu-latest

## Semantic Versioning

Version format: `MAJOR.MINOR.PATCH`

- **MAJOR** - Breaking changes to API
- **MINOR** - New features, backwards compatible
- **PATCH** - Bug fixes, no API changes

Breaking changes are documented in CHANGELOG with migration guides.
