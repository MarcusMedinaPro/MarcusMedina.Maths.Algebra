# Building a Computer Algebra System in C#
## From Verbose to Magical: A Journey Through Expression Trees

**By Marcus Medina**

---

## Book Structure

### Part I: Foundation (Weeks 1-2)
1. Why Build a CAS?
2. Expression Trees Explained
3. Your First Expression

### Part II: The Fluent API (Weeks 3-4)
4. Building the API
5. From Verbose to Clean
6. Shortcuts That Feel Like Magic

### Part III: Parsing (Weeks 5-6)
7. Lexing and Tokenization
8. Building the Parser
9. Operator Precedence

### Part IV: Symbolic Math (Weeks 7-10)
10. Differentiation
11. Integration
12. Equation Solving

### Part V: Production Ready (Weeks 11-12)
13. Performance Optimization
14. Error Handling
15. Testing Strategies

---

## Chapter 1: Why Build a CAS?

### The Problem

You're teaching high school math. A student asks:
> "Can I check if my derivative is correct?"

You open Wolfram Alpha. It works. But the student asks:
> "How does it KNOW that?"

This book answers that question.

### What We'll Build

By the end, you'll have built a system that can:

```csharp
// Parse mathematical expressions
Expr f = "x^2 + 2*x + 1";

// Evaluate them
var result = f.Evaluate("x", 5);  // 36

// Differentiate them
var derivative = f.Differentiate("x");  // 2*x + 2

// Simplify them
var simplified = f.Simplify();  // (x+1)^2

// Export to LaTeX
var latex = f.ToLaTeX();  // x^2 + 2x + 1
```

### The Journey

We'll go from **verbose** to **magical** in three stages:

---

## Chapter 2: Expression Trees Explained

### What is an Expression Tree?

When you write `3 + 5`, your brain sees two numbers and an operation.
A computer needs structure:

```
    Add
   /   \
  3     5
```

This is an **expression tree**.

### Building Trees in C#

```csharp
// Version 1: Manual construction (verbose)
var three = new ConstantExpression(3);
var five = new ConstantExpression(5);
var sum = new BinaryExpression(three, BinaryOperator.Add, five);

Console.WriteLine(sum.Evaluate());  // 8
```

**This works, but it's painful.**

---

## Chapter 3: Your First Expression

### The Interface

Every expression implements:

```csharp
public interface IAlgebraExpression
{
    double Evaluate(Dictionary<string, double>? variables = null);
    string ToString();
    IAlgebraExpression Simplify();
}
```

### Three Core Types

**1. Constants** - Fixed numbers
```csharp
var five = new ConstantExpression(5);
five.Evaluate();  // Always returns 5
```

**2. Variables** - Placeholders
```csharp
var x = new VariableExpression("x");
x.Evaluate(new Dictionary<string, double> { ["x"] = 10 });  // 10
```

**3. Operations** - Combine expressions
```csharp
var sum = new BinaryExpression(x, BinaryOperator.Add, five);
sum.Evaluate(new Dictionary<string, double> { ["x"] = 10 });  // 15
```

### Exercise: Build (x + 2)²

```csharp
var x = new VariableExpression("x");
var two = new ConstantExpression(2);
var sum = new BinaryExpression(x, BinaryOperator.Add, two);
var squared = new BinaryExpression(sum, BinaryOperator.Power, two);

squared.Evaluate(new Dictionary<string, double> { ["x"] = 5 });  // 49
```

**Painful? Yes. But it works. Let's make it better.**

---

## Chapter 4: Building the Fluent API

### The Builder Pattern

```csharp
public static class Algebra
{
    public static IAlgebraExpression X => new VariableExpression("x");
    public static IAlgebraExpression Constant(double value)
        => new ConstantExpression(value);
}
```

### Extension Methods

```csharp
public static class AlgebraExtensions
{
    public static IAlgebraExpression Add(
        this IAlgebraExpression left,
        IAlgebraExpression right)
    {
        return new BinaryExpression(left, BinaryOperator.Add, right);
    }

    public static IAlgebraExpression Add(
        this IAlgebraExpression left,
        double right)
    {
        return left.Add(new ConstantExpression(right));
    }
}
```

### Now We Can Chain!

```csharp
// Before:
var x = new VariableExpression("x");
var two = new ConstantExpression(2);
var sum = new BinaryExpression(x, BinaryOperator.Add, two);
var squared = new BinaryExpression(sum, BinaryOperator.Power, two);

// After:
var squared = Algebra.X.Add(2).Power(2);
```

**Much better!**

---

## Chapter 5: From Verbose to Clean

### Level 1: Basic Fluent (v0.1.0)

```csharp
// Still verbose, but readable
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

var result = expr.Evaluate("x", 5);  // 16.333
```

**Pros:** ✅ Readable, ✅ Type-safe
**Cons:** ⚠️ Still wordy

---

### Level 2: Operator Overloading (v0.2.0)

Add operators to IAlgebraExpression:

```csharp
public static IAlgebraExpression operator +(
    IAlgebraExpression left,
    IAlgebraExpression right)
{
    return new BinaryExpression(left, BinaryOperator.Add, right);
}
```

Now we can write:

```csharp
IAlgebraExpression x = new VariableExpression("x");
var expr = (x + 2).Square() / 3;

var result = expr.Evaluate("x", 5);  // 16.333
```

**Much more natural!**

But wait... we still write `IAlgebraExpression` everywhere. 😕

---

### Level 3: Type Aliases (v0.2.0)

Add `GlobalUsings.cs`:

```csharp
global using Expr = MarcusMedina.Fluent.Algebra.Interfaces.IAlgebraExpression;
```

Now:

```csharp
Expr x = new VariableExpression("x");
var expr = (x + 2).Square() / 3;
```

**Better! But creating variables is still ugly.**

---

### Level 4: Implicit Conversions (v0.2.0)

Add implicit operators:

```csharp
// In VariableExpression:
public static implicit operator VariableExpression(string name)
    => new(name);

// In ConstantExpression:
public static implicit operator ConstantExpression(double value)
    => new(value);
```

Now:

```csharp
Expr x = "x";  // AUTO-CONVERT! ✨
Expr five = 5; // AUTO-CONVERT! ✨

var expr = (x + 2).Square() / 3;
```

**This is starting to feel magical!** 🎩

---

### Level 5: Parse (v0.3.0)

With parser + implicit conversion:

```csharp
// Implicit operator in Expr:
public static implicit operator Expr(string input)
{
    // If just a variable name
    if (IsValidIdentifier(input))
        return new VariableExpression(input);

    // Otherwise parse as expression
    return AlgebraParser.Parse(input);
}
```

Ultimate syntax:

```csharp
// Variables
Expr x = "x";

// Simple expressions
Expr sum = "x + 5";

// Complex expressions
Expr quad = "(x + 2)^2 / 3";

// All just work!
var result = quad.Evaluate("x", 5);  // 16.333
```

**PEAK developer experience!** 🚀

---

## Chapter 6: Shortcuts That Feel Like Magic

### The Three-Stage Evolution

```csharp
// STAGE 1: Explicit (v0.1.0)
var x = new VariableExpression("x");
var two = new ConstantExpression(2);
var sum = new BinaryExpression(x, BinaryOperator.Add, two);
var power = new BinaryExpression(sum, BinaryOperator.Power, two);
var div = new BinaryExpression(power, BinaryOperator.Divide, new ConstantExpression(3));
var result = div.Evaluate(new Dictionary<string, double> { ["x"] = 5 });

// STAGE 2: Fluent + Operators (v0.2.0)
Expr x = "x";
var expr = (x + 2).Square() / 3;
var result = expr.Evaluate("x", 5);

// STAGE 3: Parse (v0.3.0)
Expr expr = "(x + 2)^2 / 3";
var result = expr.Evaluate("x", 5);
```

### Why This Matters

**For beginners:**
- Stage 1 teaches how it works
- Stage 2 makes it usable
- Stage 3 makes it natural

**For pros:**
- Stage 1 for debugging
- Stage 2 for building complex expressions
- Stage 3 for quick prototypes

### Comparison: Python SymPy vs Our C#

**SymPy:**
```python
from sympy import symbols, sqrt

x = symbols('x')
expr = (x + 2)**2 / 3
result = expr.subs(x, 5)  # 16.333...
```

**Our C# (Stage 2):**
```csharp
Expr x = "x";
var expr = (x + 2).Square() / 3;
var result = expr.Evaluate("x", 5);  // 16.333
```

**Almost identical!** And it's all type-safe at compile time! 🎯

---

## Chapter 7: Real-World Examples

### Example 1: Distance Formula

```csharp
// Stage 1: Verbose (for learning)
var x1 = new VariableExpression("x1");
var x2 = new VariableExpression("x2");
var y1 = new VariableExpression("y1");
var y2 = new VariableExpression("y2");

var dx = new BinaryExpression(x2, BinaryOperator.Subtract, x1);
var dy = new BinaryExpression(y2, BinaryOperator.Subtract, y1);
var dxSquared = new BinaryExpression(dx, BinaryOperator.Power, new ConstantExpression(2));
var dySquared = new BinaryExpression(dy, BinaryOperator.Power, new ConstantExpression(2));
var sum = new BinaryExpression(dxSquared, BinaryOperator.Add, dySquared);
var distance = new FunctionExpression("sqrt", sum);

// Stage 2: Fluent (for usage)
Expr x1 = "x1", x2 = "x2", y1 = "y1", y2 = "y2";
var distance = Algebra.Sqrt((x2 - x1).Square() + (y2 - y1).Square());

// Stage 3: Parse (for prototyping)
Expr distance = "sqrt((x2-x1)^2 + (y2-y1)^2)";

// Evaluate
var d = distance.Evaluate(new Dictionary<string, double>
{
    ["x1"] = 0, ["y1"] = 0,
    ["x2"] = 3, ["y2"] = 4
});  // 5.0
```

### Example 2: Quadratic Formula

```csharp
// Stage 1: Teaching version (shows structure)
var a = new VariableExpression("a");
var b = new VariableExpression("b");
var c = new VariableExpression("c");
var four = new ConstantExpression(4);
var two = new ConstantExpression(2);

var bSquared = new BinaryExpression(b, BinaryOperator.Power, two);
var fourAC = new BinaryExpression(
    new BinaryExpression(four, BinaryOperator.Multiply, a),
    BinaryOperator.Multiply,
    c
);
var discriminant = new BinaryExpression(bSquared, BinaryOperator.Subtract, fourAC);
var sqrtDisc = new FunctionExpression("sqrt", discriminant);
var negB = new UnaryExpression(UnaryOperator.Negate, b);
var numerator = new BinaryExpression(negB, BinaryOperator.Add, sqrtDisc);
var twoA = new BinaryExpression(two, BinaryOperator.Multiply, a);
var solution = new BinaryExpression(numerator, BinaryOperator.Divide, twoA);

// Stage 2: Production version
Expr a = "a", b = "b", c = "c";
var discriminant = b.Square() - 4 * a * c;
var solution = (-b + Algebra.Sqrt(discriminant)) / (2 * a);

// Stage 3: Quick prototype
Expr solution = "(-b + sqrt(b^2 - 4*a*c)) / (2*a)";

// Use it
var x = solution.Evaluate(new Dictionary<string, double>
{
    ["a"] = 1,
    ["b"] = -5,
    ["c"] = 6
});  // x = 3 (or 2, depending on ±)
```

### Example 3: Trigonometric Identity

```csharp
// Prove: sin²(x) + cos²(x) = 1

// Stage 2: Build it
Expr x = "x";
var identity = Algebra.Sin(x).Square() + Algebra.Cos(x).Square();

// Test at different values
for (double angle = 0; angle <= Math.PI * 2; angle += Math.PI / 4)
{
    var result = identity.Evaluate("x", angle);
    Console.WriteLine($"At x={angle:F2}: {result:F6}");
}

// Output:
// At x=0.00: 1.000000
// At x=0.79: 1.000000
// At x=1.57: 1.000000
// ... (always 1!)
```

---

## Chapter 8: Teaching Tool

### For Students

**Show step-by-step progression:**

```csharp
// Week 1: Understand structure
var x = new VariableExpression("x");
var expr = new BinaryExpression(x, BinaryOperator.Add, new ConstantExpression(5));

// Week 2: Use fluent API
var expr = Algebra.X.Add(5);

// Week 3: Use operators
Expr x = "x";
var expr = x + 5;

// Week 4: Parse expressions
Expr expr = "x + 5";
```

### For Teachers

**Demonstrate concepts:**

```csharp
// Show that expressions are just data structures
var expr = Algebra.X.Add(5);
Console.WriteLine($"Type: {expr.GetType().Name}");  // BinaryExpression
Console.WriteLine($"Structure: {expr}");            // (x + 5)

// Show evaluation with different values
for (int i = 0; i <= 10; i++)
{
    Console.WriteLine($"x={i}: {expr.Evaluate("x", i)}");
}

// Show LaTeX export for presentations
Console.WriteLine($"LaTeX: {expr.ToLaTeX()}");
```

---

## Chapter 9: The Path Forward

### What We Built

- ✅ Expression trees (foundation)
- ✅ Fluent API (usability)
- ✅ Operator overloading (naturalness)
- ✅ Type aliases (brevity)
- ✅ Implicit conversions (magic)

### What's Next

- 🔜 Parser (Stage 3)
- 🔜 Equation solver
- 🔜 Differentiation
- 🔜 Integration
- 🔜 Complete CAS

### Your Challenge

Pick one:

**Option A: Implement the Parser**
Read Chapter 10 and build the parser that makes `Expr x = "x + 5"` work.

**Option B: Add Differentiation**
Read Chapter 11 and implement symbolic derivatives.

**Option C: Solve Equations**
Read Chapter 12 and build an equation solver.

---

## Appendix: Complete API Evolution

```csharp
// ═══════════════════════════════════════════════════════════
// EVOLUTION: From Verbose to Magical
// ═══════════════════════════════════════════════════════════

// Expression: (x + 2)² / 3

// ───────────────────────────────────────────────────────────
// v0.1.0: Explicit Construction (Learning)
// ───────────────────────────────────────────────────────────
var x = new VariableExpression("x");
var two = new ConstantExpression(2);
var sum = new BinaryExpression(x, BinaryOperator.Add, two);
var squared = new BinaryExpression(sum, BinaryOperator.Power, two);
var three = new ConstantExpression(3);
var result = new BinaryExpression(squared, BinaryOperator.Divide, three);

// ───────────────────────────────────────────────────────────
// v0.1.0: Fluent API (Usable)
// ───────────────────────────────────────────────────────────
var result = Algebra.X.Add(2).Square().Divide(3);

// ───────────────────────────────────────────────────────────
// v0.2.0: Operators + Implicit (Natural)
// ───────────────────────────────────────────────────────────
Expr x = "x";
var result = (x + 2).Square() / 3;

// ───────────────────────────────────────────────────────────
// v0.3.0: Parse (Magical)
// ───────────────────────────────────────────────────────────
Expr result = "(x + 2)^2 / 3";

// ═══════════════════════════════════════════════════════════
// All four produce IDENTICAL expression trees!
// ═══════════════════════════════════════════════════════════

result.Evaluate("x", 5);  // 16.333 (all versions)
result.ToLaTeX();         // \frac{(x+2)^2}{3} (all versions)
result.Simplify();        // Same tree (all versions)
```

---

**End of Book Outline**

---

## Next Steps for Book

### Chapters to Expand:
1. Parser implementation (Chapter 10-12)
2. Differentiation rules (Chapter 13-15)
3. Integration techniques (Chapter 16-18)
4. Performance optimization (Chapter 19-20)

### Code Repository:
All code examples available at: github.com/MarcusMedina/Fluent.Algebra

### Target Audience:
- C# developers learning advanced patterns
- Math students wanting to understand CAS internals
- Teachers looking for educational tools
- Anyone building formula editors or calculators

---

**The journey from verbose to magical is complete.** 🎉

**Now it's your turn to build something amazing!** 🚀
