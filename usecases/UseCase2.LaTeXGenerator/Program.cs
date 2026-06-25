using MarcusMedina.Fluent.Algebra;
using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;

// Problem: Generate publication-ready LaTeX notation from algebraic expressions
// This demonstrates converting programmatic expressions to mathematical typesetting format

Console.OutputEncoding = System.Text.Encoding.UTF8; // Enable emoji support

Console.WriteLine("=== LaTeX Generator for Mathematical Expressions ===\n");

// Example 1: Simple expression
Console.WriteLine("Example 1: Simple Linear Expression");
var expr1 = Algebra.X.Multiply(2).Add(3);
Console.WriteLine($"Expression: 2x + 3");
Console.WriteLine($"LaTeX:      {expr1.ToLatex()}\n");

// Example 2: Quadratic with fractions
Console.WriteLine("Example 2: Quadratic Expression");
var expr2 = Algebra.X
    .Square()
    .Multiply(2)
    .Add(Algebra.X.Multiply(5))
    .Subtract(3);
Console.WriteLine($"Expression: 2x² + 5x - 3");
Console.WriteLine($"LaTeX:      {expr2.ToLatex()}\n");

// Example 3: Complex fraction
Console.WriteLine("Example 3: Complex Fraction");
var numerator = Algebra.X.Add(2).Square();
var denominator = Algebra.X.Subtract(1);
var expr3 = numerator.Divide(denominator);
Console.WriteLine($"Expression: (x + 2)² / (x - 1)");
Console.WriteLine($"LaTeX:      {expr3.ToLatex()}\n");

// Example 4: Multiple variables
Console.WriteLine("Example 4: Multiple Variables");
var expr4 = Algebra.X.Square()
    .Add(Algebra.Y.Square());
Console.WriteLine($"Expression: x² + y²");
Console.WriteLine($"LaTeX:      {expr4.ToLatex()}\n");

// Example 5: Nested operations
Console.WriteLine("Example 5: Nested Operations");
var expr5 = Algebra.X
    .Add(1)
    .Multiply(Algebra.X.Subtract(1));
Console.WriteLine($"Expression: (x + 1)(x - 1)");
Console.WriteLine($"LaTeX:      {expr5.ToLatex()}\n");

// Example 6: Generate LaTeX document snippet
Console.WriteLine("Example 6: LaTeX Document Snippet");
Console.WriteLine(@"\documentclass{article}");
Console.WriteLine(@"\usepackage{amsmath}");
Console.WriteLine(@"\begin{document}");
Console.WriteLine(@"\section{Mathematical Expressions}");
Console.WriteLine();

var documentExpressions = new (string description, IExpression expr)[]
{
    ("Linear function", Algebra.X.Multiply(3).Add(2)),
    ("Parabola", Algebra.X.Square().Subtract(4)),
    ("Rational function", Algebra.X.Divide(Algebra.X.Square().Subtract(1))),
};

foreach (var (desc, expr) in documentExpressions)
{
    Console.WriteLine($@"\subsection{{{desc}}}");
    Console.WriteLine($@"$$" + expr.ToLatex() + @"$$");
    Console.WriteLine();
}

Console.WriteLine(@"\end{document}");
