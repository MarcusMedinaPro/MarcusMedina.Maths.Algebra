namespace MarcusMedina.Fluent.Algebra.Matrix;

/// <summary>
/// Represents a mathematical matrix for algebraic operations.
/// This class is a placeholder for future matrix functionality.
/// </summary>
public class FluentMatrix
{
    private readonly double[,] _data;

    /// <summary>
    /// Gets the number of rows in the matrix.
    /// </summary>
    public int Rows { get; }

    /// <summary>
    /// Gets the number of columns in the matrix.
    /// </summary>
    public int Columns { get; }

    /// <summary>
    /// Initializes a new matrix with the specified number of rows and columns.
    /// All elements are initialized to zero.
    /// </summary>
    /// <param name="rows">The number of rows.</param>
    /// <param name="columns">The number of columns.</param>
    public FluentMatrix(int rows, int columns)
        => (_data, Rows, Columns) = (new double[rows, columns], rows, columns);

    /// <summary>
    /// Initializes a new matrix with the specified data array.
    /// </summary>
    /// <param name="data">A 2D array of doubles representing the matrix elements.</param>
    public FluentMatrix(double[,] data)
        => (_data, Rows, Columns) = ((double[,])data.Clone(), data.GetLength(0), data.GetLength(1));

    /// <summary>
    /// Gets or sets the value at the specified row and column in the matrix.
    /// </summary>
    /// <param name="row">The row index (zero-based).</param>
    /// <param name="col">The column index (zero-based).</param>
    /// <returns>The value at the specified position.</returns>
    public double this[int row, int col]
    {
        get => _data[row, col];
        set => _data[row, col] = value;
    }

    // TODO: Implement matrix operations (Add, Multiply, Transpose, Determinant, etc.)
}
