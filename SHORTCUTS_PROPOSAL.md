# Fluent.Algebra Shortcuts Proposal

## Problem Statement

Current syntax is verbose:
```csharp
var sum = Algebra.Constant(3).Add(5);
var area = Algebra.Var("l").Multiply(Algebra.Var("b"));
```

Goal: Make it feel more like natural math!

---

## Solution: Three-Tier Approach

### Tier 1: Implicit Conversions ⭐ (v0.2.0)

**Implementation:**
```csharp
// In IAlgebraExpression or helper class:
public static implicit operator IAlgebraExpression(double value)
    => new ConstantExpression(value);

public static implicit operator IAlgebraExpression(int value)
    => new ConstantExpression(value);

public static implicit operator IAlgebraExpression(string name)
    => new VariableExpression(name);
```

**Usage:**
```csharp
IAlgebraExpression x = "x";     // Auto-convert string → Variable
IAlgebraExpression five = 5;    // Auto-convert int → Constant
var sum = x.Add(five);          // x + 5
```

**Pros:**
✅ Clean syntax
✅ Type-safe
✅ No parsing overhead

**Cons:**
⚠️ Must explicitly type as `IAlgebraExpression`
⚠️ `var` won't work (var x = "x" is still string)

---

### Tier 2: Operator Overloading 🔥 (v0.2.0)

**Implementation:**
```csharp
// Add to IAlgebraExpression interface or via extension class:
public static class AlgebraOperators
{
    public static IAlgebraExpression operator +(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Add, right);

    public static IAlgebraExpression operator -(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Subtract, right);

    public static IAlgebraExpression operator *(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Multiply, right);

    public static IAlgebraExpression operator /(IAlgebraExpression left, IAlgebraExpression right)
        => new BinaryExpression(left, BinaryOperator.Divide, right);

    public static IAlgebraExpression operator -(IAlgebraExpression operand)
        => new UnaryExpression(UnaryOperator.Negate, operand);
}
```

**Usage:**
```csharp
IAlgebraExpression x = "x";
IAlgebraExpression y = "y";

// NATURAL MATH SYNTAX!
var expr1 = x + 5;              // Instead of x.Add(5)
var expr2 = 2 * x;              // Instead of Algebra.Constant(2).Multiply(x)
var expr3 = x * x + 2 * x + 1;  // Instead of... you get it
var expr4 = (x + 2) * (x - 3);  // Parentheses work!
var expr5 = -x;                 // Negation

// With implicit conversions:
var quad = (x + 2) * (x + 2);   // (x+2)²
```

**Pros:**
✅ MOST natural syntax - looks like real math!
✅ Parentheses work automatically
✅ Type-safe
✅ No performance overhead

**Cons:**
⚠️ Can't overload `^` for power (not valid C# operator)
⚠️ Still need `.Power()` or `.Square()` for exponents

---

### Tier 3: Expression Builder Wrapper (Optional Enhancement)

**Implementation:**
```csharp
// Wrapper class for even cleaner syntax:
public class Expr
{
    private readonly IAlgebraExpression _inner;

    private Expr(IAlgebraExpression inner) => _inner = inner;

    public static implicit operator Expr(double value) => new(new ConstantExpression(value));
    public static implicit operator Expr(string name) => new(new VariableExpression(name));
    public static implicit operator IAlgebraExpression(Expr expr) => expr._inner;

    public static Expr operator +(Expr left, Expr right)
        => new(left._inner + right._inner);
    // ... other operators

    public Expr Power(Expr exponent) => new(_inner.Power(exponent._inner));
    public double Eval(params (string name, double value)[] vars)
        => _inner.Evaluate(vars.ToDictionary(x => x.name, x => x.value));
}
```

**Usage:**
```csharp
Expr x = "x";           // Clean!
var quad = (x + 2).Power(2) / 3;
var result = quad.Eval(("x", 5));  // 16.333
```

**Pros:**
✅ Even cleaner - no need for `IAlgebraExpression` type
✅ Can use `var` everywhere

**Cons:**
⚠️ Additional wrapper class
⚠️ Slight mental overhead (two types to understand)

---

## Recommended Implementation Plan

### Phase 1: Operator Overloading (v0.2.0) - PRIORITY 🔴

**Why start here:** Biggest bang for buck - makes fluent API feel magical!

**Steps:**
1. Add operator overloads to a new `AlgebraOperators` static class
2. Update generator to include these operators
3. Add tests for operator precedence
4. Document in README

**Example comparison:**
```csharp
// BEFORE:
var expr = Algebra.X
    .Add(2)
    .Square()
    .Subtract(Algebra.Constant(3).Multiply(Algebra.X))
    .Add(1);

// AFTER:
IAlgebraExpression x = "x";
var expr = (x + 2).Square() - 3 * x + 1;

// OR even (with helper):
var x = Algebra.X;
var expr = (x + 2).Square() - 3 * x + 1;
```

**This is a GAME CHANGER!** 🚀

---

### Phase 2: Implicit Conversions (v0.2.0) - PRIORITY 🟡

Already partially exists (ConstantExpression has implicit from int/double).

**Add:**
```csharp
// In VariableExpression:
public static implicit operator VariableExpression(string name)
    => new(name);
```

---

### Phase 3: Expr Wrapper (v0.3.0) - PRIORITY 🟢

Optional quality-of-life improvement if users want even cleaner syntax.

---

### Phase 4: Parse (v0.3.0) - PRIORITY 🔴

For ultimate simplicity:
```csharp
var expr = Algebra.Parse("(x + 2)^2 - 3*x + 1");
```

---

## Compatibility & Migration

### Breaking Changes
❌ None! All additions are backwards compatible.

### Migration Path
```csharp
// Old style still works:
var old = Algebra.X.Add(5);

// New style available:
IAlgebraExpression x = "x";
var new = x + 5;

// Both are equivalent!
```

---

## Examples: Before & After

### Example 1: Quadratic
```csharp
// BEFORE:
var expr = Algebra.X.Add(2).Square().Divide(3);

// AFTER:
IAlgebraExpression x = "x";
var expr = (x + 2).Square() / 3;

// OR (when parse ready):
var expr = Algebra.Parse("(x + 2)^2 / 3");
```

### Example 2: Distance Formula
```csharp
// BEFORE:
var dx = Algebra.Var("x2").Subtract(Algebra.Var("x1"));
var dy = Algebra.Var("y2").Subtract(Algebra.Var("y1"));
var distance = Algebra.Sqrt(dx.Square().Add(dy.Square()));

// AFTER:
IAlgebraExpression x1 = "x1", x2 = "x2";
IAlgebraExpression y1 = "y1", y2 = "y2";
var distance = Algebra.Sqrt((x2 - x1).Square() + (y2 - y1).Square());

// OR:
var distance = Algebra.Parse("sqrt((x2-x1)^2 + (y2-y1)^2)");
```

### Example 3: Polynomial
```csharp
// BEFORE:
var poly = Algebra.X.Power(3)
    .Add(Algebra.X.Square().Multiply(2))
    .Subtract(Algebra.X.Multiply(5))
    .Add(3);

// AFTER:
IAlgebraExpression x = "x";
var poly = x.Power(3) + 2 * x.Square() - 5 * x + 3;

// OR:
var poly = Algebra.Parse("x^3 + 2*x^2 - 5*x + 3");
```

**HUGE improvement in readability!** 📈

---

## Technical Considerations

### C# Operator Overloading Limitations

**Cannot override:**
- `^` (XOR in C#, not power)
- `=` (assignment)
- `&&`, `||` (short-circuit logic)

**Solution:**
- Use `.Power()` method for exponentiation
- Eventually: Parse `"x^2"` → converts to `.Power()`

### Type Inference Challenges

```csharp
var x = "x";  // Type is string, not IAlgebraExpression
var y = x + 5;  // ERROR: Can't add int to string

// Must use:
IAlgebraExpression x = "x";  // Explicit type
var y = x + 5;  // OK
```

**Workaround options:**
1. Accept it (most type-safe)
2. Use `Expr` wrapper (cleaner but additional type)
3. Helper factory: `var x = Algebra.V("x");`

---

## Performance Impact

**Operator overloading:**
- ✅ Zero overhead - compiles to same code as `.Add()`

**Implicit conversions:**
- ✅ Zero runtime overhead - compile-time transformation

**Conclusion:** No performance penalty! 🎉

---

## User Experience Comparison

### Beginner Friendly
```csharp
// Option 1: Full explicit (clearest for learning)
var x = Algebra.X;
var expr = x.Add(2).Square().Divide(3);

// Option 2: Natural operators (most intuitive)
IAlgebraExpression x = "x";
var expr = (x + 2).Square() / 3;

// Option 3: Parse (simplest for basic cases)
var expr = Algebra.Parse("(x + 2)^2 / 3");
```

**Winner:** Option 2 (operators) - looks like math, still type-safe!

---

## Recommendation: Implement Now! 🚀

**Priority 1 (v0.2.0 - Next Week):**
- ✅ Add operator overloading (+, -, *, /, unary -)
- ✅ Update generator to include operators
- ✅ Add comprehensive tests
- ✅ Update README with examples

**Priority 2 (v0.2.0):**
- ✅ Strengthen implicit conversions
- ✅ Add helper methods for common patterns

**Priority 3 (v0.3.0):**
- ✅ Implement parser for ultimate convenience

**Result:** Users get natural math syntax WITHOUT waiting for parser! 🎯

---

## Next Steps

1. Update FluentAlgebraGenerator to generate operator overloads
2. Add tests for operator precedence
3. Update examples to show both styles
4. Document in README

**Estimated time:** 1-2 days

**Impact:** MASSIVE improvement in developer experience! 💥
