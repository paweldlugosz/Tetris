using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    /// <summary>
    /// Application interface with reference in the code where it is used.
    /// </summary>
    public interface TetrisEvent
    {
        void onBlockChange();

        void onPointsChange(int lines, int tetris);

        void onGameOver();
    }
}
