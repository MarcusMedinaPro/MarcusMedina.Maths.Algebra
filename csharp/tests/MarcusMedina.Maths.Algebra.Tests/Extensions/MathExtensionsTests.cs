namespace MarcusMedina.Maths.Algebra.Tests.Extensions;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Builders;
using MarcusMedina.Maths.Algebra.Extensions;
using MarcusMedina.Maths.Algebra.Interfaces;
using Xunit;

public class MathExtensionsTests
{
    private static IAlgebraExpression Const(double v) => Algebra.Constant(v);

    [Fact]
    public void Sqrt_OfSixteen_ReturnsFour()
    {
        Const(16).Sqrt().Evaluate().Should().Be(4);
    }

    [Fact]
    public void AbsoluteValue_NegativeNumber_ReturnsPositive()
    {
        Const(-7).AbsoluteValue().Evaluate().Should().Be(7);
    }

    [Fact]
    public void Sin_OfZero_ReturnsZero()
    {
        Const(0).Sin().Evaluate().Should().BeApproximately(0, 1e-10);
    }

    [Fact]
    public void Cos_OfZero_ReturnsOne()
    {
        Const(0).Cos().Evaluate().Should().BeApproximately(1, 1e-10);
    }

    [Fact]
    public void Tan_OfZero_ReturnsZero()
    {
        Const(0).Tan().Evaluate().Should().BeApproximately(0, 1e-10);
    }

    [Fact]
    public void Log_OfE_ReturnsOne()
    {
        Const(Math.E).Log().Evaluate().Should().BeApproximately(1, 1e-10);
    }

    [Fact]
    public void Log10_OfHundred_ReturnsTwo()
    {
        Const(100).Log10().Evaluate().Should().BeApproximately(2, 1e-10);
    }

    [Fact]
    public void Exp_OfZero_ReturnsOne()
    {
        Const(0).Exp().Evaluate().Should().BeApproximately(1, 1e-10);
    }

    [Fact]
    public void Floor_Of2Point7_ReturnsTwo()
    {
        Const(2.7).Floor().Evaluate().Should().Be(2);
    }

    [Fact]
    public void Ceiling_Of2Point1_ReturnsThree()
    {
        Const(2.1).Ceiling().Evaluate().Should().Be(3);
    }

    [Fact]
    public void ArcSin_OfOne_ReturnsHalfPi()
    {
        Const(1).ArcSin().Evaluate().Should().BeApproximately(Math.PI / 2, 1e-10);
    }

    [Fact]
    public void ArcCos_OfOne_ReturnsZero()
    {
        Const(1).ArcCos().Evaluate().Should().BeApproximately(0, 1e-10);
    }

    [Fact]
    public void ArcTan_OfOne_ReturnsQuarterPi()
    {
        Const(1).ArcTan().Evaluate().Should().BeApproximately(Math.PI / 4, 1e-10);
    }
}
