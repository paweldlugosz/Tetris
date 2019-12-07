using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public interface TetrisEvent
    {
        void onBlockChange();

        void onPointsChange(int lines, int tetris);

        void onGameOver();
    }
}
