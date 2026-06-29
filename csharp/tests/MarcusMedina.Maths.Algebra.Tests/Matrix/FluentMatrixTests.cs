namespace MarcusMedina.Maths.Algebra.Tests.Matrix;

using FluentAssertions;
using MarcusMedina.Maths.Algebra.Matrix;
using Xunit;

public class FluentMatrixTests
{
    [Fact]
    public void Constructor_Dimensions_SetsRowsAndColumns()
    {
        var m = new FluentMatrix(3, 4);
        m.Rows.Should().Be(3);
        m.Columns.Should().Be(4);
    }

    [Fact]
    public void Constructor_Dimensions_InitializesToZero()
    {
        var m = new FluentMatrix(2, 2);
        m[0, 0].Should().Be(0);
        m[0, 1].Should().Be(0);
        m[1, 0].Should().Be(0);
        m[1, 1].Should().Be(0);
    }

    [Fact]
    public void Indexer_SetAndGet_ReturnsCorrectValue()
    {
        var m = new FluentMatrix(2, 2);
        m[0, 1] = 42;
        m[0, 1].Should().Be(42);
    }

    [Fact]
    public void Constructor_DataArray_ClonesData()
    {
        var data = new double[,] { { 1, 2 }, { 3, 4 } };
        var m = new FluentMatrix(data);

        m.Rows.Should().Be(2);
        m.Columns.Should().Be(2);
        m[0, 0].Should().Be(1);
        m[0, 1].Should().Be(2);
        m[1, 0].Should().Be(3);
        m[1, 1].Should().Be(4);
    }

    [Fact]
    public void Constructor_DataArray_IsIndependentCopy()
    {
        var data = new double[,] { { 1, 2 }, { 3, 4 } };
        var m = new FluentMatrix(data);
        data[0, 0] = 99;
        m[0, 0].Should().Be(1); // not affected by original array mutation
    }
}
