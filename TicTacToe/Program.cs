using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLib;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameBoardView gameBoardView = new GameBoardView();
            GameBoardModel gameBoardModel = new GameBoardModel();
            MessageController msgController = new MessageController(new MessageModel(), new MessageView());
            GameBoardController<BasicTile> gameBoardController = new GameBoardController<BasicTile>(gameBoardView, gameBoardModel);
        }
    }
}
