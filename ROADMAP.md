# Fluent.Algebra Roadmap
## From Middle School to Advanced High School Mathematics

**Mission:** Build a complete Computer Algebra System covering Swedish school curriculum (mellanstadiet → Gymnasiet Matte 5)

---

## Current Status: v0.1.0

### ✅ What Works Now
- Expression trees (constants, variables, binary/unary ops, functions)
- Fluent API for building expressions
- Evaluation with variable substitution
- Basic simplification (constant folding, identity rules)
- String and LaTeX formatting
- Functions: sin, cos, sqrt, ln, log, abs

### ⚠️ What's Missing
- Expression parser (parse strings → expressions)
- Equation solver
- Symbolic differentiation
- Symbolic integration
- More trigonometric functions
- Factorization
- Matrix operations
- Complex numbers

---

## 🎯 Phase 1: Högstadiet (100% Coverage)
**Target:** v0.3.0 - Q2 2025

### Prerequisites from Current System
- [x] Basic arithmetic operations
- [x] Variables and substitution
- [x] Pythagorean theorem expressions
- [x] Basic trigonometry (sin, cos)

### Missing Features for 100% Högstadiet

#### 1.1 Expression Parser ⭐ CRITICAL
**Why:** Students need to input `"3*x + 5"` instead of `Algebra.X.Multiply(3).Add(5)`

**Implementation:**
```csharp
// Target API:
var expr = Algebra.Parse("3*x^2 + 2*x + 1");
var result = expr.Evaluate("x", 5);

// With Expr wrapper (from v0.2.0):
Expr expr = "3*x^2 + 2*x + 1";  // Auto-parse!
var result = expr.Evaluate("x", 5);
```

**Components:**
- Lexer (tokenize input)
- Parser (build expression tree)
- Operator precedence handling
- Parentheses support
- Function parsing: `sin(x)`, `sqrt(x + 2)`
- Integration with Expr implicit operator

**Priority:** 🔴 HIGH (blocks everything else)

**Note:** Works seamlessly with v0.2.0 shortcuts!

---

#### 1.2 Linear Equation Solver
**Why:** Core högstadiet skill - solve `ax + b = 0`

**Implementation:**
```csharp
// Target API:
var equation = Algebra.Parse("2*x + 5");
var solutions = equation.Solve("x");  // x = -2.5

// Or with equals:
var eq = Algebra.Parse("2*x + 5 = 3");
var x = eq.Solve("x");  // x = -1
```

**Algorithm:**
- Isolate variable on one side
- Handle constants on other side
- Return solution(s)

**Priority:** 🟡 MEDIUM

---

#### 1.3 Quadratic Equation Solver
**Why:** Högstadiet curriculum - solve `ax² + bx + c = 0`

**Implementation:**
```csharp
// Target API:
var equation = Algebra.Parse("x^2 - 5*x + 6 = 0");
var solutions = equation.Solve("x");  // [2, 3]

// Show quadratic formula
var formula = QuadraticFormula.Display("a", "b", "c");
Console.WriteLine(formula.ToLaTeX());
```

**Algorithm:**
- Detect quadratic form
- Apply quadratic formula: `(-b ± √(b² - 4ac)) / 2a`
- Handle discriminant (0, positive, negative cases)
- Return real solutions (or complex if Ma2+ mode enabled)

**Priority:** 🟡 MEDIUM

---

#### 1.4 More Trigonometric Functions
**Why:** Complete trig coverage for högstadiet

**Implementation:**
```csharp
// Target functions:
Algebra.Tan(x)      // tangent
Algebra.Cot(x)      // cotangent (not common, but nice to have)
```

**Priority:** 🟢 LOW (nice to have)

---

#### 1.5 Percentage Calculations
**Why:** Common in everyday math and economics

**Implementation:**
```csharp
// Target API:
var percent = Algebra.PercentOf(Algebra.X, 25);  // 25% of x
var increase = Algebra.IncreaseByPercent(Algebra.X, 10);  // x * 1.10
var decrease = Algebra.DecreaseByPercent(Algebra.X, 15);  // x * 0.85
```

**Priority:** 🟢 LOW (can be done with existing operations)

---

### Högstadiet Milestone Checklist
- [ ] Parser implementation
- [ ] Linear equation solver
- [ ] Quadratic equation solver
- [ ] Tan function
- [ ] 20+ textbook examples verified
- [ ] Documentation with högstadiet examples

**Estimated completion:** v0.3.0 (8-10 weeks)

---

## 🎯 Phase 2: Gymnasiet Matte 1 (100% Coverage)
**Target:** v0.5.0 - Q3 2025

### Prerequisites
- [x] All högstadiet features
- [ ] Parser (from Phase 1)
- [ ] Equation solver (from Phase 1)

### New Features for Matte 1

#### 2.1 Polynomial Operations
**Why:** Core algebraic manipulation

**Implementation:**
```csharp
// Expansion
var expr = Algebra.Parse("(x + 2) * (x - 3)");
var expanded = expr.Expand();  // x² - x - 6

// Factorization
var poly = Algebra.Parse("x^2 - x - 6");
var factored = poly.Factor();  // (x + 2)(x - 3)
```

**Priority:** 🔴 HIGH

---

#### 2.2 System of Linear Equations
**Why:** Two equations, two unknowns

**Implementation:**
```csharp
// Target API:
var system = new EquationSystem();
system.Add("2*x + 3*y = 8");
system.Add("x - y = 1");
var solution = system.Solve();  // { x: 2.2, y: 1.2 }
```

**Algorithm:**
- Substitution method
- Elimination method
- Matrix representation (Gaussian elimination)

**Priority:** 🟡 MEDIUM

---

#### 2.3 Exponential and Logarithmic Functions
**Why:** exp/log relationship, logarithm laws

**Implementation:**
```csharp
// Already have: Algebra.Ln(x), Algebra.Log(x)

// Add:
Algebra.Exp(x)              // e^x
Algebra.Log(x, base)        // log_base(x)
Algebra.Pow(base, exponent) // base^exponent

// Simplification rules:
// ln(e^x) = x
// e^(ln(x)) = x
// log_b(b^x) = x
```

**Priority:** 🟡 MEDIUM

---

#### 2.4 Function Properties
**Why:** Analyze function behavior

**Implementation:**
```csharp
// Target API:
var f = Algebra.Parse("x^2 - 4*x + 3");

// Domain and range (basic cases)
var domain = f.GetDomain();  // "all real numbers" or intervals

// Zero points (where f(x) = 0)
var zeros = f.FindZeros();  // Solve f(x) = 0

// Symmetry detection
var symmetry = f.CheckSymmetry();  // "even", "odd", or "none"
```

**Priority:** 🟢 LOW

---

### Matte 1 Milestone Checklist
- [ ] Polynomial expansion
- [ ] Polynomial factorization
- [ ] System of linear equations solver
- [ ] Exp function
- [ ] Function analysis tools
- [ ] 30+ Matte 1 textbook examples
- [ ] Full Matte 1 chapter coverage

**Estimated completion:** v0.5.0 (12-14 weeks from Phase 1)

---

## 🎯 Phase 3: Gymnasiet Matte 2 (100% Coverage)
**Target:** v0.7.0 - Q4 2025

### Prerequisites
- [x] All Matte 1 features
- [ ] Polynomial operations
- [ ] Equation solver (quadratic+)

### New Features for Matte 2

#### 3.1 Symbolic Differentiation ⭐ GAME CHANGER
**Why:** Core calculus concept

**Implementation:**
```csharp
// Target API:
var f = Algebra.Parse("x^3 + 2*x^2 - 5*x + 3");
var derivative = f.Differentiate("x");  // 3x² + 4x - 5

// Chain rule
var g = Algebra.Parse("sin(x^2)");
var dg = g.Differentiate("x");  // 2x * cos(x²)

// Product rule
var h = Algebra.Parse("x * sin(x)");
var dh = h.Differentiate("x");  // sin(x) + x*cos(x)
```

**Differentiation Rules:**
- Power rule: `d/dx(x^n) = n*x^(n-1)`
- Sum/difference rule
- Product rule
- Quotient rule
- Chain rule
- Trigonometric derivatives
- Exponential/logarithmic derivatives

**Priority:** 🔴 CRITICAL

---

#### 3.2 Tangent Line Equations
**Why:** Geometric interpretation of derivative

**Implementation:**
```csharp
// Target API:
var f = Algebra.Parse("x^2");
var tangent = f.TangentLineAt("x", 2);  // y = 4x - 4
```

**Priority:** 🟡 MEDIUM

---

#### 3.3 Trigonometric Identities & Simplification
**Why:** Prove and simplify trig expressions

**Implementation:**
```csharp
// Target API:
var expr = Algebra.Parse("sin(x)^2 + cos(x)^2");
var simplified = expr.SimplifyTrigonometric();  // 1

// Common identities:
// sin²x + cos²x = 1
// tan x = sin x / cos x
// sin(2x) = 2 sin x cos x
// cos(2x) = cos²x - sin²x
```

**Priority:** 🟡 MEDIUM

---

#### 3.4 Inverse Trigonometric Functions
**Why:** Complete trig function family

**Implementation:**
```csharp
// Add functions:
Algebra.Asin(x)  // arcsin
Algebra.Acos(x)  // arccos
Algebra.Atan(x)  // arctan

// Derivatives:
// d/dx(arcsin x) = 1/√(1-x²)
// d/dx(arccos x) = -1/√(1-x²)
// d/dx(arctan x) = 1/(1+x²)
```

**Priority:** 🟢 LOW

---

### Matte 2 Milestone Checklist
- [ ] Symbolic differentiation (all rules)
- [ ] Tangent line calculator
- [ ] Trigonometric simplification
- [ ] Inverse trig functions
- [ ] 40+ Matte 2 examples
- [ ] Derivative verification tests

**Estimated completion:** v0.7.0 (16-20 weeks from Phase 2)

---

## 🎯 Phase 4: Gymnasiet Matte 3 (100% Coverage)
**Target:** v0.9.0 - Q1 2026

### Prerequisites
- [x] All Matte 2 features
- [ ] Symbolic differentiation

### New Features for Matte 3

#### 4.1 Symbolic Integration ⭐ MAJOR MILESTONE
**Why:** Antiderivative calculation

**Implementation:**
```csharp
// Target API:
var f = Algebra.Parse("x^2 + 2*x + 1");
var integral = f.Integrate("x");  // x³/3 + x² + x + C

// Definite integrals
var area = f.IntegrateDefinite("x", 0, 5);  // numeric result

// Substitution
var g = Algebra.Parse("2*x * sin(x^2)");
var ig = g.Integrate("x");  // -cos(x²) + C
```

**Integration Rules:**
- Power rule (reverse)
- Sum/difference rule
- Substitution method
- Integration by parts
- Trigonometric integrals
- Exponential/logarithmic integrals

**Priority:** 🔴 CRITICAL

---

#### 4.2 Area and Volume Calculations
**Why:** Applications of integration

**Implementation:**
```csharp
// Area between curves
var f = Algebra.Parse("x^2");
var g = Algebra.Parse("2*x");
var area = Integration.AreaBetween(f, g, 0, 2);

// Volume of revolution
var volume = Integration.VolumeOfRevolution(f, "x", 0, 2);
```

**Priority:** 🟡 MEDIUM

---

#### 4.3 Complex Numbers
**Why:** Extend number system, solve all quadratics

**Implementation:**
```csharp
// Target API:
var z1 = Complex.Create(3, 4);  // 3 + 4i
var z2 = Complex.Create(1, -2); // 1 - 2i

var sum = z1.Add(z2);      // 4 + 2i
var product = z1.Multiply(z2);  // 11 + -2i

// Polar form
var polar = z1.ToPolar();  // r * e^(iθ)

// Now quadratic solver can return complex roots:
var eq = Algebra.Parse("x^2 + 1 = 0");
var solutions = eq.Solve("x");  // [i, -i]
```

**Priority:** 🟡 MEDIUM

---

#### 4.4 Vectors (2D and 3D)
**Why:** Geometry and physics applications

**Implementation:**
```csharp
// Target API:
var v1 = Vector.Create(3, 4);
var v2 = Vector.Create(1, 2);

var sum = v1.Add(v2);
var dot = v1.DotProduct(v2);
var magnitude = v1.Magnitude();

// 3D vectors
var v3d = Vector.Create(1, 2, 3);
var cross = v3d.CrossProduct(Vector.Create(4, 5, 6));
```

**Priority:** 🟢 LOW

---

### Matte 3 Milestone Checklist
- [ ] Symbolic integration (basic rules)
- [ ] Definite integrals
- [ ] Area/volume calculations
- [ ] Complex number system
- [ ] Vector operations
- [ ] 50+ Matte 3 examples

**Estimated completion:** v0.9.0 (20-24 weeks from Phase 3)

---

## 🎯 Phase 5: Gymnasiet Matte 4 (100% Coverage)
**Target:** v1.1.0 - Q3 2026

### Prerequisites
- [x] All Matte 3 features
- [ ] Symbolic integration
- [ ] Vectors

### New Features for Matte 4

#### 5.1 Matrix Operations
**Why:** Linear algebra, systems of equations

**Implementation:**
```csharp
// Target API:
var A = Matrix.Create(new[,] {
    { 1, 2 },
    { 3, 4 }
});

var B = Matrix.Create(new[,] {
    { 5, 6 },
    { 7, 8 }
});

var sum = A.Add(B);
var product = A.Multiply(B);
var transpose = A.Transpose();
var determinant = A.Determinant();
var inverse = A.Inverse();

// Solve Ax = b
var x = Matrix.Solve(A, b);
```

**Priority:** 🔴 HIGH

---

#### 5.2 Partial Derivatives
**Why:** Multivariable calculus

**Implementation:**
```csharp
// Target API:
var f = Algebra.Parse("x^2 + x*y + y^2");
var df_dx = f.PartialDerivative("x");  // 2x + y
var df_dy = f.PartialDerivative("y");  // x + 2y

// Gradient
var gradient = f.Gradient(["x", "y"]);  // [2x+y, x+2y]
```

**Priority:** 🟡 MEDIUM

---

#### 5.3 Differential Equations (Basic)
**Why:** Solve dy/dx = f(x)

**Implementation:**
```csharp
// Target API:
var ode = DifferentialEquation.Parse("dy/dx = 2*x");
var solution = ode.Solve("y", "x");  // y = x² + C

// With initial condition
var particular = ode.SolveWithInitial("y", "x", y0: 1, x0: 0);
```

**Priority:** 🟢 LOW

---

### Matte 4 Milestone Checklist
- [ ] Matrix operations (add, mult, transpose)
- [ ] Determinant calculation
- [ ] Matrix inverse
- [ ] Partial derivatives
- [ ] Basic ODE solver
- [ ] 40+ Matte 4 examples

**Estimated completion:** v1.1.0 (12-16 weeks from Phase 4)

---

## 🎯 Phase 6: Gymnasiet Matte 5 (100% Coverage)
**Target:** v1.5.0 - Q4 2026

### Prerequisites
- [x] All Matte 4 features
- [ ] Matrix operations
- [ ] Partial derivatives

### New Features for Matte 5

#### 6.1 Advanced Integration Techniques
**Why:** Complete integration toolkit

**Implementation:**
- Integration by parts (full implementation)
- Partial fractions
- Trigonometric substitution
- Improper integrals
- Numerical integration (Simpson's rule, etc.)

**Priority:** 🔴 HIGH

---

#### 6.2 Sequences and Series
**Why:** Convergence, Taylor series

**Implementation:**
```csharp
// Target API:
var sequence = Sequence.Define("n^2 + 1");
var limit = sequence.Limit();

var series = Series.Create("1/n^2");
var convergence = series.TestConvergence();  // converges
var sum = series.Sum();  // π²/6

// Taylor series
var f = Algebra.Parse("sin(x)");
var taylor = f.TaylorSeries("x", center: 0, terms: 5);
```

**Priority:** 🟡 MEDIUM

---

#### 6.3 Vector Calculus
**Why:** Gradients, divergence, curl

**Implementation:**
```csharp
// Already have: Gradient (from Matte 4)

// Add:
var field = VectorField.Create("x*y", "y^2");
var divergence = field.Divergence();
var curl = field.Curl();
```

**Priority:** 🟢 LOW

---

#### 6.4 Advanced Differential Equations
**Why:** Second-order ODEs, systems

**Implementation:**
```csharp
// Second-order linear ODEs
var ode2 = DifferentialEquation.Parse("d²y/dx² + 2*dy/dx + y = 0");
var solution = ode2.Solve("y", "x");

// System of ODEs
var system = ODESystem.Create([
    "dx/dt = -y",
    "dy/dt = x"
]);
var solutions = system.Solve("t");
```

**Priority:** 🟢 LOW

---

### Matte 5 Milestone Checklist
- [ ] Advanced integration techniques
- [ ] Sequences and series
- [ ] Taylor series expansion
- [ ] Vector calculus operations
- [ ] Advanced ODE solving
- [ ] 50+ Matte 5 examples
- [ ] Full curriculum coverage

**Estimated completion:** v1.5.0 (16-20 weeks from Phase 5)

---

## 📊 Summary Timeline

| Phase | Target | Features | Duration | Total Time |
|-------|--------|----------|----------|------------|
| **Current** | v0.1.0 | Basic expressions, evaluation | - | - |
| **Phase 1** | v0.3.0 | Parser, equation solving (Högstadiet 100%) | 8-10 weeks | 2.5 months |
| **Phase 2** | v0.5.0 | Polynomials, systems (Matte 1 100%) | 12-14 weeks | 6 months |
| **Phase 3** | v0.7.0 | Differentiation, trig (Matte 2 100%) | 16-20 weeks | 11 months |
| **Phase 4** | v0.9.0 | Integration, complex, vectors (Matte 3 100%) | 20-24 weeks | 17 months |
| **Phase 5** | v1.1.0 | Matrices, partial derivatives (Matte 4 100%) | 12-16 weeks | 21 months |
| **Phase 6** | v1.5.0 | Advanced integration, series (Matte 5 100%) | 16-20 weeks | 25 months |

**Total estimated time: ~2 years from v0.1.0 to full Matte 5 coverage**

---

## 🎯 Quick Wins (Can Be Done Now)

### v0.2.0 - Immediate Improvements ⭐ SHORTCUTS!

#### Developer Experience Improvements (PRIORITY 🔴)

**1. Operator Overloading**
```csharp
// Target syntax:
IAlgebraExpression x = "x";
var expr = (x + 2).Square() / 3;  // Instead of x.Add(2).Square().Divide(3)
```

**Implementation:**
- Add `+`, `-`, `*`, `/` operators to IAlgebraExpression
- Add unary `-` for negation
- Works with implicit conversions
- Zero performance overhead

**Time:** 1-2 days

---

**2. Type Aliases (Multiple Options)**

**Option A: Global Using (Recommended)**
```csharp
// In GlobalUsings.cs (project root):
global using Expr = MarcusMedina.Fluent.Algebra.Interfaces.IAlgebraExpression;

// Usage anywhere:
Expr x = "x";
Expr area = "a*b";  // When parser ready
```

**Option B: Per-File Using**
```csharp
// Top of each file:
using Expr = MarcusMedina.Fluent.Algebra.Interfaces.IAlgebraExpression;

// Then use:
Expr x = "x";
```

**Option C: Wrapper Type (CLEANEST!)**
```csharp
// Generator creates:
public readonly struct Expr
{
    // Implicit from string (variable or parse)
    public static implicit operator Expr(string input);

    // Implicit from numbers
    public static implicit operator Expr(double value);

    // All operators
    public static Expr operator +(Expr left, Expr right);
    // ... etc

    // Convert to IAlgebraExpression
    public static implicit operator IAlgebraExpression(Expr e);
}

// Usage - PERFECT:
Expr x = "x";
Expr area = "a*b";
var result = (x + 2).Square();
```

**Recommendation:** Implement Option C (Expr wrapper) - gives best DX!

**Time:** 2-3 days

---

**3. Implicit String Conversions**
```csharp
// When parser ready (v0.3.0):
Expr area = "a*b";  // Auto-parse!

// Before parser (v0.2.0):
Expr x = "x";       // Variable only (single identifier)
```

**Smart detection:**
- If string matches `^[a-zA-Z_]\w*$` → Variable
- Otherwise → Parse (when available)

**Time:** 1 day (after parser)

---

**Summary - Developer Experience:**
```csharp
// v0.1.0 (NOW):
var expr = Algebra.X.Add(2).Square().Divide(3);

// v0.2.0 (WITH SHORTCUTS):
Expr x = "x";
var expr = (x + 2).Square() / 3;

// v0.3.0 (WITH PARSER):
Expr expr = "(x+2)^2/3";
```

**MASSIVE improvement!** 🚀

---

#### Static Variable Shortcuts
- [ ] Generate `Vars` static class with A-Z properties
- [ ] Add common subscripted variables (X1, X2, Y1, Y2, etc.)
- [ ] Add common Greek letters (Alpha, Beta, Theta, etc.)
- [ ] Document usage with `using static`

**Priority:** 🟢 LOW (nice to have)

---

#### Math Functions
- [ ] Add more trig functions (tan, cot, sec, csc)
- [ ] Add inverse trig (asin, acos, atan)
- [ ] Add exp function
- [ ] Improve simplification rules
- [ ] Better error messages

**Time:** 2-3 weeks total (including shortcuts)

---

## 📚 Documentation & Testing Strategy

### Per Phase Deliverables
- [ ] API documentation (XML comments)
- [ ] Usage examples for each feature
- [ ] Unit tests (95%+ coverage)
- [ ] Integration tests with textbook examples
- [ ] Performance benchmarks
- [ ] Migration guide (if breaking changes)

### Textbook Verification
Each phase must pass verification against:
- [ ] Real Swedish math textbooks
- [ ] 20-50 worked examples per phase
- [ ] Edge cases and corner cases
- [ ] Student-level explanations in docs

---

## 🤝 Community & Contribution

### Open for Contributions
- Parser implementation (Phase 1)
- Equation solvers (Phase 1-2)
- Differentiation rules (Phase 3)
- Integration algorithms (Phase 4-5)
- Matrix operations (Phase 5)

### Documentation Needed
- "Building a CAS in C#" tutorial series
- Educational blog posts
- Video tutorials
- Sample lessons for teachers

---

## 🎓 Educational Impact

### Target Audience
- **Students**: Interactive learning tool
- **Teachers**: Demonstration and verification
- **Developers**: Learn CAS implementation
- **Researchers**: Foundation for advanced tools

### Use Cases
- Homework verification
- Step-by-step solutions (with future work)
- Interactive math notebooks
- Educational games
- Formula editors

---

## 🚀 Beyond Matte 5

### Future Possibilities (v2.0+)
- Step-by-step solution explanations
- 3D plotting and visualization
- Statistics and probability
- Linear programming
- Symbolic logic
- Computer algebra tricks (Gröbner bases, etc.)

---

**Last updated:** 2025-01-19
**Current version:** v0.1.0
**Next milestone:** v0.2.0 (Quick wins) → v0.3.0 (Högstadiet 100%)
