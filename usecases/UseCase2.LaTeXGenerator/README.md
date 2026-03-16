# Use Case 2: LaTeX Generator

**Problem Solved:** Convert algebraic expressions to publication-ready LaTeX notation

This example demonstrates how to use MarcusMedina.Fluent.Algebra to generate LaTeX from programmatically built expressions, enabling integration with academic papers, documentation, and mathematical typesetting.

---

## The Problem

You need to:
- Generate LaTeX from algebraic expressions
- Create mathematical notation for papers/documentation
- Avoid manual LaTeX syntax errors
- Maintain consistency across many equations
- Build dynamic mathematical content

---

## The Solution

```csharp
// Build expression programmatically
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

// Convert to LaTeX automatically
string latex = expr.ToLatex();
// Output: \frac{(x + 2)^{2}}{3}

// Use in document
Console.WriteLine($"$$" + latex + "$$");
```

---

## How to Run

```bash
cd usecases/UseCase2.LaTeXGenerator
dotnet run
```

**Expected Output:**
```
=== LaTeX Generator for Mathematical Expressions ===

Example 1: Simple Linear Expression
Expression: 2x + 3
LaTeX:      2x + 3

Example 2: Quadratic Expression
Expression: 2x² + 5x - 3
LaTeX:      2x^{2} + 5x - 3

Example 3: Complex Fraction
Expression: (x + 2)² / (x - 1)
LaTeX:      \frac{(x + 2)^{2}}{x - 1}

Example 4: Multiple Variables
Expression: x² + y²
LaTeX:      x^{2} + y^{2}

Example 5: Nested Operations
Expression: (x + 1)(x - 1)
LaTeX:      (x + 1)(x - 1)

Example 6: LaTeX Document Snippet
\documentclass{article}
\usepackage{amsmath}
\begin{document}
...
```

---

## Key Features Demonstrated

✅ **LaTeX Generation** - Convert expressions to \LaTeX format
✅ **Complex Expressions** - Handle fractions, powers, nested operations
✅ **Multiple Variables** - Support x, y, z and custom variables
✅ **Document Integration** - Generate ready-to-use document snippets
✅ **Automatic Formatting** - No manual LaTeX syntax needed

---

## Real-World Applications

- **Academic Papers** - Generate equations for research publications
- **Mathematics Textbooks** - Create dynamic problem sets
- **Online Math Tools** - Display equations on web pages
- **Educational Platforms** - Generate problem visualizations
- **Technical Documentation** - Include equations in guides
- **Scientific Computing** - Export results as LaTeX

---

## How It Works

1. **Build Expression** - Use fluent API to construct equation
2. **Generate LaTeX** - Call `.ToLatex()` method
3. **Use in Document** - Insert into LaTeX document with `$...$` or `$$...$$`
4. **Render** - LaTeX compiler renders beautiful mathematics

---

## LaTeX Output Examples

| Expression | LaTeX Output | Renders As |
|-----------|-------------|-----------|
| `x + 5` | `x + 5` | x + 5 |
| `x²` | `x^{2}` | x² |
| `(x+2)/3` | `\frac{x + 2}{3}` | (x+2)/3 |
| `x² + y²` | `x^{2} + y^{2}` | x² + y² |

---

## Integration with LaTeX Document

### Inline Math
```latex
The expression is $\frac{(x + 2)^{2}}{3}$ in our document.
```

### Display Math
```latex
\[
\frac{(x + 2)^{2}}{3}
\]
```

### Using amsmath Package
```latex
\begin{align*}
f(x) &= x^{2} + 2x + 1 \\
     &= (x + 1)^{2}
\end{align*}
```

---

## Extending This Example

**Generate problem sets dynamically:**
```csharp
var random = new Random();
for (int i = 0; i < 10; i++)
{
    var a = random.Next(1, 10);
    var b = random.Next(1, 10);
    var expr = Algebra.X.Multiply(a).Add(b);
    Console.WriteLine($"Solve: {expr.ToLatex()} = 0");
}
```

**Create educational flashcards:**
```csharp
var problems = new[]
{
    (expr: Algebra.X.Square().Subtract(4), answer: "2 or -2"),
    (expr: Algebra.X.Multiply(3).Add(5), answer: "-5/3"),
};

foreach (var (expr, answer) in problems)
{
    Console.WriteLine($"Question: Solve {expr.ToLatex()} = 0");
    Console.WriteLine($"Answer: {answer}\n");
}
```

**Build polynomial visualization tool:**
```csharp
var expr = Algebra.X.Square().Add(Algebra.X).Subtract(6);
var latex = expr.ToLatex();

// Use with Desmos, GeoGebra, or similar
Console.WriteLine($"Graph: https://www.desmos.com/calculator");
Console.WriteLine($"Equation: {latex}");
```

---

## See Also

- [Manual: Getting Started](../../csharp/Manual/GettingStarted.md)
- [API Reference: ToLatex()](../../csharp/Manual/API.md)
- [Use Case 1: Equation Solver](../UseCase1.EquationSolver/)
- [Use Case 3: Symbolic Calculator](../UseCase3.SymbolicCalculator/)

---

## LaTeX Resources

- [LaTeX Project](https://www.latex-project.org/)
- [Overleaf Online Editor](https://www.overleaf.com/)
- [MathJax (web rendering)](https://www.mathjax.org/)
- [KaTeX (fast web rendering)](https://katex.org/)
