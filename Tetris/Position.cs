﻿namespace Tetris
{
    /// <summary>
    /// This class represents the position of a cell in the grid.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// This class stores a row and column.
        /// </summary>
        public int Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// This constructor represents the position of the <see cref="Block"/> on the grid.
        /// </summary>
        /// <param name="row">This represents the rows of the gird.</param>
        /// <param name="column">This represents the columns of the grid.</param>
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}