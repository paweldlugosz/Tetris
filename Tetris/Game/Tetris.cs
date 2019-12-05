using System;
using System.Timers;
using System.Drawing;

namespace Game
{
    public class Tetris
    {
        private readonly int width, height;
        private Field[,] board;
        private Tetromino activeTetromino;
        private Timer timer;
        private TetrisEvent tetrisEvent;
        public int DeletedLines
        {
            get;
            private set;
        }
        public int TetrisCounter
        {
            get;
            private set;
        }

        public Tetris(int width, int height, TetrisEvent tetrisEvent)
        {
            this.width = width;
            this.height = height;
            this.tetrisEvent = tetrisEvent;
            DeletedLines = 0;
            TetrisCounter = 0;
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += new ElapsedEventHandler(onTimeEvent);
            board = new Field[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    board[i,j] = new Field();
                }
            }
        }

        public void start()
        {
            setNewActiveTetromino();
            tetrisEvent.onBlockChange(board);
            timer.Enabled = true;
        }

        public void pause()
        {
            timer.Enabled = false;
        }

        public void moveLeft()
        {
            movement(-1, 0);
        }

        public void moveRight()
        {
            movement(1, 0);
        }

        public void moveDown()
        {
            movement(0, -1);
        }

        private void movement(int x, int y)
        {
            if (offset(x, y)) moveTetrominoOnBoard();
            else activeTetromino.undo();
        }

        private bool offset(int x, int y)
        {
            activeTetromino.offset(x, y);
            return !collision();
        }

        public void rotate()
        {
            activeTetromino.rotate();
            if (collision()) moveTetrominoOnBoard();
            else activeTetromino.undo();
            
        }

        private void onTimeEvent(object source, ElapsedEventArgs e)
        {
            if (offset(0, -1))
            {
                moveTetrominoOnBoard();
            }
            else
            {
                activeTetromino.undo();
                setNewActiveTetromino();
                tetrisEvent.onBlockChange(board);
            }
            
        }


        private void moveTetrominoOnBoard()
        {
            clear(activeTetromino.getPreviousPosition());
            setTetrominoOnBoard();
            tetrisEvent.onBlockChange(board);
        }

        private void setTetrominoOnBoard()
        {
            foreach (Point point in activeTetromino.Points)
            {
                Field field = board[point.X, point.Y];
                field.Used = true;
                field.Color = activeTetromino.color;
            }
        }

        private void clear(Point[] points)
        {
            foreach (Point point in points)
            {
                if (point.Y < 0) continue;
                Field field = board[point.X, point.Y];
                field.Used = false;
                field.Color = Color.Transparent;
            }
        }

        private void setNewActiveTetromino()
        {
            activeTetromino = TetrominoFactory.getNewRandomTetromino();
            int center = width / 2 - 2;
            if (offset(center, -1))
            {
                setTetrominoOnBoard();
            }
            else
            {
                timer.Enabled = false;
                tetrisEvent.onGameOver();
            }
        }

        private bool collision()
        {
            if (activeTetromino.collision(width, height))
            {
                return true;
            }
            foreach (Point point in activeTetromino.Points)
            {
                if (point.Y >= 0 && board[point.X, point.Y].Used)
                {
                    return true;
                }
            }
            return false;
        }

        
    }
}
