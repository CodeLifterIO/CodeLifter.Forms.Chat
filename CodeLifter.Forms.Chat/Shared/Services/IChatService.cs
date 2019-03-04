using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeLifter.Forms.Chat.Models;

namespace CodeLifter.Forms.Chat.Services
{
    public class IncomingMessageEventArgs : EventArgs
    {
        public IChatMessage Message { get; set; }

        public IncomingMessageEventArgs(string text, ISender sender)
        {
            Message = new ChatMessage()
            {
                Text = text,
                Sender = sender,
            };
        }

        public IncomingMessageEventArgs(IChatMessage message)
        {
            Message = message;
        }
    }

    public interface IChatService
    {
        IList<IChatMessage> Messages { get; set; }
        event EventHandler ReceivedAgentUtterance;
        Task SubmitUserTurn(IChatMessage userUtterance);
        void OnReceivedAgentUtterance(IncomingMessageEventArgs e);
        void StartConversation(string message = null);
    }
}
