using System.Collections.Generic;
using TicTacToeLib.Events;

namespace TicTacToeLib
{
    public class GridLine
    {
        public List<BasicTile> tiles = new List<BasicTile>();

        //<summary> Fires GameWonEvent if all tiles are occupied by the same player</summary>
        public void UpdateWin()
        {
            string lastSymbol = "";

            foreach(BasicTile tile in tiles)
            {
                if(SymbolsAreNotEqual(lastSymbol, tile.symbol)
                    || !tile.Occupied)
                {
                    return;
                }
                lastSymbol = tile.symbol;
            }

            OnWin(lastSymbol);
        }

        private bool SymbolsAreNotEqual(string lastSymbol, string symbol)
        {
            return lastSymbol != "" && lastSymbol != symbol;
        }

        private void OnWin(string symbol)
        {
            new GameWonEvent(symbol).Fire();
        }
    }
}
