namespace MarcusMedina.Maths.Algebra.Tests.Parsers;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Evaluators;
using MarcusMedina.Maths.Algebra.Parsers;
using Xunit;

public class AlgebraParserTests
{
    [Fact]
    public void Parse_Constant_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("42").Evaluate().Should().Be(42);
    }

    [Fact]
    public void Parse_Addition_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("3 + 4").Evaluate().Should().Be(7);
    }

    [Fact]
    public void Parse_Subtraction_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("10 - 3").Evaluate().Should().Be(7);
    }

    [Fact]
    public void Parse_Multiplication_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("3 * 4").Evaluate().Should().Be(12);
    }

    [Fact]
    public void Parse_Division_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("12 / 4").Evaluate().Should().Be(3);
    }

    [Fact]
    public void Parse_Power_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("2^10").Evaluate().Should().Be(1024);
    }

    [Fact]
    public void Parse_OperatorPrecedence_MultipliesBeforeAdding()
    {
        AlgebraParser.Parse("2 + 3 * 4").Evaluate().Should().Be(14);
    }

    [Fact]
    public void Parse_Parentheses_GroupsCorrectly()
    {
        AlgebraParser.Parse("(2 + 3) * 4").Evaluate().Should().Be(20);
    }

    [Fact]
    public void Parse_UnaryMinus_NegatesValue()
    {
        AlgebraParser.Parse("-5").Evaluate().Should().Be(-5);
    }

    [Fact]
    public void Parse_Variable_EvaluatesWithDictionary()
    {
        var expr = AlgebraParser.Parse("x");
        var result = expr.Evaluate(new Dictionary<string, double> { ["x"] = 7 });
        result.Should().Be(7);
    }

    [Fact]
    public void Parse_Polynomial_EvaluatesCorrectly()
    {
        // 2*x^2 + 3*x + 1 at x=2 → 8+6+1 = 15
        var expr = AlgebraParser.Parse("2*x^2 + 3*x + 1");
        var result = expr.Evaluate(new Dictionary<string, double> { ["x"] = 2 });
        result.Should().Be(15);
    }

    [Fact]
    public void Parse_SqrtFunction_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("sqrt(16)").Evaluate().Should().Be(4);
    }

    [Fact]
    public void Parse_SinFunction_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("sin(0)").Evaluate().Should().BeApproximately(0, 0.0001);
    }

    [Fact]
    public void Parse_CosFunction_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("cos(0)").Evaluate().Should().BeApproximately(1, 0.0001);
    }

    [Fact]
    public void Parse_NestedFunctions_EvaluatesCorrectly()
    {
        // sqrt(abs(-16)) = 4
        var expr = AlgebraParser.Parse("sqrt(abs(-16))");
        expr.Evaluate().Should().Be(4);
    }

    [Fact]
    public void Parse_EmptyString_ThrowsArgumentException()
    {
        var act = () => AlgebraParser.Parse("");
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Parse_WhitespaceOnly_ThrowsArgumentException()
    {
        var act = () => AlgebraParser.Parse("   ");
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Parse_InvalidCharacter_ThrowsInvalidOperationException()
    {
        var act = () => AlgebraParser.Parse("2 @ 3");
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Parse_UnmatchedParenthesis_ThrowsInvalidOperationException()
    {
        var act = () => AlgebraParser.Parse("(2 + 3");
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void Parse_DecimalLiteral_EvaluatesCorrectly()
    {
        AlgebraParser.Parse("3.14").Evaluate().Should().BeApproximately(3.14, 0.001);
    }

    [Fact]
    public void Parse_MultipleVariables_EvaluatesCorrectly()
    {
        var expr = AlgebraParser.Parse("x + y");
        var result = expr.Evaluate(new Dictionary<string, double> { ["x"] = 3, ["y"] = 4 });
        result.Should().Be(7);
    }
}
