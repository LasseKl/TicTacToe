using GameFramework;
using TicTacToeLib.Events;

namespace TicTacToeLib
{
    public class MessageModel
    {
        public string Message { get; set; }
        public MessageController Controller { get; set; }

        public MessageModel()
        {
            EventEngine.SignIn<MessageEvent>(OnMsgEvent);
        }

        private void OnMsgEvent(MessageEvent e)
        {
            Message = e.data;
            Controller.OnMessageChanged();
        }
    }
}
