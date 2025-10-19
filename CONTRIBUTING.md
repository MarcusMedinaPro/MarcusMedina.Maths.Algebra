# Contributing to MarcusMedina.Fluent.Algebra

Thank you for your interest in contributing! This document provides guidelines for contributing to Fluent.Algebra.

---

## 🎯 How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check existing issues. When creating a bug report, include:

- **Description**: Clear description of the bug
- **Steps to Reproduce**: Minimal code sample
- **Expected Behavior**: What should happen
- **Actual Behavior**: What actually happens
- **Environment**: .NET version, OS, etc.

**Example:**

```markdown
**Description**: Expression.Simplify() doesn't handle division by 1

**Steps to Reproduce**:
```csharp
var expr = Algebra.X.Divide(1);
var simplified = expr.Simplify();
Console.WriteLine(simplified); // Still shows (x / 1)
```

**Expected**: Should simplify to `x`
**Actual**: Returns `(x / 1)`
**Environment**: .NET 9.0, Windows 11
```

### Suggesting Enhancements

Enhancement suggestions are welcome! Please include:

- **Use Case**: Why is this enhancement useful?
- **Proposed API**: How should it work?
- **Examples**: Code examples of usage
- **Alternatives**: Other approaches considered

### Pull Requests

1. **Fork the repository**
2. **Create a feature branch**: `git checkout -b feature/amazing-feature`
3. **Make your changes** following code standards below
4. **Add tests** for your changes
5. **Update documentation** (README, XML docs, CHANGELOG)
6. **Commit**: `git commit -m "Add amazing feature"`
7. **Push**: `git push origin feature/amazing-feature`
8. **Open a Pull Request**

---

## 📝 Code Standards

### C# Style Guide

- **Language Version**: C# 13.0
- **Target Framework**: .NET 9.0
- **Nullable References**: Enabled
- **File-scoped Namespaces**: Preferred
- **Primary Constructors**: Use where appropriate

### Naming Conventions

```csharp
// Classes, interfaces, methods - PascalCase
public class ConstantExpression { }
public interface IAlgebraExpression { }
public void Evaluate() { }

// Parameters, local variables - camelCase
public void Substitute(string variableName, double value)
{
    var newExpression = ...;
}

// Private fields - _camelCase
private readonly double _value;

// Constants - PascalCase
public const double Pi = 3.14159;
```

### Code Structure

```csharp
namespace MarcusMedina.Fluent.Algebra.Expressions;

/// <summary>
/// Brief description of what this class does
/// </summary>
public sealed class ConstantExpression : IAlgebraExpression
{
    // 1. Fields
    private readonly double _value;

    // 2. Properties
    public double Value => _value;

    // 3. Constructors
    public ConstantExpression(double value)
    {
        _value = value;
    }

    // 4. Public methods
    public double Evaluate(Dictionary<string, double>? variables = null)
        => _value;

    // 5. Private methods
    private void ValidateValue() { }
}
```

### XML Documentation

All public APIs must have XML documentation:

```csharp
/// <summary>
/// Evaluates the expression with given variable substitutions
/// </summary>
/// <param name="variables">Variable name-value pairs</param>
/// <returns>Numeric result of evaluation</returns>
/// <exception cref="InvalidOperationException">
/// Thrown when a required variable is not defined
/// </exception>
/// <example>
/// <code>
/// var expr = Algebra.X.Add(5);
/// var result = expr.Evaluate("x", 10); // Returns 15
/// </code>
/// </example>
public double Evaluate(Dictionary<string, double>? variables = null)
{
    // Implementation
}
```

---

## 🧪 Testing Standards

### Test Structure

```csharp
namespace Fluent.Algebra.Tests.Expressions;

public class ConstantExpressionTests
{
    [Fact]
    public void Evaluate_WithoutVariables_ReturnsConstantValue()
    {
        // Arrange
        var expr = new ConstantExpression(42);

        // Act
        var result = expr.Evaluate();

        // Assert
        Assert.Equal(42, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(3.14159)]
    public void Evaluate_VariousConstants_ReturnsCorrectValue(double value)
    {
        // Arrange
        var expr = new ConstantExpression(value);

        // Act
        var result = expr.Evaluate();

        // Assert
        Assert.Equal(value, result);
    }
}
```

### Test Coverage

- **Minimum Coverage**: 80% for new code
- **Critical Paths**: 100% coverage for core evaluation logic
- **Test Types**:
  - Unit tests for individual expressions
  - Integration tests for complex expression trees
  - Edge case tests (division by zero, undefined variables, etc.)

### Running Tests

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"

# Run specific test
dotnet test --filter FullyQualifiedName~ConstantExpressionTests
```

---

## 📚 Documentation Standards

### README Updates

When adding new features, update README.md:

1. Add to **Features** section
2. Add usage examples to **API Reference**
3. Add common patterns if applicable
4. Update **Roadmap** if completing planned feature

### CHANGELOG Updates

Follow [Keep a Changelog](https://keepachangelog.com/en/1.0.0/) format:

```markdown
## [Unreleased]

### Added
- New `Tan()` function for tangent calculation

### Changed
- Improved simplification rules for multiplication

### Fixed
- Fixed issue with division by 1 not simplifying

### Deprecated
- `OldMethod()` - use `NewMethod()` instead
```

---

## 🏗️ Architecture Guidelines

### Expression Design

- **Immutability**: All expressions are immutable
- **Type Safety**: Use strong typing, avoid `object` or `dynamic`
- **Single Responsibility**: Each expression type has one purpose
- **Composition**: Build complex expressions from simple ones

### Extension Methods

```csharp
// Good - clear, focused extension
public static IAlgebraExpression Square(this IAlgebraExpression expr)
    => new BinaryExpression(expr, BinaryOperator.Power, new ConstantExpression(2));

// Bad - too complex, side effects
public static void EvaluateAndPrint(this IAlgebraExpression expr, string variable)
{
    Console.WriteLine(expr.Evaluate(variable, 0)); // Side effects!
}
```

### Error Handling

```csharp
// Good - descriptive exceptions
if (variables == null || !variables.ContainsKey(Name))
{
    throw new InvalidOperationException(
        $"Variable '{Name}' is not defined. " +
        $"Provide a value using Evaluate(variableName, value)."
    );
}

// Bad - generic exceptions
if (variables == null)
    throw new Exception("Error"); // Too generic!
```

---

## 🔄 Development Workflow

### Branch Strategy

- **main**: Stable releases only
- **develop**: Integration branch for next release
- **feature/xxx**: New features
- **bugfix/xxx**: Bug fixes
- **docs/xxx**: Documentation updates

### Commit Messages

Follow [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: add symbolic differentiation support
fix: correct simplification of division by 1
docs: update API reference with new functions
test: add edge cases for variable substitution
refactor: improve expression tree traversal
```

### PR Review Process

1. **Automated Checks**: All tests must pass
2. **Code Review**: At least one maintainer approval
3. **Documentation**: README and CHANGELOG updated
4. **No Conflicts**: Rebase on latest develop

---

## 🎓 Learning Resources

### Understanding Expression Trees

- [.NET Expression Trees](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/)
- [Visitor Pattern](https://refactoring.guru/design-patterns/visitor)
- [Interpreter Pattern](https://refactoring.guru/design-patterns/interpreter)

### Computer Algebra Systems

- [SymPy Documentation](https://www.sympy.org/)
- [Wolfram Language Algebra](https://www.wolfram.com/language/elementary-introduction/2nd-ed/algebra/)

---

## 📞 Questions?

- **GitHub Discussions**: General questions and ideas
- **GitHub Issues**: Bugs and feature requests
- **Email**: marcus@marcusmedina.pro (for sensitive matters)

---

**Thank you for contributing to Fluent.Algebra!** 🎉
