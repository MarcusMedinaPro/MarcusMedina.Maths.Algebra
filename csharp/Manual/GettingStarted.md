# Getting Started

Get up and running with MarcusMedina.Fluent.Algebra in 5 minutes.

---

## Installation

### Via .NET CLI

```bash
dotnet add package MarcusMedina.Fluent.Maths.Algebra
```

### Via Package Manager Console

```powershell
Install-Package MarcusMedina.Fluent.Maths.Algebra
```

### Via Visual Studio

1. Right-click project → Manage NuGet Packages
2. Search for `MarcusMedina.Fluent.Maths.Algebra`
3. Click Install

**System Requirements:**
- .NET 10.0 or later
- C# 14.0 or later (compiler requirement)

---

## Your First Expression

### Step 1: Add Using Statements

```csharp
using MarcusMedina.Fluent.Algebra;
using MarcusMedina.Fluent.Algebra.Builders;
using MarcusMedina.Fluent.Algebra.Extensions;
```

### Step 2: Create an Expression

```csharp
// Create the expression: x + 5
var expr = Algebra.X.Add(5);
```

### Step 3: Evaluate It

```csharp
// Evaluate with x = 3
double result = expr.Evaluate(x: 3);
Console.WriteLine(result);  // Output: 8
```

**Complete working example:**

```csharp
using MarcusMedina.Fluent.Algebra;
using MarcusMedina.Fluent.Algebra.Builders;

class Program
{
    static void Main()
    {
        // Build: x + 5
        var expr = Algebra.X.Add(5);

        // Evaluate with x = 3
        double result = expr.Evaluate(x: 3);

        Console.WriteLine($"x + 5 where x=3 = {result}");  // Output: 8
    }
}
```

---

## Basic Operations

### Arithmetic Operations

```csharp
var x = Algebra.X;

// Addition
var add = x.Add(5);            // x + 5

// Subtraction
var sub = x.Subtract(3);        // x - 3

// Multiplication
var mul = x.Multiply(2);        // x * 2

// Division
var div = x.Divide(4);          // x / 4

// Power
var power = x.Power(2);         // x^2

// Square and Cube shortcuts
var square = x.Square();        // x^2
var cube = x.Cube();            // x^3
```

### Chaining Operations

Operations can be chained for complex expressions:

```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

// This represents: ((x + 2)^2) / 3

double result = expr.Evaluate(x: 4);
// (4 + 2)^2 / 3 = 36 / 3 = 12
```

---

## Working with Constants

### Using Constants

```csharp
// Create expression: 2x + 3
var expr = Algebra.X.Multiply(2).Add(3);

// Evaluate
var result = expr.Evaluate(x: 5);  // 2*5 + 3 = 13
```

### Constant Expressions

```csharp
// Pure constant expression
var constant = Algebra.Constant(42);
var result = constant.Evaluate();  // 42
```

---

## Multiple Variables

### Using Different Variables

```csharp
var x = Algebra.X;
var y = Algebra.Y;

// Create expression: x + y
var expr = x.Add(y);

// Evaluate with values
double result = expr.Evaluate(x: 3, y: 4);  // 7
```

### Custom Variable Names

```csharp
var a = Algebra.Variable("a");
var b = Algebra.Variable("b");

// Create expression: a^2 + b^2
var expr = a.Square().Add(b.Square());

// Evaluate
double result = expr.Evaluate(a: 3, b: 4);  // 9 + 16 = 25
```

---

## Exporting to LaTeX

### Generate LaTeX Notation

```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

string latex = expr.ToLatex();
Console.WriteLine(latex);

// Output: \frac{(x + 2)^{2}}{3}
```

This LaTeX can be used in documents, papers, or web pages:

```latex
\frac{(x + 2)^{2}}{3}
```

---

## Common Patterns

### Pattern 1: Build → Evaluate

```csharp
var expr = Algebra.X.Multiply(2).Add(5);
double result = expr.Evaluate(x: 10);  // 25
```

### Pattern 2: Build → Export

```csharp
var expr = Algebra.X.Square().Subtract(1);
string latex = expr.ToLatex();  // x^{2} - 1
```

### Pattern 3: Build → Simplify

```csharp
var expr = Algebra.X.Add(0);  // x + 0
var simplified = expr.Simplify();  // x
```

### Pattern 4: Build → Substitute Variables

```csharp
var expr = Algebra.X.Add(Algebra.Y);
var substituted = expr.Substitute("X", Algebra.Constant(5));
double result = substituted.Evaluate(y: 3);  // 8
```

---

## Troubleshooting

### "Cannot resolve symbol 'Algebra'"
- Did you add the using statements? ✓
- Is the NuGet package installed? Check via: `dotnet list package`

### Expression doesn't evaluate correctly
- Check variable names match (case-sensitive)
- Ensure you're passing values for all variables
- Example: `expr.Evaluate(x: 5, y: 3)` not just `expr.Evaluate()`

### NaN or Infinity in results
- Check for division by zero
- Some expressions may have undefined values
- Use try-catch when evaluating untrusted expressions

---

## Next Steps

- **See more examples** → [Examples](./Examples/)
- **Learn advanced features** → [Advanced Topics](./Advanced.md)
- **Complete API reference** → [API Reference](./API.md)
- **Real-world use cases** → See `../usecases/` folder

---

## Quick Reference

```csharp
// Create variable
var x = Algebra.X;

// Operations
x.Add(5)                    // +
x.Subtract(3)               // -
x.Multiply(2)               // *
x.Divide(4)                 // /
x.Power(2)                  // ^
x.Square()                  // ^2
x.Cube()                    // ^3

// Evaluate
expr.Evaluate(x: 5)

// Export
expr.ToLatex()
expr.ToMathML()

// Simplify
expr.Simplify()

// Substitute
expr.Substitute("X", Algebra.Constant(5))
```

---

**Ready to dive deeper?** Check out [Examples](./Examples/) for more practical use cases!
