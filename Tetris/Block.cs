namespace Tetris
{
    /// <summary>
    /// This class represents the blocks of the game for each block.
    /// </summary>
    public abstract class Block
    {
        //Tile position and the four rotation states.
        protected abstract Position[][] Tiles { get; }
        //Offset which decides where the block spawns.
        protected abstract Position StartOffset { get; }
        //ID to distinguish the blocks.
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        /// <summary>
        /// The constructor that represents the offset for the block.
        /// </summary>
        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        /// <summary>
        /// This method generates a sequence of 'Position' objects. It iterates over the 'Position' objects in the 'Tiles' collection
        /// at the index 'rotationState', and adjusts each 'Position' by an offset.
        /// </summary>
        /// <returns>
        /// This returns the grid position occupied by the current block.
        /// </returns>
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        /// <summary>
        /// This method rotates the block 90 degrees clockwise.
        /// </summary>
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        /// <summary>
        /// This method rotates the block 90 degrees counter-clockwise.
        /// </summary>
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        /// <summary>
        /// This method moves the block by a number of rows and columns.
        /// </summary>
        /// <param name="rows">This represents the rows of the gird.</param>
        /// <param name="columns">This represents the columns of the gird.</param>
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        /// <summary>
        /// This method resets the rotation and position of the block.
        /// </summary>
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}