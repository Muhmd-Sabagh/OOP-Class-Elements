namespace OOP.Indexers
{
    // Represents a Sudoku grid with validation
    public class Sudoku
    {
        private readonly int[,] _grid;
        private const int GRID_SIZE = 9;
        private const int MIN_VALUE = 1;
        private const int MAX_VALUE = 9;

        // Indexer to get or set values in the Sudoku grid
        // Row index (0-8)
        // Column index (0-8)
        public int this[int row, int col]
        {
            get
            {
                ValidateCoordinates(row, col);
                return _grid[row, col];
            }
            set
            {
                ValidateCoordinates(row, col);
                ValidateValue(value);
                _grid[row, col] = value;
            }
        }

        // Creates a new Sudoku grid from a 9x9 matrix
        public Sudoku(int[,] grid)
        {
            if (grid.GetLength(0) != GRID_SIZE || grid.GetLength(1) != GRID_SIZE)
                throw new ArgumentException("Sudoku grid must be 9x9");

            _grid = new int[GRID_SIZE, GRID_SIZE];
            Array.Copy(grid, _grid, grid.Length);
        }

        private void ValidateCoordinates(int row, int col)
        {
            if (row < 0 || row >= GRID_SIZE || col < 0 || col >= GRID_SIZE)
                throw new IndexOutOfRangeException($"Row and column indices must be between 0 and {GRID_SIZE - 1}");
        }

        private void ValidateValue(int value)
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
                throw new ArgumentOutOfRangeException($"Sudoku values must be between {MIN_VALUE} and {MAX_VALUE}");
        }

        public override string ToString()
        {
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < GRID_SIZE; i++)
            {
                if (i % 3 == 0 && i != 0)
                    result.AppendLine("---------------------");

                for (int j = 0; j < GRID_SIZE; j++)
                {
                    if (j % 3 == 0 && j != 0)
                        result.Append("| ");
                    result.Append($"{_grid[i, j]} ");
                }
                result.AppendLine();
            }
            return result.ToString();
        }
    }
}
