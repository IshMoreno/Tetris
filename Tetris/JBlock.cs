namespace Tetris
{
    /// <summary>
    /// This class stores the four positions for the <see cref="JBlock"/> class.
    /// </summary>
    public class JBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0,0), new(1,0), new(1,1), new(1,2) },
            new Position[] {new(0,1), new(0,2), new(1,1), new(2,1) },
            new Position[] {new(1,0), new(1,1), new(1,2), new(2,2) },
            new Position[] {new(0,1), new(1,1), new(2,0), new(2,1) }
        };

        /// <summary>
        /// This property spawns the block in the middle of the top row and returns the 
        /// tiles array from above.
        /// </summary>
        public override int Id => 2;
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}