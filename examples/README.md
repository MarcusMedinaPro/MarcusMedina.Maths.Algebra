# Fluent.Algebra Examples

Example applications demonstrating Fluent.Algebra usage.

## Running Examples

### Basic Usage
```bash
cd examples/BasicUsage
dotnet run
```

## Example Output

```
🧮 Fluent.Algebra - Basic Usage Examples

📌 Example 1: Simple Expression (x + 5)
Expression: (x + 5)
LaTeX: (x + 5)
x=10: 15

📌 Example 2: Quadratic (x + 2)² / 3
Expression: ((x + 2)^2 / 3)
LaTeX: \frac{(x+2)^2}{3}
x=5: 16.333

📌 Example 3: Multiple Variables (2x + 3y - z)
Expression: (((2 * x) + (3 * y)) - z)
LaTeX: (((2 \cdot x) + (3 \cdot y)) - z)
x=4, y=2, z=1: 13

📌 Example 4: Trigonometry (sin²(x) + cos²(x))
Expression: ((sin(x)^2) + (cos(x)^2))
LaTeX: ((\sin(x)^2) + (\cos(x)^2))
x=π/4: 1.000000
x=π/2: 1.000000
```

## Quick Reference

### Creating Expressions

```csharp
using MarcusMedina.Fluent.Algebra.Builders;
using MarcusMedina.Fluent.Algebra.Extensions;

// Constants
var five = Algebra.Constant(5);

// Variables
var x = Algebra.X;              // Predefined x
var y = Algebra.Y;              // Predefined y
var custom = Algebra.Var("alpha");

// Basic operations
var sum = x.Add(5);             // x + 5
var product = x.Multiply(2);    // 2x
var power = x.Power(2);         // x²
var square = x.Square();        // x² (convenience)

// Functions
var sinX = Algebra.Sin(x);
var sqrtX = Algebra.Sqrt(x);
```

### Evaluating Expressions

```csharp
var expr = Algebra.X.Add(5);

// Single variable
var result = expr.Evaluate("x", 10);  // 15

// Multiple variables
var expr2 = Algebra.X.Add(Algebra.Y);
var result2 = expr2.Evaluate(new Dictionary<string, double>
{
    ["x"] = 3,
    ["y"] = 4
});  // 7
```

### Substitution

```csharp
var expr = Algebra.X.Square();

// Substitute with value
var withValue = expr.Substitute("x", 5);  // 25

// Substitute with expression
var withExpr = expr.Substitute("x", Algebra.Y.Add(1));  // (y+1)²
```

### LaTeX Export

```csharp
var expr = Algebra.X.Add(2).Square().Divide(3);
var latex = expr.ToLaTeX();  // \frac{(x+2)^2}{3}
```

### Simplification

```csharp
var expr = Algebra.X.Multiply(1).Add(0);
var simple = expr.Simplify();  // x

var constant = Algebra.Constant(3).Add(4).Multiply(2);
var result = constant.Simplify();  // 14
```

## Common Patterns

### Quadratic Formula
```csharp
var a = Algebra.Var("a");
var b = Algebra.Var("b");
var c = Algebra.Var("c");

var discriminant = b.Square()
    .Subtract(Algebra.Constant(4).Multiply(a).Multiply(c));

var solution = b.Negate()
    .Add(Algebra.Sqrt(discriminant))
    .Divide(Algebra.Constant(2).Multiply(a));
```

### Distance Formula
```csharp
var dx = Algebra.Var("x2").Subtract(Algebra.Var("x1"));
var dy = Algebra.Var("y2").Subtract(Algebra.Var("y1"));
var distance = Algebra.Sqrt(dx.Square().Add(dy.Square()));
```

### Pythagorean Theorem
```csharp
var a = Algebra.Var("a");
var b = Algebra.Var("b");
var c = Algebra.Sqrt(a.Square().Add(b.Square()));
```
