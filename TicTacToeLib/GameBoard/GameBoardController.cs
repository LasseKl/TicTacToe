using System;
using TicTacToeLib.Events;
using TicTacToeLib;
using GameFramework;

namespace TicTacToeLib
{
    public interface IGameBoardController
    {
        void OnUserInput(int x, int y);
        void OnArgumentOutOfRange();
        void OnTileIsOccupied();
        void OnTileChanged();
    }

    public class GameBoardController<T> : IGameBoardController where T : BasicTile, new()
    {
        private IGameBoardGridView<T> view;
        private IGameBoardModel<T> model;

        public GameBoardController(IGameBoardGridView<T> view, IGameBoardModel<T> model)
        {
            this.view = view;
            this.model = model;
            this.view.Controller = this;
            this.model.Controller = this;
            view.UpdateGameBoard(model.Grid);
        }

        public void OnUserInput(int x, int y)
        {
            model.SetTile(x, y);
        }

        public void OnArgumentOutOfRange()
        {
            view.PollUserInput();
        }

        public void OnTileIsOccupied()
        {
            view.PollUserInput();
        }

        public void OnTileChanged()
        {
            view.UpdateGameBoard(model.Grid);
        }
    }
}
