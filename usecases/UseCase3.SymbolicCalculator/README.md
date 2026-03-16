# Use Case 3: Symbolic Calculator

**Problem Solved:** Build an interactive calculator for symbolic mathematics and expression manipulation

This example demonstrates how to use MarcusMedina.Fluent.Algebra to create a calculator that can store, manipulate, and evaluate algebraic expressions symbolically—perfect for business applications, educational tools, and scientific computing.

---

## The Problem

You need to:
- Store multiple algebraic expressions with meaningful names
- Evaluate expressions with different variable values
- Perform algebraic manipulations (substitution, simplification)
- Generate mathematical notation for documentation
- Build applications that work with symbolic math
- Solve real-world problems (cost analysis, optimization, etc.)

---

## The Solution

```csharp
var calculator = new SymbolicCalculator();

// Define expressions
var revenue = Algebra.X.Multiply(25);
var cost = Algebra.X.Multiply(12).Add(50);
var profit = revenue.Subtract(cost);

// Store them
calculator.Store("Revenue", revenue);
calculator.Store("Cost", cost);
calculator.Store("Profit", profit);

// Evaluate
double profit = calculator.Evaluate("Profit", x: 100);  // $1300

// Export
string latex = calculator.GetLaTeX("Profit");  // 25x - (12x + 50)
```

---

## How to Run

```bash
cd usecases/UseCase3.SymbolicCalculator
dotnet run
```

**Expected Output:**
```
=== Symbolic Mathematics Calculator ===

--- Scenario 1: Cost Analysis ---
Problem: Total cost = 50 (fixed) + 12x (per unit)
Expression: 12x + 50

Cost for different quantities:
  0 units: $50
  2 units: $74
  4 units: $98
  ...

--- Scenario 2: Revenue Calculation ---
Problem: Revenue = 25x (price per unit)
Expression: 25x

--- Scenario 3: Profit Analysis ---
Profit = Revenue - Cost
       = 25x - (12x + 50)
       = 13x - 50

Profit analysis:
  0 units: Revenue=$0, Cost=$50, Profit=$-50
  5 units: Revenue=$125, Cost=$110, Profit=$15
  ...

Break-even Analysis
Break-even point: x = 3.85 units
Verification: Profit = 0.00

--- Inventory Optimization ---
...
```

---

## Key Features Demonstrated

✅ **Expression Storage** - Named storage of algebraic expressions
✅ **Symbolic Computation** - Manipulate expressions algebraically
✅ **Multiple Evaluations** - Evaluate same expression with different values
✅ **Real-world Problems** - Cost, revenue, profit analysis
✅ **LaTeX Export** - Generate mathematical notation
✅ **Break-even Analysis** - Find critical points
✅ **Optimization** - Find minimum/maximum values

---

## Real-World Applications

### Business & Finance
- **Cost Analysis** - Fixed + variable costs
- **Revenue Planning** - Price × quantity models
- **Profit Optimization** - Revenue - Cost analysis
- **Break-even** - When profit = 0
- **Pricing Strategies** - Dynamic pricing models

### Education
- **Interactive Tools** - Student learning platforms
- **Problem Generators** - Dynamic homework creation
- **Visualization** - Display equations with results
- **Assessment** - Auto-grading math problems

### Science & Engineering
- **Physics Equations** - Motion, forces, energy
- **Chemistry** - Stoichiometry calculations
- **Economics** - Supply/demand curves
- **Statistics** - Distribution formulas

---

## Calculator Architecture

The `SymbolicCalculator` class provides:

```csharp
public class SymbolicCalculator
{
    public void Store(string name, IExpression expression);
    public IExpression? Get(string name);
    public double Evaluate(string name, double x);
    public string GetLaTeX(string name);
    public IEnumerable<string> GetNames();
    public void PrintAll();
}
```

---

## Extending the Calculator

### Add Support for Multiple Variables

```csharp
public class AdvancedCalculator
{
    private Dictionary<string, IExpression> _expressions = [];

    public double Evaluate(string name, params (string var, double val)[] variables)
    {
        var expr = _expressions[name];
        return expr.Evaluate(variables);
    }
}

// Usage
calc.Store("Revenue2D", Algebra.X.Multiply(Algebra.Y));
double result = calc.Evaluate("Revenue2D", ("X", 25), ("Y", 100));  // $2500
```

### Add Simplification

```csharp
public void Simplify(string name)
{
    if (_expressions.TryGetValue(name, out var expr))
    {
        var simplified = expr.Simplify();
        _expressions[name] = simplified;
        Console.WriteLine($"Simplified: {simplified.ToLatex()}");
    }
}
```

### Add Expression Analysis

```csharp
public void AnalyzeExpression(string name)
{
    var expr = _expressions[name];
    var vars = expr.GetVariables();
    Console.WriteLine($"Variables: {string.Join(", ", vars)}");
    Console.WriteLine($"Constant: {expr.IsConstant}");
    Console.WriteLine($"LaTeX: {expr.ToLatex()}");
}
```

### Create Problem Solver

```csharp
public double? SolveForZero(string name, double startGuess, double tolerance = 0.0001)
{
    var expr = _expressions[name];
    // Implement Newton-Raphson or other numerical method
    for (int i = 0; i < 100; i++)
    {
        double fx = expr.Evaluate(x: startGuess);
        if (Math.Abs(fx) < tolerance)
            return startGuess;

        // Continue iteration...
    }
    return null;
}
```

---

## Sample Calculations

### Profit Margin Analysis
```csharp
var revenue = Algebra.X.Multiply(100);      // $100 per unit
var cost = Algebra.X.Multiply(60).Add(1000); // $60 + $1000 fixed
var profit = revenue.Subtract(cost);         // Profit

// Break-even: 100x - (60x + 1000) = 0
// 40x = 1000
// x = 25 units
```

### Quadratic Cost Optimization
```csharp
var cost = Algebra.X.Square()
    .Multiply(0.5)
    .Subtract(Algebra.X.Multiply(10))
    .Add(100);

// Find minimum by evaluating around optimal point
// Derivative: x - 10 = 0 → x = 10
```

### Compound Calculations
```csharp
// A = P(1 + r)^t
var principal = Algebra.Constant(1000);
var rate = Algebra.Constant(0.05);
var amount = principal.Multiply(
    Algebra.Constant(1).Add(rate).Power(Algebra.X)
);
```

---

## See Also

- [Manual: Getting Started](../../csharp/Manual/GettingStarted.md)
- [Manual: Advanced Topics](../../csharp/Manual/Advanced.md)
- [API Reference](../../csharp/Manual/API.md)
- [Use Case 1: Equation Solver](../UseCase1.EquationSolver/)
- [Use Case 2: LaTeX Generator](../UseCase2.LaTeXGenerator/)
