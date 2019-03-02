using System;
using System.Collections.Generic;
using System.Text;

namespace CodeLifter.Forms.Chat.Models
{
    interface ISender
    {
        string Username { get; set; }
        string Avatar { get; set; }
        bool IsLocalSender { get; set; }
        Color TextColor { get; set; }
        Color Color { get; set; }
    }
}
