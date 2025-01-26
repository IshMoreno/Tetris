using System;

namespace Tetris
{
    /// <summary>
    /// This class contains an instance of all the block classes.
    /// </summary>
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };

        /// <summary>
        /// Randomized next block.
        /// </summary>
        private readonly Random random = new Random();

        /// <summary>
        /// Next block in the queue.
        /// </summary>
        public Block NextBlock {  get; private set; }

        /// <summary>
        /// Method to queue the next random block.
        /// </summary>
        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        /// <summary>
        /// Initialized random block.
        /// </summary>
        /// <returns>Returns next random block in queue.</returns>
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        /// <summary>
        /// Method to return the next block and update the property.
        /// </summary>
        /// <returns>Returns the next block.</returns>
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}