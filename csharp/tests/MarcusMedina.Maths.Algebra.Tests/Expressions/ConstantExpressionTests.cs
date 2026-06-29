namespace MarcusMedina.Maths.Algebra.Tests.Expressions;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Expressions;
using Xunit;

public class ConstantExpressionTests
{
    [Fact]
    public void Evaluate_WithoutVariables_ReturnsConstantValue()
    {
        // Arrange
        var expr = new ConstantExpression(42);

        // Act
        var result = expr.Evaluate();

        // Assert
        result.Should().Be(42);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(-1)]
    [InlineData(3.14159)]
    [InlineData(-273.15)]
    public void Evaluate_VariousConstants_ReturnsCorrectValue(double value)
    {
        // Arrange
        var expr = new ConstantExpression(value);

        // Act
        var result = expr.Evaluate();

        // Assert
        result.Should().Be(value);
    }

    [Fact]
    public void ToString_ReturnsNumericString()
    {
        // Arrange
        var expr = new ConstantExpression(42.5);

        // Act
        var result = expr.ToString();

        // Assert
        result.Should().Be("42.5");
    }

    [Fact]
    public void ToLaTeX_ReturnsNumericString()
    {
        // Arrange
        var expr = new ConstantExpression(3.14);

        // Act
        var result = expr.ToLaTeX();

        // Assert
        result.Should().Be("3.14");
    }

    [Fact]
    public void Substitute_ReturnsUnchanged()
    {
        // Arrange
        var expr = new ConstantExpression(10);

        // Act
        var substituted = expr.Substitute("x", 5);

        // Assert
        substituted.Should().BeSameAs(expr);
    }

    [Fact]
    public void Simplify_ReturnsUnchanged()
    {
        // Arrange
        var expr = new ConstantExpression(7);

        // Act
        var simplified = expr.Simplify();

        // Assert
        simplified.Should().BeSameAs(expr);
    }

    [Fact]
    public void ImplicitConversion_FromDouble_CreatesConstant()
    {
        // Act
        ConstantExpression expr = 42.0;

        // Assert
        expr.Value.Should().Be(42.0);
    }

    [Fact]
    public void ImplicitConversion_FromInt_CreatesConstant()
    {
        // Act
        ConstantExpression expr = 42;

        // Assert
        expr.Value.Should().Be(42.0);
    }
}
