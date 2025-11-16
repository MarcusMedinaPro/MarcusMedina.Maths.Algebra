# Changelog

All notable changes to MarcusMedina.Fluent.Algebra will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.1.0] - 2025-01-19

### Added
- Initial release of Fluent.Algebra
- Core expression tree architecture:
  - `IAlgebraExpression` interface
  - `ConstantExpression` for numeric constants
  - `VariableExpression` for symbolic variables
  - `BinaryExpression` for binary operations (add, subtract, multiply, divide, power)
  - `UnaryExpression` for unary operations (negate, absolute value)
  - `FunctionExpression` for mathematical functions (sin, cos, sqrt, ln)
- Fluent builder API:
  - `Algebra.Constant()`, `Algebra.Variable()`, `Algebra.Var()`
  - Common variables: `Algebra.X`, `Algebra.Y`, `Algebra.Z`
  - Operation builders: `Algebra.Add()`, `Algebra.Multiply()`, etc.
- Extension methods for fluent chaining:
  - `.Add()`, `.Subtract()`, `.Multiply()`, `.Divide()`, `.Power()`
  - `.Square()` convenience method
  - `.Negate()` for negation
- Expression evaluation:
  - `Evaluate()` with variable substitution
  - `Evaluate(variable, value)` single variable helper
  - `EvaluateRange()` for multiple evaluation points
- Variable substitution:
  - `Substitute(variable, value)` - replace with constant
  - `Substitute(variable, expression)` - replace with expression
- Expression simplification:
  - Constant folding (e.g., `3 + 4` → `7`)
  - Identity rules (e.g., `x * 1` → `x`, `x + 0` → `x`)
  - Zero multiplication (e.g., `x * 0` → `0`)
- Formatting support:
  - `ToString()` for standard mathematical notation
  - `ToLaTeX()` for LaTeX export
- Utility classes:
  - `AlgebraEvaluator` with range evaluation
  - `StringFormatter` and `LaTeXFormatter`
- Placeholder classes for future features:
  - `FluentMatrix` (matrix operations)
  - `AlgebraParser` (string parsing)
- Complete XML documentation for all public APIs
- MIT License
- Comprehensive README with examples and API reference

### Design Decisions
- Immutable expression trees - all operations return new expressions
- Type-safe API with compile-time validation
- Clean separation: expression tree, evaluation, formatting
- Extensible architecture for future operators and functions
- Educational focus with clear, readable code

---

## Future Plans

### Version 0.2.0 (Planned)
- Expression parser implementation
- Operator overloading support
- Additional functions (tan, log, exp, asin, acos, atan)
- More comprehensive simplification rules

### Version 0.3.0 (Planned)
- Symbolic differentiation
- Expression comparison and equality
- Partial derivative support
- Chain rule implementation

### Version 0.4.0 (Planned)
- Matrix operations (add, multiply, transpose)
- Determinant calculation
- Matrix inverse
- Linear algebra utilities

### Version 1.0.0 (Planned)
- Equation solving capabilities
- System of equations solver
- Production-ready stability
- Performance optimizations
- Comprehensive test coverage

---

[Unreleased]: https://github.com/MarcusMedina/Fluent.Algebra/compare/v0.1.0...HEAD
[0.1.0]: https://github.com/MarcusMedina/Fluent.Algebra/releases/tag/v0.1.0
