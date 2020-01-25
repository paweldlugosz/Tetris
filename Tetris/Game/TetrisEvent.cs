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
        /// <summary>
        /// The method is called after changing the arrangement of elements
        /// </summary>
        void onBlockChange();

        /// <summary>
        /// The method is called after changing points
        /// </summary>
        /// <param name="lines">Number of all lines removed</param>
        /// <param name="tetris">Number of tetris gained</param>
        void onPointsChange(int lines, int tetris);

        /// <summary>
        /// The method is called after game over
        /// </summary>
        void onGameOver();
    }
}
