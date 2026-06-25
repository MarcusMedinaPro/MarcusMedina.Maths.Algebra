namespace MarcusMedina.Fluent.Maths.Algebra.Tests.Integration;

using FluentAssertions;
using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Evaluators;
using MarcusMedina.Fluent.Maths.Algebra.Extensions;
using Xunit;

public class FluentChainTests
{
    [Fact]
    public void QuadraticExpression_EvaluatesCorrectly()
    {
        // Arrange: (x + 2)^2 / 3
        var expr = Algebra.X
            .Add(2)
            .Square()
            .Divide(3);

        // Act
        var result = expr.Evaluate("x", 5);

        // Assert
        result.Should().BeApproximately(16.333, 0.001);
    }

    [Fact]
    public void ComplexExpression_WithMultipleVariables()
    {
        // Arrange: 2x + 3y - z
        var expr = Algebra.X
            .Multiply(2)
            .Add(Algebra.Y.Multiply(3))
            .Subtract(Algebra.Z);

        var vars = new Dictionary<string, double>
        {
            ["x"] = 4,
            ["y"] = 2,
            ["z"] = 1
        };

        // Act
        var result = expr.Evaluate(vars);

        // Assert
        result.Should().Be(13); // 2*4 + 3*2 - 1 = 13
    }

    [Fact]
    public void DistanceFormula_EvaluatesCorrectly()
    {
        // Arrange: sqrt((x2-x1)^2 + (y2-y1)^2)
        var distance = Algebra.Var("x2")
            .Subtract(Algebra.Var("x1"))
            .Square()
            .Add(
                Algebra.Var("y2")
                    .Subtract(Algebra.Var("y1"))
                    .Square()
            );

        var expr = Algebra.Sqrt(distance);

        var vars = new Dictionary<string, double>
        {
            ["x1"] = 0,
            ["y1"] = 0,
            ["x2"] = 3,
            ["y2"] = 4
        };

        // Act
        var result = expr.Evaluate(vars);

        // Assert
        result.Should().Be(5); // 3-4-5 triangle
    }

    [Fact]
    public void SubstitutionChain_WorksCorrectly()
    {
        // Arrange: x^2 + 2x + 1
        var expr = Algebra.X.Square()
            .Add(Algebra.X.Multiply(2))
            .Add(1);

        // Act: Substitute x = 5
        var substituted = expr.Substitute("x", 5);
        var result = substituted.Evaluate();

        // Assert
        result.Should().Be(36); // 25 + 10 + 1
    }

    [Fact]
    public void SimplificationChain_ReducesExpression()
    {
        // Arrange: x * 1 + 0 * 2
        var expr = Algebra.X
            .Multiply(1)
            .Add(
                Algebra.Constant(0).Multiply(2)
            );

        // Act
        var simplified = expr.Simplify();

        // Assert
        simplified.ToString().Should().Be("x");
    }

    [Fact]
    public void LaTeXExport_FormatsCorrectly()
    {
        // Arrange: (x + 2)^2 / 3
        var expr = Algebra.X
            .Add(2)
            .Power(2)
            .Divide(3);

        // Act
        var latex = expr.ToLaTeX();

        // Assert
        latex.Should().Contain("frac");
        latex.Should().Contain("^");
    }

    [Fact]
    public void TrigonometricIdentity_VerifiesCorrectly()
    {
        // Arrange: sin^2(x) + cos^2(x)
        var expr = Algebra.Sin(Algebra.X).Square()
            .Add(Algebra.Cos(Algebra.X).Square());

        // Act
        var result = expr.Evaluate("x", Math.PI / 4);

        // Assert
        result.Should().BeApproximately(1.0, 0.0001);
    }
}
