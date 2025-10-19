namespace MarcusMedina.Fluent.Algebra.Matrix;

/// <summary>
/// Fluent matrix operations (placeholder for future implementation)
/// </summary>
public class FluentMatrix
{
    private readonly double[,] _data;

    public int Rows { get; }
    public int Columns { get; }

    public FluentMatrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _data = new double[rows, columns];
    }

    public FluentMatrix(double[,] data)
    {
        Rows = data.GetLength(0);
        Columns = data.GetLength(1);
        _data = (double[,])data.Clone();
    }

    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    // TODO: Implement matrix operations (Add, Multiply, Transpose, Determinant, etc.)
}
