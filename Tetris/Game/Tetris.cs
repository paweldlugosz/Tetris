using System;
using System.Timers;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
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

        public void pause()
        {
            timer.Enabled = false;
        }

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

        public void moveLeft()
        {
            if (Running) movement(-1, 0);
        }

        public void moveRight()
        {
            if (Running) movement(1, 0);
        }

        public void moveDown()
        {
            if (Running) movement(0, 1);
        }

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

        public void rotate()
        {
            if (!Running) return;
            activeTetromino.Rotate();
            if (!collision()) drawTetrominoOnBoard();
            else activeTetromino.undo();
            
        }

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

        private void drawTetrominoOnBoard()
        {
            clear(activeTetromino.getPreviousPosition());
            setTetrominoOnBoard(false);
            tetrisEvent.onBlockChange();
        }

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
