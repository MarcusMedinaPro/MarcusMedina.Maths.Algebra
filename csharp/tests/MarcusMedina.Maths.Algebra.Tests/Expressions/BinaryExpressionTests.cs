namespace MarcusMedina.Maths.Algebra.Tests.Expressions;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Builders;
using MarcusMedina.Maths.Algebra.Expressions;
using MarcusMedina.Maths.Algebra.Interfaces;
using Xunit;

public class BinaryExpressionTests
{
    private static IAlgebraExpression Const(double v) => Algebra.Constant(v);

    [Fact]
    public void Add_EvaluatesSum()
    {
        Algebra.Add(Const(3), Const(4)).Evaluate().Should().Be(7);
    }

    [Fact]
    public void Subtract_EvaluatesDifference()
    {
        Algebra.Subtract(Const(10), Const(3)).Evaluate().Should().Be(7);
    }

    [Fact]
    public void Multiply_EvaluatesProduct()
    {
        Algebra.Multiply(Const(3), Const(4)).Evaluate().Should().Be(12);
    }

    [Fact]
    public void Divide_EvaluatesQuotient()
    {
        Algebra.Divide(Const(12), Const(4)).Evaluate().Should().Be(3);
    }

    [Fact]
    public void Divide_ByZero_ThrowsDivideByZeroException()
    {
        var expr = Algebra.Divide(Const(1), Const(0));
        var act = () => expr.Evaluate();
        act.Should().Throw<DivideByZeroException>();
    }

    [Fact]
    public void Power_EvaluatesExponentiation()
    {
        Algebra.Power(Const(2), Const(10)).Evaluate().Should().Be(1024);
    }

    [Fact]
    public void Power_ZeroExponent_ReturnsOne()
    {
        Algebra.Power(Const(99), Const(0)).Evaluate().Should().Be(1);
    }

    [Fact]
    public void ToString_AddExpression_FormatsWithPlus()
    {
        Algebra.Add(Const(2), Const(3)).ToString().Should().Be("(2 + 3)");
    }

    [Fact]
    public void ToString_DivideExpression_FormatsWithSlash()
    {
        Algebra.Divide(Const(6), Const(2)).ToString().Should().Be("(6 / 2)");
    }

    [Fact]
    public void ToLaTeX_Division_UsesFracNotation()
    {
        Algebra.Divide(Const(1), Const(2)).ToLaTeX().Should().Contain("frac");
    }

    [Fact]
    public void ToLaTeX_Power_UsesCaret()
    {
        Algebra.Power(Const(2), Const(3)).ToLaTeX().Should().Contain("^");
    }

    [Fact]
    public void ToLaTeX_Multiply_UsesCdot()
    {
        Algebra.Multiply(Const(2), Const(3)).ToLaTeX().Should().Contain(@"\cdot");
    }

    [Fact]
    public void Simplify_ConstantFolding_EvaluatesConstants()
    {
        var expr = new BinaryExpression(Const(3), BinaryOperator.Add, Const(4));
        var simplified = expr.Simplify();
        simplified.Should().BeOfType<ConstantExpression>();
        simplified.Evaluate().Should().Be(7);
    }

    [Fact]
    public void Simplify_AddZero_ReturnsOtherOperand()
    {
        var expr = new BinaryExpression(Algebra.X, BinaryOperator.Add, Const(0));
        var simplified = expr.Simplify();
        simplified.Should().BeOfType<VariableExpression>();
    }

    [Fact]
    public void Simplify_MultiplyByOne_ReturnsOtherOperand()
    {
        var expr = new BinaryExpression(Algebra.X, BinaryOperator.Multiply, Const(1));
        var simplified = expr.Simplify();
        simplified.Should().BeOfType<VariableExpression>();
    }

    [Fact]
    public void Simplify_MultiplyByZero_ReturnsZero()
    {
        var expr = new BinaryExpression(Algebra.X, BinaryOperator.Multiply, Const(0));
        var simplified = expr.Simplify();
        simplified.Should().BeOfType<ConstantExpression>();
        simplified.Evaluate().Should().Be(0);
    }

    [Fact]
    public void Substitute_ReplacesVariable()
    {
        var expr = new BinaryExpression(Algebra.X, BinaryOperator.Add, Const(1));
        var substituted = expr.Substitute("x", 5);
        substituted.Evaluate().Should().Be(6);
    }
}
