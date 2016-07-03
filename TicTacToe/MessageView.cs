using System;
using TicTacToeLib;

namespace TicTacToe
{
    public class MessageView : IMessageView
    {
        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
