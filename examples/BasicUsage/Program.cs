using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;
using MarcusMedina.Fluent.Maths.Algebra.Extensions;

Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable emoji support

Console.WriteLine("🧮 Fluent.Algebra - Basic Usage Examples\n");

// ══════════════════════════════════════════════════════════════
// Example 1: Simple Expression
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 1: Simple Expression (x + 5)");
var expr1 = Algebra.X.Add(5);
Console.WriteLine($"Expression: {expr1}");
Console.WriteLine($"LaTeX: {expr1.ToLaTeX()}");
Console.WriteLine($"x=10: {expr1.Evaluate("x", 10)}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 2: Quadratic Expression
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 2: Quadratic (x + 2)² / 3");
var expr2 = Algebra.X
    .Add(2)
    .Square()
    .Divide(3);

Console.WriteLine($"Expression: {expr2}");
Console.WriteLine($"LaTeX: {expr2.ToLaTeX()}");
Console.WriteLine($"x=5: {expr2.Evaluate("x", 5):F3}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 3: Multiple Variables
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 3: Multiple Variables (2x + 3y - z)");
var expr3 = Algebra.X
    .Multiply(2)
    .Add(Algebra.Y.Multiply(3))
    .Subtract(Algebra.Z);

Console.WriteLine($"Expression: {expr3}");
Console.WriteLine($"LaTeX: {expr3.ToLaTeX()}");

var vars = new Dictionary<string, double>
{
    ["x"] = 4,
    ["y"] = 2,
    ["z"] = 1
};
Console.WriteLine($"x=4, y=2, z=1: {expr3.Evaluate(vars)}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 4: Functions (Trigonometry)
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 4: Trigonometry (sin²(x) + cos²(x))");
var sin = Algebra.Sin(Algebra.X);
var cos = Algebra.Cos(Algebra.X);
var identity = sin.Square().Add(cos.Square());

Console.WriteLine($"Expression: {identity}");
Console.WriteLine($"LaTeX: {identity.ToLaTeX()}");
Console.WriteLine($"x=π/4: {identity.Evaluate("x", Math.PI / 4):F6}");
Console.WriteLine($"x=π/2: {identity.Evaluate("x", Math.PI / 2):F6}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 5: Distance Formula
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 5: Distance Formula √((x₂-x₁)² + (y₂-y₁)²)");
var distance = Algebra.Var("x2")
    .Subtract(Algebra.Var("x1"))
    .Square()
    .Add(
        Algebra.Var("y2")
            .Subtract(Algebra.Var("y1"))
            .Square()
    );
var distanceFormula = Algebra.Sqrt(distance);

Console.WriteLine($"Expression: {distanceFormula}");
Console.WriteLine($"LaTeX: {distanceFormula.ToLaTeX()}");

var points = new Dictionary<string, double>
{
    ["x1"] = 0, ["y1"] = 0,
    ["x2"] = 3, ["y2"] = 4
};
Console.WriteLine($"(0,0) to (3,4): {distanceFormula.Evaluate(points)}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 6: Substitution
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 6: Variable Substitution");
var expr6 = Algebra.X.Square().Add(Algebra.X.Multiply(2)).Add(1);
Console.WriteLine($"Original: {expr6}");
Console.WriteLine($"LaTeX: {expr6.ToLaTeX()}");

var substituted = expr6.Substitute("x", 5);
Console.WriteLine($"After x=5: {substituted}");
Console.WriteLine($"Result: {substituted.Evaluate()}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 7: Simplification
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 7: Expression Simplification");
var expr7 = Algebra.X.Multiply(1).Add(0).Multiply(2);
Console.WriteLine($"Before: {expr7}");

var simplified = expr7.Simplify();
Console.WriteLine($"After: {simplified}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
// Example 8: Complex Expression
// ══════════════════════════════════════════════════════════════
Console.WriteLine("📌 Example 8: Complex Expression");
var complex = Algebra.Sqrt(
    Algebra.X.Square()
        .Add(Algebra.Y.Square())
)
.Multiply(
    Algebra.Sin(Algebra.Z)
)
.Divide(2);

Console.WriteLine($"Expression: {complex}");
Console.WriteLine($"LaTeX: {complex.ToLaTeX()}");

var complexVars = new Dictionary<string, double>
{
    ["x"] = 3,
    ["y"] = 4,
    ["z"] = Math.PI / 6
};
Console.WriteLine($"x=3, y=4, z=π/6: {complex.Evaluate(complexVars):F3}");
Console.WriteLine();

// ══════════════════════════════════════════════════════════════
Console.WriteLine("✨ Done! Try building your own expressions!");
