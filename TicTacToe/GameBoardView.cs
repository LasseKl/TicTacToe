using System;
using GameFramework;
using TicTacToeLib;
using TicTacToeLib.Events;

namespace TicTacToe
{
    public class GameBoardView : IGameBoardGridView<BasicTile>
    {
        public IGameBoardController Controller
        {
            get;
            set;
        }

        public void UpdateGameBoard(Grid<BasicTile> grid)
        {
            Console.Clear();
            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Console.Write(grid.GetTile(x, y).value.symbol);
                }
                Console.WriteLine();
            }
            PollUserInput();
        }

        public void PollUserInput()
        {
            string line = Console.ReadLine();
            try
            {
                int x = int.Parse(line[0].ToString());
                int y = int.Parse(line[1].ToString());
                Controller.OnUserInput(x, y);
            }
            catch
            {
                new MessageEvent("Pls enter two numbers between 0 and 2").Fire();
                PollUserInput();
            }
        }
    }
}
