# Example 1: Building Algebraic Expressions

Learn how to build simple and complex algebraic expressions using the fluent API.

---

## Simple Expressions

### Expression: x + 5

```csharp
var expr = Algebra.X.Add(5);
```

Building step-by-step:
1. Start with variable `X`
2. Chain `.Add(5)` to add 5 to it
3. Result: `x + 5`

### Expression: 2x - 3

```csharp
var expr = Algebra.X
    .Multiply(2)
    .Subtract(3);
```

This builds: `(x * 2) - 3` = `2x - 3`

---

## Intermediate Expressions

### Expression: (x + 2)²

```csharp
var expr = Algebra.X
    .Add(2)
    .Square();
```

**Important:** Parentheses are implicit in chaining:
- `.Add(2).Square()` means `(x + 2)²`
- NOT `x + 2²`

### Expression: (x + 2)² / 3

```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);
```

Breaking it down:
1. `Algebra.X` → `x`
2. `.Add(2)` → `x + 2`
3. `.Square()` → `(x + 2)²`
4. `.Divide(3)` → `(x + 2)² / 3`

---

## Complex Expressions

### Quadratic: ax² + bx + c

Build expression `3x² + 2x + 1`:

```csharp
var expr = Algebra.X
    .Square()
    .Multiply(3)
    .Add(Algebra.X.Multiply(2))
    .Add(1);

// Represents: 3x² + 2x + 1
```

**Evaluate with different values:**

```csharp
double y1 = expr.Evaluate(x: 0);   // 1
double y2 = expr.Evaluate(x: 1);   // 6
double y3 = expr.Evaluate(x: 2);   // 17
double y4 = expr.Evaluate(x: -1);  // 2
```

### Polynomial: x³ + 2x² - x + 5

```csharp
var expr = Algebra.X
    .Cube()
    .Add(Algebra.X.Square().Multiply(2))
    .Subtract(Algebra.X)
    .Add(5);

// x³ + 2x² - x + 5
```

---

## Working with Multiple Variables

### Expression: x + y

```csharp
var expr = Algebra.X.Add(Algebra.Y);

double result = expr.Evaluate(x: 3, y: 4);  // 7
```

### Expression: x² + y²

```csharp
var expr = Algebra.X.Square().Add(Algebra.Y.Square());

double result = expr.Evaluate(x: 3, y: 4);  // 9 + 16 = 25
```

This is the Pythagorean theorem!

### Expression: (x + y)(x - y)

```csharp
var sum = Algebra.X.Add(Algebra.Y);
var diff = Algebra.X.Subtract(Algebra.Y);

var expr = sum.Multiply(diff);
// (x + y)(x - y) = x² - y²

double result = expr.Evaluate(x: 5, y: 3);  // 25 - 9 = 16
```

---

## Reusing Expressions

### Build once, evaluate many times

```csharp
// Build the expression
var expr = Algebra.X.Square().Add(Algebra.X).Add(1);

// Evaluate multiple times
for (int i = 0; i <= 5; i++)
{
    double result = expr.Evaluate(x: i);
    Console.WriteLine($"f({i}) = {result}");
}

// Output:
// f(0) = 1
// f(1) = 3
// f(2) = 7
// f(3) = 13
// f(4) = 21
// f(5) = 31
```

### Extract parts and reuse

```csharp
var x = Algebra.X;
var y = Algebra.Y;

// Build components
var linearX = x.Multiply(2);
var linearY = y.Multiply(3);

// Combine them
var expr = linearX.Add(linearY).Add(5);  // 2x + 3y + 5

double result = expr.Evaluate(x: 2, y: 3);  // 4 + 9 + 5 = 18
```

---

## Exporting Built Expressions

### Convert to LaTeX

```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

string latex = expr.ToLatex();
Console.WriteLine(latex);

// Output: \frac{(x + 2)^{2}}{3}
```

**In a LaTeX document:**
```latex
The expression is: \frac{(x + 2)^{2}}{3}
```

### View Expression Structure

```csharp
var expr = Algebra.X.Add(5).Multiply(2);

// String representation for debugging
string debug = expr.ToString();
Console.WriteLine(debug);

// Output: Multiply(Add(X, 5), 2)
```

---

## Common Building Mistakes

### ❌ Mistake 1: Wrong order of operations

```csharp
// WRONG - This is (x * 2) + 3 NOT 2(x + 3)
var wrong = Algebra.X.Multiply(2).Add(3);

// RIGHT - This is 2(x + 3)
var right = Algebra.X.Add(3).Multiply(2);
```

### ❌ Mistake 2: Forgetting to chain

```csharp
// WRONG - x2 is undefined
var x = Algebra.X;
var expr = x.Multiply(2);
var x2 = x.Square();  // This creates a new expression, doesn't modify expr

// RIGHT - Chain operations
var expr = Algebra.X.Multiply(2).Square();  // (2x)²
```

### ❌ Mistake 3: Missing variable references

```csharp
// WRONG - Constants, not variables
var expr = Algebra.X.Add(5);
double result = expr.Evaluate();  // Missing x: parameter!

// RIGHT - Provide all variables
double result = expr.Evaluate(x: 10);  // ✓
```

---

## Summary

**Key points:**
- Use `Algebra.X`, `Algebra.Y` for variables
- Chain operations for natural syntax
- Each operation returns a new expression
- Evaluate with `.Evaluate(x: value, y: value, ...)`
- Export to LaTeX with `.ToLatex()`
- Expressions are immutable

**Next:** See [Example 2: Variable Substitution](./Example2_VariableSubstitution.md)
