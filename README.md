# MarcusMedina.Maths.Algebra

[![NuGet](https://img.shields.io/nuget/v/MarcusMedina.Maths.Algebra.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/MarcusMedina.Maths.Algebra/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MarcusMedina.Maths.Algebra.svg?style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/MarcusMedina.Maths.Algebra/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=csharp&logoColor=white)](#)
[![.NET](https://img.shields.io/badge/.NET-10.0+-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)
[![Open Source](https://raw.githubusercontent.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/main/assets/open-source.svg)](https://opensource.org)
[![Build](https://img.shields.io/github/actions/workflow/status/MarcusMedinaPro/MarcusMedina.Maths.Algebra/release.yml?branch=main&label=Build&style=for-the-badge&logo=github)](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/actions)
[![Signed](https://img.shields.io/badge/Signed-Sigstore-green?style=for-the-badge&logo=linux)](https://docs.sigstore.dev)

**Fluent API for algebraic expressions, symbolic mathematics, and equation manipulation in C#**

Build expression trees, evaluate symbolic math, and export to LaTeX - all with a clean, fluent interface designed for both education and production use.

> In 2016, working as a study supervisor for upper-secondary (gymnasium) students, I had to explain the thinking behind their algebra assignments — or break the problems down into small enough pieces that they'd click. It was more than a little dismaying how much I'd forgotten since my own gymnasium days, and it got me thinking about how you'd actually explain algebra step by step as code. It took until 2022 for that thought to turn into action: I was hunting through an old gymnasium textbook for simple calculation exercises to use in a first C# course, and that's where the idea of algebra-as-code finally clicked.
>
> In this case, I wanted the code itself to read like the explanation I'd give a student out loud, step by step, not just spit out a final answer.

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

- **[Getting Started](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/blob/main/csharp/Manual/GettingStarted.md)** - Installation and setup guide
- **[Manual](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/blob/main/csharp/Manual/README.md)** - Comprehensive documentation
- **[Examples](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/tree/main/csharp/Manual/Examples/)** - Detailed usage examples
- **[API Reference](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/blob/main/csharp/Manual/API.md)** - Complete API documentation

---

## 🔧 Use Cases

This library solves real-world problems in mathematics and education:

1. **[Equation Solver](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/tree/main/usecases/UseCase1.EquationSolver/)** - Programmatically build and solve algebraic equations
2. **[LaTeX Generator](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/tree/main/usecases/UseCase2.LaTeXGenerator/)** - Convert mathematical expressions to publication-ready notation
3. **[Symbolic Calculator](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/tree/main/usecases/UseCase3.SymbolicCalculator/)** - Interactive symbolic mathematics with variable substitution

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

This project is licensed under the **MIT License** - see the [LICENSE](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/blob/main/LICENSE) file for details.

---

## 🔐 Package Integrity

All releases are signed with [cosign](https://docs.sigstore.dev) (Sigstore keyless signing).

To verify a downloaded package:

```bash
cosign verify-blob <package.nupkg> \
  --bundle <package.nupkg.sigstore.json> \
  --certificate-identity-regexp "https://github.com/MarcusMedinaPro/.*/release.yml" \
  --certificate-oidc-issuer https://token.actions.githubusercontent.com
```

The `.sigstore.json` bundle is available in each [GitHub Release](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/releases).

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

- **Issues**: [GitHub Issues](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/issues)
- **Discussions**: [GitHub Discussions](https://github.com/MarcusMedinaPro/MarcusMedina.Maths.Algebra/discussions)

---

## Built with Human + AI Collaboration

This library was written by **Marcus Medina** together with **Claude Code** (Anthropic) — not through "vibe coding" where you just describe and accept, but through genuine collaboration: planning together, reviewing each other's decisions, pushing back when something felt wrong, and iterating until the result felt right.

The goal was always to write code worth reading and code worth using — the kind a student can open, understand, and learn from, and the kind any programmer can drop into real, professional work without wanting to rewrite it from scratch. AI was a partner in that process, not a shortcut around it.

If you're curious about this way of working, the source code and git history are open. Every decision has a reason behind it.

## Made for Curious Minds

This library was built with students in mind — not as a black box to copy and paste, but as a real-world example of how clean, purposeful code is written and shared. At the same time, it's built to be genuinely useful in professional projects too — for any developer who's tired of writing the same code over and over.

Whether you're discovering C# for the first time, need a reliable helper for your school project, want a dependable building block for production work, or are simply trying to fall in love with writing code — you're exactly who this was made for.

The source is open. Read it, fork it, break it, improve it. That's the whole point.

---

## 📚 Related Projects

- [MarcusMedina.Units.Math](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Math) — Unit-aware mathematical operations
- [MarcusMedina.Units.Distance](https://github.com/MarcusMedinaPro/MarcusMedina.Units.Distance) — Distance unit conversions
- [MarcusMedina.Fluent.Data](https://github.com/MarcusMedinaPro/MarcusMedina.Fluent.Data) — CSV, JSON, XML extensions
- [MarcusMedina.Fluent.Data.Sql](https://github.com/MarcusMedinaPro/MarcusMedina.Fluent.Data.Sql) — SQL-style pattern matching
