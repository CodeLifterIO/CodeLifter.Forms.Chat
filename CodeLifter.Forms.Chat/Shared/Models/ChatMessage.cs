using System;

namespace CodeLifter.Forms.Chat.Models
{
    public class ChatMessage : IChatMessage
    {
        public string Text { get; set; }
        public ISender Sender { get; set; }
        public object Data { get; set; }
    }
}
