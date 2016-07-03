using System.Collections.Generic;
using GameFramework;

namespace TicTacToeLib
{
    public class WinConditionChecker
    {
        public GridLine[] lines;

        public WinConditionChecker(Grid<BasicTile> grid)
        {
            lines = new GridLineBuilder().BuildLines(grid);
        }

        //<summary>Update all lines win states</summary>
        public void UpdateWin()
        {
            foreach(GridLine line in lines)
            {
                line.UpdateWin();
            }
        }
    }
}
