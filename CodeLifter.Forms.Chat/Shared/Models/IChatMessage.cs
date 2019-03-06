using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLifter.Forms.Chat.Models
{
    public interface IChatMessage
    {
        string Text { get; set; }
        ISender Sender { get; set; }
        object Data { get; set; }
    }
}
