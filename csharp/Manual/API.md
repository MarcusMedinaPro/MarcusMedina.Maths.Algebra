# API Reference

Complete reference for the MarcusMedina.Fluent.Algebra API.

---

## Core Classes

### Algebra (Static Builder)

Main entry point for building expressions.

```csharp
public static class Algebra
{
    // Variable shortcuts
    public static IExpression X { get; }
    public static IExpression Y { get; }
    public static IExpression Z { get; }

    // Factory methods
    public static IExpression Variable(string name);
    public static IExpression Constant(double value);
}
```

**Usage:**
```csharp
var x = Algebra.X;                      // Variable X
var custom = Algebra.Variable("t");     // Custom variable
var constant = Algebra.Constant(5);     // Numeric constant
```

---

### IExpression Interface

Main interface for all expressions.

```csharp
public interface IExpression
{
    // Evaluation
    double Evaluate(Dictionary<string, double> variables);
    double Evaluate(params (string name, double value)[] variables);

    // Operations
    IExpression Add(IExpression other);
    IExpression Add(double value);
    IExpression Subtract(IExpression other);
    IExpression Subtract(double value);
    IExpression Multiply(IExpression other);
    IExpression Multiply(double value);
    IExpression Divide(IExpression other);
    IExpression Divide(double value);
    IExpression Power(double exponent);
    IExpression Power(IExpression exponent);

    // Shortcuts
    IExpression Square();
    IExpression Cube();
    IExpression Negate();

    // Export
    string ToLatex();
    string ToMathML();
    string ToString();

    // Transformation
    IExpression Simplify();
    IExpression Substitute(string variableName, IExpression replacement);

    // Analysis
    ISet<string> GetVariables();
    bool IsConstant { get; }
}
```

---

## Arithmetic Operations

### Addition

```csharp
// Add another expression
var expr1 = Algebra.X.Add(Algebra.Y);  // x + y

// Add constant
var expr2 = Algebra.X.Add(5);          // x + 5
```

### Subtraction

```csharp
var expr1 = Algebra.X.Subtract(Algebra.Y);  // x - y
var expr2 = Algebra.X.Subtract(3);          // x - 3
```

### Multiplication

```csharp
var expr1 = Algebra.X.Multiply(Algebra.Y);  // x * y
var expr2 = Algebra.X.Multiply(2);          // x * 2
```

### Division

```csharp
var expr1 = Algebra.X.Divide(Algebra.Y);    // x / y
var expr2 = Algebra.X.Divide(4);            // x / 4
```

### Power

```csharp
var expr1 = Algebra.X.Power(2);             // x^2
var expr2 = Algebra.X.Power(3.5);           // x^3.5
var expr3 = Algebra.X.Power(Algebra.Y);     // x^y
```

### Shortcuts

```csharp
Algebra.X.Square();         // x^2
Algebra.X.Cube();           // x^3
Algebra.X.Negate();         // -x
```

---

## Evaluation

### Basic Evaluation

```csharp
// Single variable
var expr = Algebra.X.Add(5);
double result = expr.Evaluate(x: 10);  // 15

// Multiple variables
var expr = Algebra.X.Add(Algebra.Y);
double result = expr.Evaluate(x: 3, y: 4);  // 7
```

### Using Dictionary

```csharp
var expr = Algebra.X.Add(Algebra.Y);
var vars = new Dictionary<string, double>
{
    { "X", 3 },
    { "Y", 4 }
};
double result = expr.Evaluate(vars);  // 7
```

---

## Export Formats

### LaTeX

```csharp
var expr = Algebra.X.Square().Add(1);
string latex = expr.ToLatex();
// Output: x^{2} + 1
```

**Use cases:**
- Academic papers
- Documentation
- Mathematical typesetting

### MathML

```csharp
var expr = Algebra.X.Add(5);
string mathml = expr.ToMathML();
// Output: <math>...</math>
```

**Use cases:**
- Web pages
- Accessibility
- XML-based formats

---

## Simplification

### Auto Simplify

```csharp
// Remove identity operations
var expr = Algebra.X.Add(0);
var simplified = expr.Simplify();  // Returns just: x

// Constant folding
var expr = Algebra.Constant(2).Add(3);
var simplified = expr.Simplify();  // Returns: 5
```

### Supported Simplifications

- x + 0 → x
- x - 0 → x
- x * 0 → 0
- x * 1 → x
- x / 1 → x
- 0 / x → 0
- Constant folding (2 + 3 → 5)

---

## Variable Substitution

### Substitute Variables

```csharp
var expr = Algebra.X.Add(Algebra.Y);
var subst = expr.Substitute("X", Algebra.Constant(5));
// Now: 5 + y

double result = subst.Evaluate(y: 3);  // 8
```

### Chain Substitutions

```csharp
var expr = Algebra.X.Add(Algebra.Y).Add(Algebra.Z);

var step1 = expr.Substitute("X", Algebra.Constant(2));   // 2 + y + z
var step2 = step1.Substitute("Y", Algebra.Constant(3));  // 2 + 3 + z
var step3 = step2.Substitute("Z", Algebra.Constant(4));  // 2 + 3 + 4

double result = step3.Evaluate();  // 9
```

---

## Analysis

### Get Variables

```csharp
var expr = Algebra.X.Add(Algebra.Y).Multiply(Algebra.Z);
var vars = expr.GetVariables();
// Returns: { "X", "Y", "Z" }
```

### Check if Constant

```csharp
var expr1 = Algebra.Constant(5);
bool isConst = expr1.IsConstant;  // true

var expr2 = Algebra.X.Add(5);
bool isConst = expr2.IsConstant;  // false
```

---

## Extension Methods

### Fluent Builders

All arithmetic operations are extension methods on `IExpression`:

```csharp
public static class ExpressionExtensions
{
    public static IExpression Add(this IExpression expr, IExpression other);
    public static IExpression Subtract(this IExpression expr, IExpression other);
    public static IExpression Multiply(this IExpression expr, IExpression other);
    public static IExpression Divide(this IExpression expr, IExpression other);
    public static IExpression Power(this IExpression expr, double exponent);
    public static IExpression Square(this IExpression expr);
    public static IExpression Cube(this IExpression expr);
    public static IExpression Negate(this IExpression expr);
    // ... and more
}
```

---

## Common Return Types

### Evaluation Results

- **Single operation:** Returns `double`
- **Failed evaluation:** Throws `EvaluationException`
- **Undefined (div by 0):** Returns `double.NaN` or throws

### Expression Results

- **All operations:** Return `IExpression`
- **Immutable:** Original expression unchanged
- **Chainable:** Results can be further modified

---

## Error Handling

### EvaluationException

```csharp
try
{
    var expr = Algebra.X.Divide(Algebra.X.Subtract(Algebra.X));  // x / (x - x)
    double result = expr.Evaluate(x: 5);  // Division by zero!
}
catch (EvaluationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

### Division by Zero

```csharp
// Returns NaN (not all cases throw)
var expr = Algebra.X.Divide(0);
double result = expr.Evaluate(x: 5);  // NaN
```

---

## Namespaces

```csharp
// Main API
using MarcusMedina.Fluent.Algebra;

// Builder classes
using MarcusMedina.Fluent.Algebra.Builders;

// Extension methods
using MarcusMedina.Fluent.Algebra.Extensions;
```

---

## Performance Characteristics

| Operation | Time | Notes |
|-----------|------|-------|
| Build expression | O(1) per operation | Immutable, no side effects |
| Evaluate | O(n) | n = expression depth |
| Simplify | O(n²) | May require multiple passes |
| ToLatex | O(n) | Linear in expression size |

---

**Last Updated:** 2025-03-16 | **Version:** 0.2.0
