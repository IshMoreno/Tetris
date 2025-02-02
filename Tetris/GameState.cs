namespace Tetris
{
    /// <summary>
    /// The <see cref="GameState"/> class handles the interactions between all parts and movements for the <see cref="Block"/>.
    /// </summary>
    public class GameState
    {
        private Block currentBlock = null!;

        /// <summary>
        /// When the current block is updated, the reset method is called to set the correct stop position and rotation.
        /// </summary>
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();

                for (int i = 0; i < 2; i++)
                {
                    currentBlock.Move(1, 0);

                    if (!BlockFits())
                    {
                        currentBlock.Move(-1, 0);
                    }
                }
            }
        }

        /// <summary>
        /// Properties for the game grid, block queue, and game over bool, the score, held-block, and can-hold.
        /// </summary>
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public Block? HeldBlock { get; private set; }
        public bool CanHold { get; private set; }

        /// <summary>
        /// Constructor to initialize the game grid with 22 rows and 10 columns. Also initialize the Block queue 
        /// to use it to get a random block.
        /// </summary>
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
            CanHold = true;
        }

        /// <summary>
        /// Method to check if current block is in a legal position or not.
        /// </summary>
        /// <returns>Returns true if block is in the grid and can be set.</returns>
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (p.Row < 0 || p.Row >= GameGrid.Rows || p.Column < 0 || p.Column >= GameGrid.Columns || !GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false; 
                }
            }

            return true;
        }

        /// <summary>
        /// Method to keep a block in hold position.
        /// </summary>
        public void HoldBlock()
        {
            if (!CanHold)
            {
                return;
            }

            if (HeldBlock == null)
            {
                HeldBlock = CurrentBlock;
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
            else
            {
                Block tmp = CurrentBlock;
                CurrentBlock = HeldBlock;
                HeldBlock = tmp;
            }

            CanHold = false;
        }

        /// <summary>
        /// Rotates block CW if it's possible.
        /// </summary>
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        /// <summary>
        /// Rotates block CCW if it's possible.
        /// </summary>
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        /// <summary>
        /// Moves block left.
        /// </summary>
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        /// <summary>
        /// Moves block right.
        /// </summary>
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        /// <summary>
        /// Method to check if the game is over.
        /// </summary>
        /// <returns>If the hidden rows are not empty, then the game is over.</returns>
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        /// <summary>
        /// Method when current block cannot be moved down.
        /// The block is looped over the tile positions and sets those positions in the game grid = to the block's
        /// id. Then any potential full rows are cleared. Then check if the game is over, if not, update the 
        /// current block.
        /// </summary>
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            Score += GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
                CanHold = true;
            }
        }

        /// <summary>
        /// Method to move block down.
        /// </summary>
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }

        /// <summary>
        /// Helper method that takes the position and returns the number of empty cells below it.
        /// </summary>
        private int TileDropDistance(Position p)
        {
            int drop = 0;

            while (p.Row + drop + 1 < GameGrid.Rows && GameGrid.IsEmpty(p.Row + drop + 1, p.Column))
            {
                drop++;
            }

            return drop;
        }

        /// <summary>
        /// Method that calls the <see cref="TileDropDistance(Position)"/> method and takes the number of cells to move down.
        /// </summary>
        /// <returns></returns>
        public int BlockDropDistance()
        {
            int drop = GameGrid.Rows;

            foreach (Position p in CurrentBlock.TilePositions())
            {
                drop = System.Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }
        /// <summary>
        /// Method to move the block all the way down and places it in the grid.
        /// </summary>
        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }
    }
}