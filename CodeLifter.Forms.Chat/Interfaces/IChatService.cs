using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeLifter.Forms.Chat.Models;

namespace CodeLifter.Forms.Chat.Interfaces
{
    public class IncomingMessageEventArgs : EventArgs
    {
        public string MessageText { get; set; }
        public Sender Sender { get; set; }

        public ChatMessage Message
        {
            get
            {
                return new ChatMessage()
                {
                    Text = MessageText,
                    Sender = Sender,
                };
            }
        }

        public IncomingMessageEventArgs(string message, Sender sender)
        {
            MessageText = message;
            Sender = sender;
        }
    }

    public interface IChatService
    {
        IList<ChatMessage> Messages { get; set; }
        event EventHandler ReceivedAgentUtterance;
        Task SubmitUserTurn(ChatMessage userUtterance);
        void OnReceivedAgentUtterance(IncomingMessageEventArgs e);
        void StartConversation();
    }
}
