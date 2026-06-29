namespace MarcusMedina.Maths.Algebra.Tests.Evaluators;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Builders;
using MarcusMedina.Maths.Algebra.Evaluators;
using MarcusMedina.Maths.Algebra.Extensions;
using Xunit;

public class AlgebraEvaluatorTests
{
    [Fact]
    public void Evaluate_WithVariableName_SubstitutesCorrectly()
    {
        var expr = Algebra.X.Multiply(2).Add(1);
        expr.Evaluate("x", 5).Should().Be(11);
    }

    [Fact]
    public void Evaluate_WithDictionary_SubstitutesCorrectly()
    {
        var expr = Algebra.X.Add(Algebra.Y);
        var result = expr.Evaluate(new Dictionary<string, double> { ["x"] = 3, ["y"] = 4 });
        result.Should().Be(7);
    }

    [Fact]
    public void EvaluateRange_ThreeSteps_ProducesCorrectValues()
    {
        // f(x) = x at x = 0, 1, 2
        var expr = Algebra.X;
        var results = expr.EvaluateRange("x", 0, 2, 3).ToList();
        results.Should().HaveCount(3);
        results[0].Should().Be(0);
        results[1].Should().Be(1);
        results[2].Should().Be(2);
    }

    [Fact]
    public void EvaluateRange_ConstantExpression_ReturnsConstantForAllPoints()
    {
        var expr = Algebra.Constant(5);
        var results = expr.EvaluateRange("x", 0, 10, 5).ToList();
        results.Should().AllSatisfy(v => v.Should().Be(5));
    }

    [Fact]
    public void EvaluateRange_QuadraticExpression_EvaluatesAtEachPoint()
    {
        // f(x) = x^2 at x=0,1,2
        var expr = Algebra.X.Square();
        var results = expr.EvaluateRange("x", 0, 2, 3).ToList();
        results[0].Should().Be(0);
        results[1].Should().Be(1);
        results[2].Should().Be(4);
    }
}
