using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CodeLifter.Forms.Chat.Models;
using CodeLifter.Forms.Chat.Services;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Shared.Services
{
    public class MimicBotService : IChatService
    {
        public ObservableCollection<IChatMessage> Messages { get; set; } = new ObservableCollection<IChatMessage>();

        private List<Sender> Mimics { get; set; } = new List<Sender>();

        public MimicBotService()
        {
            Mimics.Add(new Sender()
            {
                Username = "A. Mimic",
                Avatar = "https://cdnb.artstation.com/p/assets/images/images/010/158/137/large/luis-miguel-jocson-mimic-final.jpg?1523357844",
                Color = Color.Green
            });

            Mimics.Add(new Sender()
            {
                Username = "A. CopyCat",
                Avatar = "https://cdnb.artstation.com/p/assets/images/images/011/485/349/large/lukas-stoddard-mimic-chest.jpg?1529842500",
                Color = Color.AliceBlue,
                TextColor = Color.DarkGray
            });
        }

        public async Task SubmitUserTurn(IChatMessage utterance)
        {
            Messages.Add(utterance);

            foreach (Sender s in Mimics)
            {
                OnReceivedAgentUtterance(new IncomingMessageEventArgs($"{s.Username}: {utterance.Text}", s));
            }
        }

        public void StartConversation(string message = null)
        {
            string firstMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(message))
                firstMessage = "Hello! I am a 'Mimic Bot'!";
            else
                firstMessage = message;

            foreach (Sender s in Mimics)
            {
                OnReceivedAgentUtterance(new IncomingMessageEventArgs($"{firstMessage} My name is '{s.Username}'", s));
            }
        }

        public event EventHandler ReceivedAgentUtterance;
        public virtual void OnReceivedAgentUtterance(IncomingMessageEventArgs e)
        {
            Messages.Add((e as IncomingMessageEventArgs).Message);
            ReceivedAgentUtterance?.Invoke(this, e);
        }

    }
}
