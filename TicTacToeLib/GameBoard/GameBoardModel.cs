using System;
using GameFramework;
using TicTacToeLib;
using TicTacToeLib.Events;

namespace TicTacToeLib
{

    public class GameBoardModel : IGameBoardModel<BasicTile>
    {
        public WinConditionChecker condition;
        public bool won = false;
        private Player player1;
        private Player player2;
        private Player activePlayer;

        public IGameBoardController Controller
        {
            get;
            set;
        }

        public Grid<BasicTile> Grid
        {
            get;
            set;
        }

        public GameBoardModel()
        {
            Grid = new Grid<BasicTile>(3, 3);
            condition = new WinConditionChecker(Grid as Grid<BasicTile>);
            EventEngine.SignIn<GameWonEvent>(OnGameWon);
            player1 = new Player("1");
            player2 = new Player("2");
            activePlayer = player1;
        }

        private void OnGameWon(GameWonEvent e)
        {
            new MessageEvent(e.data + " wins").Fire();
            won = true;
            Console.Read();
        }

        public void SetTile(int x, int y)
        {
            BasicTile tileModel = null;
            try
            {
                tileModel = Grid.GetTile(x, y).value;
            }
            catch (ArgumentException)
            {
                new MessageEvent("Pls enter 2 numbers between 0 and 2").Fire();
                Controller.OnArgumentOutOfRange();
                return;
            }
            try
            {
                tileModel.Occupy(activePlayer.id);
                activePlayer = activePlayer == player1 ? player2 : player1;
                condition.UpdateWin();
                if (!won)
                {
                    Controller.OnTileChanged();
                }
            }
            catch (Exception e)
            {
                if (e.Message == "Tile is Occupied")
                {
                    new MessageEvent("This field is occupied pls choose another").Fire();
                    Controller.OnTileIsOccupied();
                }
            }
        }
    }
}
