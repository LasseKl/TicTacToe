using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace TicTacToeLib
{
    public class GridLineBuilder
    {
        //<summary>
        // Builds vertical, horizontal and diagonal lines from the GameBoards grid.
        // The lines contain 3 tiles each
        //</summary>
        public GridLine[] BuildLines(Grid<BasicTile> grid)
        {
            List<GridLine> lines = new List<GridLine>();
            lines.AddRange(BuildHorizontalLines(grid));
            lines.AddRange(BuildVerticalLines(grid));
            lines.AddRange(BuildDiagonalLines(grid));
            return lines.ToArray();
        }

        private List<GridLine> BuildHorizontalLines(Grid<BasicTile> grid)
        {
            List<GridLine> lines = new List<GridLine>();
            for (int i = 0; i < grid.Height; i++)
            {
                lines.Add(BuildLine(Direction.Right, grid.GetTile(0, i)));
            }
            return lines;
        }

        private List<GridLine> BuildVerticalLines(Grid<BasicTile> grid)
        {
            List<GridLine> lines = new List<GridLine>();
            for (int i = 0; i < grid.Width; i++)
            {
                lines.Add(BuildLine(Direction.Lower, grid.GetTile(i, 0)));
            }
            return lines;
        }

        private List<GridLine> BuildDiagonalLines(Grid<BasicTile> grid)
        {
            List<GridLine> lines = new List<GridLine>();
            for (int i = 0; i < grid.Width; i++)
            {
                GridLine result = BuildLine(Direction.LowerRight, grid.GetTile(i, 0));

                if (result.tiles.Count >= 3)
                {
                    lines.Add(result);
                }
            }
            return lines;
        }

        private GridLine BuildLine(Direction direction, Tile<BasicTile> startTile)
        {
            GridLine line = new GridLine();
            Tile<BasicTile> currentTile = startTile;

            while (currentTile != null)
            {
                line.tiles.Add(currentTile.value);
                currentTile = currentTile.GetNeighbour(direction);
            }

            return line;
        }
    }
}
