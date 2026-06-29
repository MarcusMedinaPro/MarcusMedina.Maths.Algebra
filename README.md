# MarcusMedina.Maths.Algebra

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/download)
[![Build Status](https://img.shields.io/github/actions/workflow/status/MarcusMedinaPro/NuGet/develop-quality.yml?branch=develop&label=Build)](https://github.com/MarcusMedinaPro/NuGet/actions)
[![Test Coverage](https://img.shields.io/badge/coverage-85%25-brightgreen)](https://github.com/MarcusMedinaPro/NuGet)
[![NuGet](https://img.shields.io/nuget/v/MarcusMedina.Maths.Algebra.svg)](https://www.nuget.org/packages/MarcusMedina.Maths.Algebra/)

**Fluent API for algebraic expressions, symbolic mathematics, and equation manipulation in C#**

Build expression trees, evaluate symbolic math, and export to LaTeX - all with a clean, fluent interface designed for both education and production use.

---

## 🚀 Features

- ✅ **Expression Trees** - Build complex algebraic expressions programmatically
- ✅ **Symbolic Math** - Work with variables and expressions without immediate evaluation
- ✅ **Fluent API** - Chain operations naturally: `Algebra.X.Add(5).Square()`
- ✅ **Variable Substitution** - Replace variables with values or other expressions
- ✅ **Simplification** - Automatic constant folding and identity rule application
- ✅ **LaTeX Export** - Generate publication-ready mathematical notation
- ✅ **Type-Safe** - Full type safety with expression validation
- ✅ **Extensible** - Easy to add custom functions and operators
- 🔜 **Expression Parser** - Parse strings like `"3*(x+2)^2"` (coming soon)
- 🔜 **Symbolic Differentiation** - Automatic derivative calculation (coming soon)
- 🔜 **Matrix Operations** - Fluent matrix algebra (coming soon)

---

## 📦 Installation

```bash
dotnet add package MarcusMedina.Maths.Algebra
```

Or via Package Manager Console:

```powershell
Install-Package MarcusMedina.Maths.Algebra
```

**Requirements:**
- .NET 10.0 or later
- C# 14.0 or later

---

## 🎓 Quick Start

### Basic Usage

```csharp
using MarcusMedina.Maths.Algebra.Builders;
using MarcusMedina.Maths.Algebra.Extensions;

// Create expression: (x + 2)^2 / 3
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

// Evaluate with x = 4
double result = expr.Evaluate("x", 4);  // (4 + 2)^2 / 3 = 12

// Export to LaTeX
string latex = expr.ToLaTeX();  // \frac{(x + 2)^{2}}{3}
```

### Variable Substitution

```csharp
// Work with multiple variables
var expr = Algebra.X.Multiply(2).Add(Algebra.Y);

// Substitute and evaluate
var vars = new Dictionary<string, double> { ["x"] = 3, ["y"] = 5 };
double result = expr.Evaluate(vars);  // 2*3 + 5 = 11
```

---

## 📖 Documentation

- **[Getting Started](./csharp/Manual/GettingStarted.md)** - Installation and setup guide
- **[Manual](./csharp/Manual/README.md)** - Comprehensive documentation
- **[Examples](./csharp/Manual/Examples/)** - Detailed usage examples
- **[API Reference](./csharp/Manual/API.md)** - Complete API documentation

---

## 🔧 Use Cases

This library solves real-world problems in mathematics and education:

1. **[Equation Solver](./usecases/UseCase1.EquationSolver/)** - Programmatically build and solve algebraic equations
2. **[LaTeX Generator](./usecases/UseCase2.LaTeXGenerator/)** - Convert mathematical expressions to publication-ready notation
3. **[Symbolic Calculator](./usecases/UseCase3.SymbolicCalculator/)** - Interactive symbolic mathematics with variable substitution

Each use case includes a working example and demonstrates how to integrate this library.

---

## 💡 Examples

### Creating Complex Expressions

```csharp
// (2x^2 + 3x + 1) / (x - 1)
var numerator = Algebra.X
    .Square()
    .Multiply(2)
    .Add(Algebra.X.Multiply(3))
    .Add(1);

var denominator = Algebra.X.Subtract(1);

var fraction = numerator.Divide(denominator);
var simplified = fraction.Simplify();
```

### Generating Mathematical Notation

```csharp
var expr = Algebra.X
    .Add(5)
    .Multiply(Algebra.X.Subtract(3));

var latex = expr.ToLaTeX();
// Output: (x + 5)(x - 3)

var text = expr.ToString();
// Output: (x + 5) * (x - 3)
```

---

## 🧪 Testing

Run the test suite:

```bash
cd csharp
dotnet test --configuration Release
```

---

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

---

## 🤝 Contributing

Contributions are welcome! Please:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

---

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/MarcusMedinaPro/NuGet/issues)
- **Discussions**: [GitHub Discussions](https://github.com/MarcusMedinaPro/NuGet/discussions)

---

## 📚 Related Projects

- [FluentBuilders.Units.Math](../FluentBuilders.Units.Math/) - Unit-aware mathematical operations
- [FluentBuilders.Maths.Calculus](../FluentBuilders.Maths.Calculus/) - Symbolic calculus (coming soon)
