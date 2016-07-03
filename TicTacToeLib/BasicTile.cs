using System;

namespace TicTacToeLib
{
    public class BasicTile
    {
        public string symbol = "#";
        public bool Occupied { get; private set; }

        //<summary>Set symbol to the active Players id</summary>
        public void Occupy(string symbol)
        {
            if (Occupied)
            {
                throw new Exception("Tile is Occupied");
            }
            else
            {
                this.symbol = symbol;
                Occupied = true;
            }
        }
    }
}
