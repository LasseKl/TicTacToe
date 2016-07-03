namespace TicTacToeLib
{
    public class MessageController
    {
        public MessageModel model;
        public IMessageView view;

        public MessageController(MessageModel model, IMessageView view)
        {
            this.model = model;
            this.view = view;
            this.model.Controller = this;
        }

        public void OnMessageChanged()
        {
            view.ShowMessage(model.Message);
        }
    }
}
