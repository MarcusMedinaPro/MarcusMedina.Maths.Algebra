namespace MarcusMedina.Fluent.Maths.Algebra.Tests.Builders;

using FluentAssertions;
using MarcusMedina.Fluent.Maths.Algebra.Builders;
using MarcusMedina.Fluent.Maths.Algebra.Expressions;
using Xunit;

public class AlgebraBuilderTests
{
    [Fact]
    public void Constant_CreatesConstantExpression()
    {
        // Act
        var expr = Algebra.Constant(42);

        // Assert
        expr.Should().BeOfType<ConstantExpression>();
        expr.Evaluate().Should().Be(42);
    }

    [Fact]
    public void Variable_CreatesVariableExpression()
    {
        // Act
        var expr = Algebra.Variable("x");

        // Assert
        expr.Should().BeOfType<VariableExpression>();
        expr.ToString().Should().Be("x");
    }

    [Fact]
    public void Var_CreatesVariableExpression()
    {
        // Act
        var expr = Algebra.Var("y");

        // Assert
        expr.Should().BeOfType<VariableExpression>();
        expr.ToString().Should().Be("y");
    }

    [Theory]
    [InlineData("x")]
    [InlineData("y")]
    [InlineData("z")]
    public void CommonVariables_CreateCorrectVariables(string expectedName)
    {
        // Act
        var expr = expectedName switch
        {
            "x" => Algebra.X,
            "y" => Algebra.Y,
            "z" => Algebra.Z,
            _ => throw new ArgumentException()
        };

        // Assert
        expr.Should().BeOfType<VariableExpression>();
        expr.ToString().Should().Be(expectedName);
    }

    [Fact]
    public void Add_CreatesBinaryExpression()
    {
        // Arrange
        var left = Algebra.Constant(3);
        var right = Algebra.Constant(4);

        // Act
        var expr = Algebra.Add(left, right);

        // Assert
        expr.Should().BeOfType<BinaryExpression>();
        expr.Evaluate().Should().Be(7);
    }

    [Fact]
    public void Multiply_CreatesBinaryExpression()
    {
        // Arrange
        var left = Algebra.Constant(3);
        var right = Algebra.Constant(4);

        // Act
        var expr = Algebra.Multiply(left, right);

        // Assert
        expr.Evaluate().Should().Be(12);
    }

    [Fact]
    public void Sqrt_CreatesFunctionExpression()
    {
        // Arrange
        var arg = Algebra.Constant(16);

        // Act
        var expr = Algebra.Sqrt(arg);

        // Assert
        expr.Should().BeOfType<FunctionExpression>();
        expr.Evaluate().Should().Be(4);
    }

    [Fact]
    public void Sin_CreatesFunctionExpression()
    {
        // Arrange
        var arg = Algebra.Constant(0);

        // Act
        var expr = Algebra.Sin(arg);

        // Assert
        expr.Evaluate().Should().BeApproximately(0, 0.0001);
    }

    [Fact]
    public void Abs_CreatesUnaryExpression()
    {
        // Arrange
        var arg = Algebra.Constant(-5);

        // Act
        var expr = Algebra.Abs(arg);

        // Assert
        expr.Should().BeOfType<UnaryExpression>();
        expr.Evaluate().Should().Be(5);
    }

    [Fact]
    public void Negate_CreatesUnaryExpression()
    {
        // Arrange
        var arg = Algebra.Constant(5);

        // Act
        var expr = Algebra.Negate(arg);

        // Assert
        expr.Evaluate().Should().Be(-5);
    }
}
