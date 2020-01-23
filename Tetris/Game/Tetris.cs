using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{/// <summary>
 ///  Instance definition Board, Tetromino and other elements.
 /// </summary>
    public class Tetris
    {
        public readonly int Width, Height;
        public Field[,] Board;
        public Tetromino activeTetromino;
        private System.Timers.Timer timer;
        private bool newGame, gameOver;
        private TetrisEvent tetrisEvent;
        private int dl, tc;
        public int DeletedLines
        {
            get => dl;
            private set
            {
                dl = value;
                tetrisEvent.onPointsChange(dl, tc);
            }
        }
        public int TetrisCounter
        {
            get => tc;
            private set
            {
                tc = value;
                tetrisEvent.onPointsChange(dl, tc);
            }
        }

        public bool Running
        {
            get => timer.Enabled;
        }

        /// <summary>
        /// Tetris class constructor, definition of height, width, timer. Calling the setup function.
        /// </summary>
        public Tetris(int width, int height, TetrisEvent tetrisEvent)
        {
            this.Width = width;
            this.Height = height;
            this.tetrisEvent = tetrisEvent;
            timer = new System.Timers.Timer();
            timer.Interval = 300;
            timer.Elapsed += new ElapsedEventHandler(onTimeEvent);
            setUp();
        }

        /// <summary>
        /// Start the game with the button'Start Game'.
        /// </summary>
        public void start()
        {
            if (newGame)
            {
                newGame = false;
                setNewActiveTetromino();
                tetrisEvent.onBlockChange();
            }
            if (!gameOver) timer.Enabled = true;
        }

        /// <summary>
        /// The mechanism responsible for the possibility of pausing the game.
        /// </summary>
        public void pause()
        {
            timer.Enabled = false;
        }


        /// <summary>
        /// Define entry conditions.
        /// Setting up the game, drawing a field, possibility to start the game.
        /// </summary>
        public void setUp()
        {
            newGame = true;
            gameOver = false;
            DeletedLines = 0;
            TetrisCounter = 0;
            Board = new Field[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Board[i, j] = new Field();
                }
            }
            timer.Enabled = false;
            tetrisEvent.onBlockChange();
        }

        /// <summary>
        /// Function responsible for rotating the block to the left.
        /// </summary>
        public void moveLeft()
        {
            if (Running) movement(-1, 0);
        }

        /// <summary>
        /// Function responsible for movement the block to the right.
        /// </summary>
        public void moveRight()
        {
            if (Running) movement(1, 0);
        }

        /// <summary>
        /// Function responsible for movement the block to down.
        /// </summary>
        public void moveDown()
        {
            if (Running) movement(0, 1);
        }

        /// <summary>
        /// The "flor ()" function, which tetromino moves it down and create new blocks.
        /// </summary>
        public void flor()
        {
            Point[] previous = new Point[activeTetromino.Points.Length];
            for (int i = 0; i < previous.Length; i++)
            {
                previous[i] = activeTetromino.Points[i].Clone();
            }
            while(true)
            {
                if (!offset(0, 1)) break;
            }
            clear(previous);
            setTetrominoOnBoard(true);
            checkLines();
            setNewActiveTetromino();
        }

        private void movement(int x, int y)
        {
            if (offset(x, y)) drawTetrominoOnBoard();
        }

        /// <summary>
        /// Move the active block with the 'X' and 'Y' parameters.
        /// Checks for a collision.If a collision appear, the block returns to the previous position
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>true if offset succeeded, false if failed</returns>
        private bool offset(int x, int y)
        {
            activeTetromino.offset(x, y);
            bool isCollision = collision();
            if (isCollision)
            {
                activeTetromino.undo();
            }
            return !isCollision;
        }

        /// <summary>
        /// Function is a function of turning the block, which at the same time checks whether the application is running. 
        /// Checks if we don't leave the block outside the board.
        /// </summary>
        public void rotate()
        {
            if (!Running) return;
            activeTetromino.Rotate();
            if (!collision()) drawTetrominoOnBoard();
            else activeTetromino.undo();
            
        }

        /// <summary>
        /// Reaction to the M button ( moving the block down ).
        /// If the offset has such parameters (the block is at the bottom) then draw a new one.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void onTimeEvent(object source, ElapsedEventArgs e)
        {
            if (offset(0, 1))
            {
                drawTetrominoOnBoard();
            }
            else
            {
                setTetrominoOnBoard(true);
                setNewActiveTetromino();
                checkLines();
            }
            tetrisEvent.onBlockChange();

        }

        /// <summary>
        /// Checking if the blocks fill the lines in the board area. If they are full it starts the function of removing these lines from the board.
        /// </summary>
        private void checkLines()
        {
            int lines = 0;
            for (int y = 0; y < Height; y++)
            {
                int block = 0;
                for (int x = 0; x < Width; x++)
                {
                    if (Board[x, y].Used) block++;
                }
                if (block == Width)
                {
                    
                    lines++;
                    moveLines(y);
                }
                
            }
            if (lines >= 4) TetrisCounter++;
            DeletedLines += lines;
        }

        /// <summary>
        ///  Shift lines if full and clear them.
        /// </summary>
        /// <param name="row"></param>
        private void moveLines(int row)
        {
            for (int y = row; y > 0; y--)
            {
                for (int x = 0; x < Width; x++)
                {
                    Board[x, y].set(Board[x, y - 1]);
                }
            }

            for (int x = 0; x < Width; x++)
            {
                Board[x, 0].clear();
            }
        }

        /// <summary>
        /// Displaying the first and each block on the board after starting the game.
        /// </summary>
        private void drawTetrominoOnBoard()
        {
            clear(activeTetromino.getPreviousPosition());
            setTetrominoOnBoard(false);
            tetrisEvent.onBlockChange();
        }

        /// <summary>
        /// Setting first and each next block on the board.
        /// </summary>
        /// <param name="used"></param>
        private void setTetrominoOnBoard(bool used)
        {
            foreach (Point point in activeTetromino.Points)
            {
                if (point.Y < 0 /**|| point.X < 0 || point.Y >= Height || point.X >= Width**/) continue;
                Field field = Board[point.X, point.Y];
                field.Used = used;
                field.Color = activeTetromino.color;
            }
        }

        /// <summary>
        /// Cleaning the board. Collect each point and sets it so that it is not used.Removes color.
        /// </summary>
        /// <param name="points"></param>
        private void clear(Point[] points)
        {
            foreach (Point point in points)
            {
                if (point.Y < 0) continue;
                Field field = Board[point.X, point.Y];
                field.Used = false;
                field.Color = Color.Transparent;
            }
        }

        /// <summary>
        ///  The function responsible for creating a new block and displaying it on the board.
        /// </summary>
        private void setNewActiveTetromino()
        {
            activeTetromino = TetrominoFactory.getNewRandomTetromino();
            int center = Width / 2 - 2;
            if (offset(center, -1))
            {
                setTetrominoOnBoard(false);
            }
            else
            {
                timer.Enabled = false;
                gameOver = true;
                tetrisEvent.onGameOver();
            }
        }

        /// <summary>
        ///  A mechanism that limits the possibility of moving blocks outside the board.
        /// </summary>
        private bool collision()
        {
            if (activeTetromino.collision(Width, Height))
            {
                return true;
            }
            foreach (Point point in activeTetromino.Points)
            {
                if (point.Y >= 0 && Board[point.X, point.Y].Used)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
