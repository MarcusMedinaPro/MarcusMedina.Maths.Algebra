# MarcusMedina.Fluent.Algebra

[![NuGet](https://img.shields.io/nuget/v/MarcusMedina.Fluent.Algebra.svg)](https://www.nuget.org/packages/MarcusMedina.Fluent.Algebra/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/download)

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
dotnet add package MarcusMedina.Fluent.Algebra
```

Or via Package Manager Console:

```powershell
Install-Package MarcusMedina.Fluent.Algebra
```

**Requirements:**
- .NET 9.0 or later
- C# 13.0 or later

---

## 🎓 Quick Start

### Basic Usage

```csharp
using MarcusMedina.Fluent.Algebra.Builders;
using MarcusMedina.Fluent.Algebra.Extensions;

// Create expression: (x + 2)^2 / 3
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

// Evaluate with x = 5
var result = expr.Evaluate("x", 5);  // (5+2)^2 / 3 = 16.333...

// Get string representation
Console.WriteLine(expr.ToString());  // ((x + 2)^2 / 3)

// Export to LaTeX
Console.WriteLine(expr.ToLaTeX());   // \frac{(x+2)^2}{3}
```

### Working with Multiple Variables

```csharp
// Create expression: 2x + 3y - z
var expr = Algebra.Var("x")
    .Multiply(2)
    .Add(Algebra.Var("y").Multiply(3))
    .Subtract(Algebra.Var("z"));

// Evaluate with specific values
var result = expr.Evaluate(new Dictionary<string, double>
{
    ["x"] = 4,
    ["y"] = 2,
    ["z"] = 1
});  // 2*4 + 3*2 - 1 = 13
```

### Variable Substitution

```csharp
// Original: x^2 + 2x + 1
var expr = Algebra.X.Square()
    .Add(Algebra.X.Multiply(2))
    .Add(1);

// Substitute x with 5
var substituted = expr.Substitute("x", 5);
var result = substituted.Evaluate();  // 25 + 10 + 1 = 36

// Substitute x with another expression (y + 1)
var expr2 = expr.Substitute("x", Algebra.Y.Add(1));
// Result: (y+1)^2 + 2(y+1) + 1
```

### Simplification

```csharp
// Expression with identities
var expr = Algebra.X
    .Multiply(1)      // x * 1
    .Add(0)           // + 0
    .Multiply(2);     // * 2

var simplified = expr.Simplify();  // 2x

// Constant folding
var expr2 = Algebra.Constant(3)
    .Add(4)
    .Multiply(2);

var simplified2 = expr2.Simplify();  // 14 (evaluated at compile time)
```

---

## 📚 API Reference

### Builders

```csharp
using MarcusMedina.Fluent.Algebra.Builders;

// Constants
Algebra.Constant(5)              // Numeric constant

// Variables
Algebra.Variable("x")            // Create variable
Algebra.Var("x")                 // Shorthand
Algebra.X                        // Common variable x
Algebra.Y                        // Common variable y
Algebra.Z                        // Common variable z

// Binary operations
Algebra.Add(expr1, expr2)        // Addition
Algebra.Subtract(expr1, expr2)   // Subtraction
Algebra.Multiply(expr1, expr2)   // Multiplication
Algebra.Divide(expr1, expr2)     // Division
Algebra.Power(base, exponent)    // Exponentiation

// Unary operations
Algebra.Negate(expr)             // Negation (-expr)
Algebra.Abs(expr)                // Absolute value

// Functions
Algebra.Sqrt(expr)               // Square root
Algebra.Sin(expr)                // Sine
Algebra.Cos(expr)                // Cosine
Algebra.Ln(expr)                 // Natural logarithm
```

### Extension Methods

All operations available as fluent extensions:

```csharp
using MarcusMedina.Fluent.Algebra.Extensions;

expr.Add(other)                  // expr + other
expr.Add(5)                      // expr + 5
expr.Subtract(other)             // expr - other
expr.Multiply(other)             // expr * other
expr.Divide(other)               // expr / other
expr.Power(2)                    // expr^2
expr.Square()                    // expr^2 (convenience)
expr.Negate()                    // -expr
```

### Expression Operations

```csharp
// Evaluation
expr.Evaluate()                                  // Evaluate constant expression
expr.Evaluate("x", 5)                           // Evaluate with single variable
expr.Evaluate(new Dictionary<string, double>    // Multiple variables
{
    ["x"] = 5,
    ["y"] = 3
});

// Substitution
expr.Substitute("x", 5)                         // Replace variable with constant
expr.Substitute("x", Algebra.Y.Add(1))          // Replace with expression

// Formatting
expr.ToString()                                  // Standard notation
expr.ToLaTeX()                                   // LaTeX format

// Simplification
expr.Simplify()                                  // Apply simplification rules
```

### Evaluator Utilities

```csharp
using MarcusMedina.Fluent.Algebra.Evaluators;

// Evaluate over range
var values = expr.EvaluateRange("x", start: 0, end: 10, steps: 11);
// Returns [f(0), f(1), f(2), ..., f(10)]
```

---

## 🎯 Common Patterns

### Quadratic Formula

```csharp
// a*x^2 + b*x + c
var a = Algebra.Var("a");
var b = Algebra.Var("b");
var c = Algebra.Var("c");
var x = Algebra.X;

var quadratic = a.Multiply(x.Square())
    .Add(b.Multiply(x))
    .Add(c);

// Evaluate with coefficients
var result = quadratic.Evaluate(new Dictionary<string, double>
{
    ["a"] = 1,
    ["b"] = -5,
    ["c"] = 6,
    ["x"] = 2
});  // 1*4 + (-5)*2 + 6 = 0
```

### Distance Formula

```csharp
// sqrt((x2-x1)^2 + (y2-y1)^2)
var distance = Algebra.Var("x2")
    .Subtract(Algebra.Var("x1"))
    .Square()
    .Add(
        Algebra.Var("y2")
            .Subtract(Algebra.Var("y1"))
            .Square()
    );

var distanceFormula = Algebra.Sqrt(distance);

Console.WriteLine(distanceFormula.ToLaTeX());
// \sqrt{(x2 - x1)^2 + (y2 - y1)^2}
```

### Trigonometric Identity

```csharp
// sin^2(x) + cos^2(x) = 1
var sin = Algebra.Sin(Algebra.X);
var cos = Algebra.Cos(Algebra.X);

var identity = sin.Square().Add(cos.Square());

// Evaluate at x = π/4
var result = identity.Evaluate("x", Math.PI / 4);
// Should be ~1.0
```

---

## 🧪 Educational Use

Perfect for teaching and learning:

```csharp
// Show students the quadratic formula
var discriminant = Algebra.Var("b").Square()
    .Subtract(
        Algebra.Constant(4)
            .Multiply(Algebra.Var("a"))
            .Multiply(Algebra.Var("c"))
    );

var quadraticSolution = Algebra.Var("b")
    .Negate()
    .Add(Algebra.Sqrt(discriminant))
    .Divide(
        Algebra.Constant(2).Multiply(Algebra.Var("a"))
    );

// Export for presentation
Console.WriteLine(quadraticSolution.ToLaTeX());
// \frac{-b + \sqrt{b^2 - 4ac}}{2a}
```

---

## 🏗️ Architecture

### Expression Tree Pattern

All expressions implement `IAlgebraExpression`:

```
IAlgebraExpression
├── ConstantExpression     (5, 3.14)
├── VariableExpression     (x, y, z)
├── BinaryExpression       (a + b, a * b)
├── UnaryExpression        (-a, |a|)
└── FunctionExpression     (sin(x), sqrt(x))
```

### Immutability

All operations return new expressions - original expressions are never modified:

```csharp
var x = Algebra.X;
var expr1 = x.Add(5);        // x + 5
var expr2 = x.Multiply(2);   // 2x
// x is unchanged
```

---

## 🔜 Roadmap

### Version 0.2.0
- [ ] Expression parser: `Algebra.Parse("3*x^2 + 2*x + 1")`
- [ ] Operator overloading: `var expr = x + 5;`
- [ ] More functions: tan, log, exp, etc.

### Version 0.3.0
- [ ] Symbolic differentiation
- [ ] Expression comparison and equality
- [ ] Advanced simplification rules

### Version 0.4.0
- [ ] Matrix operations
- [ ] Determinants and inverses
- [ ] Linear algebra support

### Version 1.0.0
- [ ] Equation solving
- [ ] System of equations
- [ ] Production-ready stability

---

## 🤝 Contributing

Contributions welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

**Areas needing help:**
- Expression parser implementation
- Symbolic differentiation
- More simplification rules
- Performance optimization
- Documentation improvements

---

## 📄 License

MIT License - Copyright © Marcus Medina 2019-2025

See [LICENSE](LICENSE) for details.

---

## 🙏 Acknowledgments

Built with ❤️ by Marcus Medina

Inspired by:
- SymPy (Python symbolic mathematics)
- Wolfram Mathematica
- Computer algebra systems (CAS) research

---

## 📞 Support

- **Issues**: [GitHub Issues](https://github.com/MarcusMedina/Fluent.Algebra/issues)
- **Discussions**: [GitHub Discussions](https://github.com/MarcusMedina/Fluent.Algebra/discussions)
- **Documentation**: [Wiki](https://github.com/MarcusMedina/Fluent.Algebra/wiki)

---

**Made with 💙 for the .NET community**

---
_For metadata and SEO keywords, see [SEO.md](SEO.md)._
