using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace TicTacToeLib.Events
{
    //An Event that gets received by the MessageModel its used to show messages to the user
    public class MessageEvent : DataEvent<MessageEvent, string>
    {
        public MessageEvent(string msg) : base(msg)
        {

        }
    }
}
