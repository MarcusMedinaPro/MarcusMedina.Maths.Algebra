# Advanced Topics

Master the Fluent Algebra API with advanced techniques and patterns.

---

## Expression Composition

### Reusing Expressions

Build expressions from other expressions:

```csharp
var base = Algebra.X.Add(1);
var expr1 = base.Square();      // (x + 1)^2
var expr2 = base.Multiply(2);   // (x + 1) * 2
var expr3 = base.Add(base);     // (x + 1) + (x + 1)

// All use the same underlying expression
```

### Composite Patterns

```csharp
// Create a function builder
Func<double, double> createQuadratic(double a, double b, double c)
{
    var expr = Algebra.X
        .Square()
        .Multiply(a)
        .Add(Algebra.X.Multiply(b))
        .Add(c);

    return x => expr.Evaluate(x: x);
}

var quad = createQuadratic(1, 2, 3);  // x^2 + 2x + 3
Console.WriteLine(quad(4));            // 16 + 8 + 3 = 27
```

---

## Performance Optimization

### Caching Evaluations

```csharp
// Build once, evaluate many times
var expr = Algebra.X.Square().Add(Algebra.X).Multiply(2);

var stopwatch = Stopwatch.StartNew();
for (int i = 0; i < 1_000_000; i++)
{
    var result = expr.Evaluate(x: i);
}
stopwatch.Stop();
Console.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
```

### Pre-simplification

```csharp
// Complex expression
var expr = Algebra.X
    .Add(0)
    .Multiply(1)
    .Add(Algebra.Y)
    .Add(0);

// Simplify once
var optimized = expr.Simplify();

// Now evaluate is faster
for (int i = 0; i < 100_000; i++)
{
    optimized.Evaluate(x: i, y: i);
}
```

---

## Advanced Substitution

### Substituting with Complex Expressions

```csharp
var expr = Algebra.X.Add(Algebra.Y);

// Replace X with a complex expression
var substitution = Algebra.Y.Square().Add(1);
var result = expr.Substitute("X", substitution);

// Now: (Y^2 + 1) + Y
double value = result.Evaluate(y: 3);  // (9 + 1) + 3 = 13
```

### Partial Application

```csharp
var expr = Algebra.X.Add(Algebra.Y).Multiply(Algebra.Z);

// Partially apply values
var partial = expr
    .Substitute("X", Algebra.Constant(2))
    .Substitute("Z", Algebra.Constant(3));

// Now: (2 + Y) * 3 = 6 + 3Y
// Create a function of Y only
Func<double, double> f = y => partial.Evaluate(y: y);

Console.WriteLine(f(4));  // 6 + 12 = 18
```

---

## Working with Expression Trees

### Analyzing Expression Structure

```csharp
var expr = Algebra.X.Square().Add(1);

// Get all variables used
var vars = expr.GetVariables();
Console.WriteLine(string.Join(", ", vars));  // Output: X

// Check if constant
bool isConst = expr.IsConstant;
Console.WriteLine(isConst);  // false
```

### Converting Between Formats

```csharp
var expr = Algebra.X.Add(5).Square();

// LaTeX for typesetting
string latex = expr.ToLatex();
// Output: (x + 5)^{2}

// MathML for web
string mathml = expr.ToMathML();
// Output: <math>...</math>

// Debugging
string debug = expr.ToString();
// Output: Square(Add(X, 5))
```

---

## Custom Expression Building

### Builder Pattern

```csharp
public class ExpressionBuilder
{
    private IExpression _expr = Algebra.Constant(0);

    public ExpressionBuilder WithQuadratic(double a, double b, double c)
    {
        _expr = Algebra.X
            .Square()
            .Multiply(a)
            .Add(Algebra.X.Multiply(b))
            .Add(c);
        return this;
    }

    public ExpressionBuilder WithLinear(double m, double b)
    {
        _expr = Algebra.X.Multiply(m).Add(b);
        return this;
    }

    public IExpression Build() => _expr;
}

// Usage
var builder = new ExpressionBuilder();
var expr = builder
    .WithQuadratic(1, 2, 3)
    .Build();
```

### Expression Factory

```csharp
public static class Expressions
{
    public static IExpression Linear(double m, double b)
        => Algebra.X.Multiply(m).Add(b);

    public static IExpression Quadratic(double a, double b, double c)
        => Algebra.X
            .Square()
            .Multiply(a)
            .Add(Algebra.X.Multiply(b))
            .Add(c);

    public static IExpression Polynomial(params double[] coefficients)
    {
        if (coefficients.Length == 0)
            return Algebra.Constant(0);

        IExpression expr = Algebra.Constant(coefficients[0]);
        for (int i = 1; i < coefficients.Length; i++)
        {
            expr = expr.Add(Algebra.X.Power(i).Multiply(coefficients[i]));
        }
        return expr;
    }
}

// Usage
var linear = Expressions.Linear(2, 3);     // 2x + 3
var quad = Expressions.Quadratic(1, 2, 3); // x^2 + 2x + 3
var poly = Expressions.Polynomial(1, 2, 3, 4);  // 1 + 2x + 3x^2 + 4x^3
```

---

## Integration Patterns

### With LINQ

```csharp
var expressions = new[]
{
    Algebra.X.Add(1),
    Algebra.X.Multiply(2),
    Algebra.X.Square()
};

var results = expressions
    .Select(expr => expr.Evaluate(x: 5))
    .ToArray();

// [6, 10, 25]
```

### With Data Processing

```csharp
var data = new[] { 1, 2, 3, 4, 5 };
var expr = Algebra.X.Square().Add(Algebra.X);

var transformed = data
    .Select(x => expr.Evaluate(x: x))
    .ToArray();

// [2, 6, 12, 20, 30]
```

### With Async Operations

```csharp
public async Task<double> EvaluateAsync(IExpression expr, double x)
{
    return await Task.Run(() => expr.Evaluate(x: x));
}

// Usage
var expr = Algebra.X.Square().Add(5);
var result = await EvaluateAsync(expr, 3);  // 14
```

---

## Error Handling Strategies

### Graceful Degradation

```csharp
public double SafeEvaluate(IExpression expr, double x, double defaultValue = 0)
{
    try
    {
        return expr.Evaluate(x: x);
    }
    catch (EvaluationException)
    {
        return defaultValue;
    }
}

// Usage
var expr = Algebra.X.Divide(0);
double result = SafeEvaluate(expr, 5, defaultValue: -1);  // -1
```

### Validation

```csharp
public bool TryEvaluate(IExpression expr, double x, out double result)
{
    try
    {
        result = expr.Evaluate(x: x);
        return !double.IsNaN(result) && !double.IsInfinity(result);
    }
    catch
    {
        result = 0;
        return false;
    }
}

// Usage
var expr = Algebra.X.Square();
if (TryEvaluate(expr, 5, out var result))
{
    Console.WriteLine($"Result: {result}");
}
```

---

## Best Practices

### ✅ Do

- Build expressions as constants when reusing
- Simplify complex expressions before evaluating many times
- Use custom variables for domain-specific models
- Cache expression builders for factory methods
- Validate input values before evaluation

### ❌ Don't

- Create the same expression repeatedly
- Evaluate unsimplified expressions in tight loops
- Forget variable names are case-sensitive
- Assume all operations succeed (handle NaN/Infinity)
- Build extremely deep expression trees (consider limits)

---

## Debugging Tips

### Print Expression Structure

```csharp
var expr = Algebra.X.Square().Add(Algebra.X).Multiply(2);
Console.WriteLine(expr.ToString());
// Output: Multiply(Add(Square(X), X), 2)
```

### Step-by-Step Evaluation

```csharp
var expr = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

var step1 = Algebra.Constant(5).Add(2);           // 7
var step2 = step1.Square();                        // 49
var step3 = step2.Divide(3);                       // ~16.33
Console.WriteLine(step3.Evaluate());
```

### Variable Tracing

```csharp
var expr = Algebra.X.Add(Algebra.Y);
var vars = expr.GetVariables();
Console.WriteLine($"Variables: {string.Join(", ", vars)}");
```

---

## Summary

**Advanced techniques:**
- Expression composition and reuse
- Performance optimization through simplification
- Complex substitution patterns
- Custom builders and factories
- Integration with LINQ and async
- Robust error handling

**Next steps:**
- Read [API Reference](./API.md) for complete documentation
- Check [Examples](./Examples/) for practical code
- See real-world use cases in `usecases/` folder

---

**Last Updated:** 2025-03-16 | **Version:** 0.2.0
