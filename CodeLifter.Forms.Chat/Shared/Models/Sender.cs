using System;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Models
{
    public class Sender : ISender
    {
        public Sender()
        {
            TextColor = Color.White;
            Color = Color.LightBlue;
        }

        public string Username { get; set; }
        public string Avatar { get; set; }
        public bool IsLocalSender { get; set; }
        public Color TextColor { get; set; }
        public Color Color { get; set; }
    }
}
