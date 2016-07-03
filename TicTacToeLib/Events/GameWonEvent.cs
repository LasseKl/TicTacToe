using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace TicTacToeLib.Events
{
    public class GameWonEvent : DataEvent<GameWonEvent, string>
    {
        public GameWonEvent(string symbol) : base (symbol)
        {

        }
    }
}
