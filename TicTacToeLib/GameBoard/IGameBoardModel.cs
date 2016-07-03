using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace TicTacToeLib
{
    public interface IGameBoardModel<T> where T : BasicTile, new()
    {
        IGameBoardController Controller
        {
            get;
            set;
        }

        Grid<T> Grid
        {
            get;
            set;
        }
        void SetTile(int x, int y);
    }
}
