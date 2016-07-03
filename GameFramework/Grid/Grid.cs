using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Grid<T> where T : new()
    {
        private Tile<T>[,] tiles;
        public event Action OnTilesBuilt;

        public int Width
        {
            get; private set;
        }

        public int Height
        {
            get; private set;
        }

        public Grid(int width, int height)
        {
            tiles = new Tile<T>[width, height];

            Width = width;
            Height = height;

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new Tile<T>(this, x, y);
                }
            }

            OnTilesBuilt();
        }

        public Tile<T> GetTile(int x, int y)
        {
            if (!IsInRange(x, y)) throw new ArgumentException("x and y have to be between -1 and 1");
            return tiles[x, y];
        }

        public bool IsInRange(int x, int y)
        {
            return x >= 0 && x < tiles.GetLength(0)
                && y >= 0 && y < tiles.GetLength(1);
        }
    }
}
