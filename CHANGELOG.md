# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [0.2.0] - 2025-03-16

### Changed
- **BREAKING**: Updated minimum target framework from .NET 9.0 to .NET 10.0
- **BREAKING**: Updated C# language version from 13.0 to 14.0 (enables latest language features)
- Reorganized project structure with comprehensive manual documentation
- Added three real-world use case examples

### Added
- Comprehensive manual with getting started guide in `csharp/Manual/`
- Multiple detailed examples in `csharp/Manual/Examples/`
- API reference documentation in `csharp/Manual/API.md`
- Test coverage configuration (Cobertura format)
- Three production-ready use case projects:
  - `usecases/UseCase1.EquationSolver/` - Programmatic equation building and solving
  - `usecases/UseCase2.LaTeXGenerator/` - Mathematical expression to LaTeX conversion
  - `usecases/UseCase3.SymbolicCalculator/` - Interactive symbolic mathematics
- Status badges in README (MIT License, .NET version, Build status, Test coverage, NuGet package)
- **Mathematical Functions Extension (MathExtensions.cs)**:
  - Trigonometric: `Sin()`, `Cos()`, `Tan()`, `ArcSin()`, `ArcCos()`, `ArcTan()`
  - Exponential: `Sqrt()`, `Exp()`
  - Logarithmic: `Log()`, `Log10()`
  - Rounding: `Floor()`, `Ceiling()`
  - Other: `AbsoluteValue()`
  - All functions leverage .NET `Math` class for performance
- **Expression Parser (AlgebraParser.cs)**:
  - Parse string expressions: `"2*x^2 + 3*x + 1"`
  - Support for `+`, `-`, `*`, `/`, `^` (power) operators
  - Function calls: `sin(x)`, `sqrt(y)`, `log10(z)`
  - Variable support with arbitrary names
  - Parenthesized grouping with proper operator precedence
  - Full mathematical expression evaluation from strings

### Fixed
- Corrected test project reference path in solution file
- Fixed namespace references in README and examples
- Updated documentation to reflect actual API (removed non-existent `ToMathML()` method)
- Added missing test project configuration in solution file
- Improved project file organization and structure

### Migration Guide

If upgrading from v0.1.x:

```powershell
# Update package
dotnet package update MarcusMedina.Maths.Algebra

# Update your project file (if targeting <.NET 10.0)
# Change: <TargetFramework>net9.0</TargetFramework>
# To:     <TargetFramework>net10.0</TargetFramework>

# Update C# version
# Change: <LangVersion>13.0</LangVersion>
# To:     <LangVersion>14.0</LangVersion>
```

No breaking changes to the public API - only platform version requirements changed.

---

## [0.1.0] - 2024-12-01

### Added
- Initial release of Fluent API for algebraic expressions
- Expression tree building with fluent interface
- Symbolic mathematics support with variable substitution
- LaTeX export capability
- Type-safe expression validation
- Extensible architecture for custom functions and operators
- Comprehensive unit test coverage
- Example projects demonstrating usage:
  - BasicUsage - Simple expression building
  - HowItWorks - Detailed API walkthrough
  - FacebookMathQuiz - Real-world application

### Features
- Build complex algebraic expressions programmatically
- Work with variables and expressions symbolically
- Natural fluent API: `Algebra.X.Add(5).Square()`
- Variable substitution and evaluation
- Automatic simplification with constant folding
- Generate publication-ready LaTeX notation
- Full type safety with expression validation

---

## Future Roadmap

### [0.3.0] - Planned
- Expression parser to build expressions from strings like `"3*(x+2)^2"`
- Symbolic differentiation (automatic derivative calculation)
- Integration support

### [0.4.0] - Planned
- Matrix operations with fluent API
- Advanced simplification rules
- Performance optimizations for large expressions

---

## Notes

- All versions maintain semantic versioning (MAJOR.MINOR.PATCH)
- Breaking changes are documented with migration guides
- Latest version is recommended for all new projects
