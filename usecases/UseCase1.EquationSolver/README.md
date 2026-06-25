# Use Case 1: Quadratic Equation Solver

**Problem Solved:** Build and solve quadratic equations programmatically

This example demonstrates how to use MarcusMedina.Fluent.Algebra to construct quadratic equations algebraically and find their solutions.

---

## The Problem

You need to:
- Build quadratic equations (ax² + bx + c) programmatically
- Evaluate equations at specific x values
- Find equation roots using the quadratic formula
- Verify solutions
- Convert equations to mathematical notation

---

## The Solution

```csharp
// Build equation: x² - 5x + 6 = 0
var equation = Algebra.X
    .Square()
    .Multiply(1)
    .Add(Algebra.X.Multiply(-5))
    .Add(6);

// Find roots
var discriminant = 25 - 24;  // b² - 4ac
var root1 = (5 + Math.Sqrt(discriminant)) / 2;  // 3
var root2 = (5 - Math.Sqrt(discriminant)) / 2;  // 2

// Verify
Console.WriteLine(equation.Evaluate(x: 3));  // 0 ✓
Console.WriteLine(equation.Evaluate(x: 2));  // 0 ✓
```

---

## How to Run

```bash
cd usecases/UseCase1.EquationSolver
dotnet run
```

**Expected Output:**
```
=== Quadratic Equation Solver ===

Equation: 1x² + -5x + 6 = 0
Expression: Add(Add(Multiply(Square(X), 1), Multiply(X, -5)), 6)

Discriminant: 1
Root 1: x = 3
Root 2: x = 2

Verification (should be ~0):
f(3) = 0.0000000000
f(2) = 0.0000000000

LaTeX: x^{2} - 5x + 6
```

---

## Key Features Demonstrated

✅ **Expression Building** - Construct equations using fluent API
✅ **Evaluation** - Test if values satisfy the equation
✅ **Mathematical Operations** - Power, multiply, add
✅ **LaTeX Export** - Convert to publication-ready format
✅ **Verification** - Confirm solutions are correct

---

## Real-World Applications

- **Physics**: Solve motion equations (v = u + at, s = ut + ½at²)
- **Engineering**: Analyze parabolic structures and trajectories
- **Finance**: Calculate break-even points in cost-benefit analysis
- **Education**: Build math teaching tools and problem generators

---

## How It Works

1. **Build Expression** - Chain operations to create ax² + bx + c
2. **Calculate Discriminant** - b² - 4ac determines solution type
3. **Apply Quadratic Formula** - x = (-b ± √discriminant) / 2a
4. **Verify Results** - Evaluate equation at roots (should equal ~0)
5. **Export Notation** - Convert to LaTeX for documentation

---

## Extending This Example

**Solve other polynomial equations:**
```csharp
// Cubic: x³ + 2x² - x + 5 = 0
var cubic = Algebra.X
    .Cube()
    .Add(Algebra.X.Square().Multiply(2))
    .Subtract(Algebra.X)
    .Add(5);
```

**Find vertex of parabola:**
```csharp
// Vertex x-coordinate: -b / 2a
var vertexX = -b / (2 * a);
var vertexY = equation.Evaluate(x: vertexX);
```

**Analyze function behavior:**
```csharp
// Evaluate at multiple points
for (double x = -2; x <= 5; x += 0.5)
{
    Console.WriteLine($"f({x}) = {equation.Evaluate(x: x)}");
}
```

---

## See Also

- [Manual: Getting Started](../../csharp/Manual/GettingStarted.md)
- [Manual: Building Expressions](../../csharp/Manual/Examples/Example1_BuildingExpressions.md)
- [Use Case 2: LaTeX Generator](../UseCase2.LaTeXGenerator/)
- [Use Case 3: Symbolic Calculator](../UseCase3.SymbolicCalculator/)
