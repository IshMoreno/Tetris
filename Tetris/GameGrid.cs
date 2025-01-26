namespace Tetris
{/// <summary>
/// This class <see cref="GameGrid Grid"/> holds a two dimensional game grid array, the rows and columns. 
/// </summary>
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get;  }
        public int Columns { get; }

        //indexer to provide easy access to the array.
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        /// <summary>
        /// The constructor will take the number of rows and columns as parameters and initialize the array.
        /// </summary>
        /// <param name="rows">This represents the rows of the gird.</param>
        /// <param name="columns">This represents the columns of the grid.</param>
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }

        /// <summary>
        /// This method checks if the given row or column is inside the grid or not.
        /// </summary>
        /// <param name="r">The row must be greater or equal to 0 and less than the number of rows.</param>
        /// <param name="c">The column must be greater or equal to 0 and less than the number of columns.</param>
        /// <returns>
        /// Returns value greater than zero if object is inside the grid.
        /// </returns>
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        /// <summary>
        /// This method checks if the given cell is empty or not.
        /// </summary>
        /// <param name="r">The row that must be inside the grid and equal to zero.</param>
        /// <param name="c">The column that must be inside the grid and equal to zero.s</param>
        /// <returns>
        /// Returns value of zero if it is empty.
        /// </returns>
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        /// <summary>
        /// This method checks if an entire row is full.
        /// </summary>
        /// <param name="r">This represents the grid for rows.</param>
        /// <returns>
        /// Returns true if an entire row is full.
        /// </returns>
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method checks if a row is empty.
        /// </summary>
        /// <param name="r">This represents the grid for rows.</param>
        /// <returns>
        /// Returns true if a row is empty.
        /// </returns>
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if(grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// This method clears a row.
        /// </summary>
        /// <param name="r">This represents the row being cleared.</param>
        private void ClearRow(int r)
        {
            for (int c = 0; r < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        /// <summary>
        /// This method moves a row down by a certain number of rows.
        /// </summary>
        /// <param name="r">This represents the rows cleared.</param>
        /// <param name="numRows">This represents the the rows moved down.</param>
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        /// <summary>
        /// This method clears full rows.
        /// It starts at 0 and moves from the bottom to the top.
        /// The loop checks if the current row is full, if it is, it clears and increment cleared.
        /// Otherwise, if clear is greater than 0, then the current row moves down by the number of cleared rows.
        /// </summary>
        /// <returns>
        /// This returns the number of cleared rows.
        /// </returns>
        public int ClearFullRows()
        {
            int cleared = 0;
            
            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}