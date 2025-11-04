namespace MarcusMedina.Fluent.Algebra.Tests.Expressions;

using FluentAssertions;
using MarcusMedina.Fluent.Algebra.Expressions;
using Xunit;

public class VariableExpressionTests
{
    [Fact]
    public void Constructor_ValidName_CreatesVariable()
    {
        // Act
        var expr = new VariableExpression("x");

        // Assert
        expr.Name.Should().Be("x");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Constructor_InvalidName_ThrowsArgumentException(string? name)
    {
        // Act
        var act = () => new VariableExpression(name!);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Evaluate_WithVariable_ReturnsValue()
    {
        // Arrange
        var expr = new VariableExpression("x");
        var variables = new Dictionary<string, double> { ["x"] = 42 };

        // Act
        var result = expr.Evaluate(variables);

        // Assert
        result.Should().Be(42);
    }

    [Fact]
    public void Evaluate_WithoutVariable_ThrowsInvalidOperationException()
    {
        // Arrange
        var expr = new VariableExpression("x");

        // Act
        var act = () => expr.Evaluate();

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*x*not defined*");
    }

    [Fact]
    public void ToString_ReturnsVariableName()
    {
        // Arrange
        var expr = new VariableExpression("alpha");

        // Act
        var result = expr.ToString();

        // Assert
        result.Should().Be("alpha");
    }

    [Fact]
    public void ToLaTeX_ReturnsVariableName()
    {
        // Arrange
        var expr = new VariableExpression("beta");

        // Act
        var result = expr.ToLaTeX();

        // Assert
        result.Should().Be("beta");
    }

    [Fact]
    public void Substitute_MatchingVariable_ReturnsConstant()
    {
        // Arrange
        var expr = new VariableExpression("x");

        // Act
        var substituted = expr.Substitute("x", 10);

        // Assert
        substituted.Should().BeOfType<ConstantExpression>();
        substituted.Evaluate().Should().Be(10);
    }

    [Fact]
    public void Substitute_DifferentVariable_ReturnsUnchanged()
    {
        // Arrange
        var expr = new VariableExpression("x");

        // Act
        var substituted = expr.Substitute("y", 10);

        // Assert
        substituted.Should().BeSameAs(expr);
    }

    [Fact]
    public void Substitute_WithExpression_ReturnsExpression()
    {
        // Arrange
        var expr = new VariableExpression("x");
        var replacement = new ConstantExpression(5);

        // Act
        var substituted = expr.Substitute("x", replacement);

        // Assert
        substituted.Should().BeSameAs(replacement);
    }

    [Fact]
    public void Simplify_ReturnsUnchanged()
    {
        // Arrange
        var expr = new VariableExpression("x");

        // Act
        var simplified = expr.Simplify();

        // Assert
        simplified.Should().BeSameAs(expr);
    }
}
