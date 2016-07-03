using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Tile<T> where T : new()
    {
        private Dictionary<Direction, Tile<T>> neighbours = new Dictionary<Direction, Tile<T>>();
        Grid<T> grid;
        private int posX;
        private int posY;
        public T value;

        public Tile(Grid<T> grid, int posX, int posY)
        {
            this.grid = grid;
            grid.OnTilesBuilt += SetNeighbours;
            this.posX = posX;
            this.posY = posY;
            value = new T();
        }

        //<summary> Gets neighbour in direction, returns null if neighbour is out range.</summary>
        public Tile<T> GetNeighbour(Direction direction)
        {
            Tile<T> neighbour = null;

            if(neighbours.ContainsKey(direction))
            {
                neighbour = neighbours[direction];
            }

            return neighbour;
        }

        //<summary>Sets the neighbours of this tile including diagonal neighbours</summary>
        private void SetNeighbours()
        {
            for (int x1 = -1; x1 <= 1; x1++)
            {
                for (int y1 = -1; y1 <= 1; y1++)
                {
                    if (!(x1 == 0 && y1 == 0))
                    {
                        int curX = posX + x1;
                        int curY = posY + y1;

                        if (grid.IsInRange(curX, curY))
                        {
                            neighbours[GetDirection(x1, y1)] = grid.GetTile(curX, curY);
                        }
                    }
                }
            }
        }

        //<summary>Returns the corresponding direction for x and y</summary>
        private Direction GetDirection(int x, int y)
        {
            switch (x)
            {
                case -1:
                    if (y == -1)
                        return Direction.UpperLeft;
                    if (y == 0)
                        return Direction.Left;
                    if (y == 1)
                        return Direction.LowerLeft;
                    break;
                case 0:
                    if (y == -1)
                        return Direction.Upper;
                    if (y == 1)
                        return Direction.Lower;
                    break;
                case 1:
                    if (y == -1)
                        return Direction.UpperRight;
                    if (y == 1)
                        return Direction.LowerRight;
                    if (y == 0)
                        return Direction.Right;
                    break;
            }
            throw new ArgumentException("x and y have to between -1 and 1");
        }

    }
}
