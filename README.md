# Tetris Game

This is a classic Tetris game implemented in C# using WPF (Windows Presentation Foundation). The game includes all the standard Tetris features, such as block rotation, 
movement, scoring, and a hold functionality. The game also includes a preview of the next block and a ghost block to indicate where the current block will land.

## Features

- **Classic Tetris Gameplay**: Move, rotate, and drop blocks to clear lines and score points.
- **Block Rotation**: Rotate blocks clockwise and counter-clockwise.
- **Hold Functionality**: Hold a block to use it later.
- **Next Block Preview**: See the next block in the queue.
- **Ghost Block**: A translucent preview of where the current block will land.
- **Scoring**: Earn points by clearing lines. The more lines you clear at once, the higher the score.
- **Increasing Difficulty**: The game speeds up as your score increases.
- **Game Over**: The game ends when blocks stack up to the top of the grid.

## How to Run the Game

1. **Prerequisites**:
   - Ensure you have [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
   - A code editor like Visual Studio or Visual Studio Code is recommended.

2. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-repo/tetris-game.git
   cd tetris-game
   Build and Run:

3. **Build and Run**:
 
   - Open the project in Visual Studio or Visual Studio Code.

   - Build the project using the Build option in your IDE.

   - Run the project by pressing F5 or using the Run option in your IDE.

4. **Play the Game**:

   - Use the arrow keys to move the blocks:

   - **Left Arrow**: Move block left.

   - **Right Arrow**: Move block right.

   - **Down Arrow**: Move block down faster.

   - **Up Arrow**: Rotate block clockwise.

   - **Z Key**: Rotate block counter-clockwise.

   - **C Key**: Hold the current block.

   - **Space Bar**: Drop the block instantly.

   - Clear as many lines as possible to increase your score.
  
## Code Structure

The project is organized into several classes, each responsible for a specific part of the game:

   - **Block**: Abstract base class for all Tetris blocks. Contains methods for rotation, movement, and tile positions.

   - **BlockQueue**: Manages the queue of blocks and provides the next block in the sequence.

   - **GameGrid**: Represents the game grid and handles line clearing, row checking, and block placement.

   - **GameState**: Manages the game state, including the current block, score, and game over conditions.

   - **MainWindow**: The main window of the game, handling the UI, user input, and game loop.

## Assets

The game uses the following assets for the blocks and tiles:

   - **Tile Images**: Represent the empty and filled cells in the grid.

   - **Block Images**: Represent the different Tetris blocks (I, J, L, O, S, T, Z).

## Future Improvements

   - **High Score System**: Implement a high score system to save and display the highest scores.

   - **Multiplayer Mode**: Add a multiplayer mode where players can compete against each other.

   - **Customizable Controls**: Allow players to customize the control keys.

   - **Sound Effects**: Add sound effects for block movements, rotations, and line clears.

## Contributing

Contributions are welcome! If you have any suggestions, bug reports, or feature requests, please open an issue or submit a pull request.

Enjoy the game! 🎮
