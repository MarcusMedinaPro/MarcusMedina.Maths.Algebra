using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;

// Problem: Solve quadratic equations programmatically
// This demonstrates building equations, evaluating them, and finding roots

Console.WriteLine("=== Quadratic Equation Solver ===\n");

// Build quadratic equation: ax² + bx + c = 0
// We'll use: x² - 5x + 6 = 0

var a = 1.0;
var b = -5.0;
var c = 6.0;

// Build the equation expression
var equation = Algebra.X
    .Square()
    .Multiply(a)
    .Add(Algebra.X.Multiply(b))
    .Add(c);

Console.WriteLine($"Equation: {a}x² + {b}x + {c} = 0");
Console.WriteLine($"Expression: {equation}\n");

// Find roots using quadratic formula: x = (-b ± √(b² - 4ac)) / 2a
var discriminant = b * b - 4 * a * c;
var root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
var root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

Console.WriteLine($"Discriminant: {discriminant}");
Console.WriteLine($"Root 1: x = {root1}");
Console.WriteLine($"Root 2: x = {root2}\n");

// Verify solutions by evaluating the equation at the roots
Console.WriteLine("Verification (should be ~0):");
var result1 = equation.Evaluate("x", root1);
var result2 = equation.Evaluate("x", root2);
Console.WriteLine($"f({root1}) = {result1:F10}");
Console.WriteLine($"f({root2}) = {result2:F10}\n");

// Show the LaTeX representation
var latex = equation.ToLatex();
Console.WriteLine($"LaTeX: {latex}");
