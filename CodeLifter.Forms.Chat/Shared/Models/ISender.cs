using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Models
{
    public interface ISender
    {
        string Username { get; set; }
        string Avatar { get; set; }
        bool IsLocalSender { get; set; }
        Color TextColor { get; set; }
        Color Color { get; set; }
    }
}
