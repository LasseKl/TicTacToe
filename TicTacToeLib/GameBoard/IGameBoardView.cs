using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace TicTacToeLib
{
    public interface IGameBoardGridView<T> where T : BasicTile, new()
    {
        IGameBoardController Controller { get; set; }
        void PollUserInput();
        void UpdateGameBoard(Grid<T> grid);
    }
}
