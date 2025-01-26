namespace Tetris
{
    /// <summary>
    /// This class stores the four positions for the <see cref="OBlock"/> class.
    /// This particular block only needs one rotation state, since it's symmetrical.
    /// </summary>
    public class OBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] {new(0, 0), new(0, 1),new(1, 0), new(1, 1) }
        };

        /// <summary>
        /// This property spawns the block in the middle of the top row and returns the 
        /// tiles array from above.
        /// </summary>
        public override int Id => 4;
        protected override Position StartOffset => new Position(0, 4);
        protected override Position[][] Tiles => tiles;
    }
}