using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeLifter.Forms.Chat.Interfaces;
using CodeLifter.Forms.Chat.Models;
using CodeLifter.Http;
using Demo.Models;
using MvvmHelpers;
using RestSharp;

namespace Demo.Services
{
    public class MimicBotService : IChatService
    {
        private string Greeting = "Hello! I am a 'Mimic Bot'!";
        private Sender MimicBot { get; set; }
        public IList<ChatMessage> Messages { get; set; } = new ObservableRangeCollection<ChatMessage>();

        public MimicBotService()
        {
            MimicBot = new Sender()
            {
                Username = "Pazz",
                Avatar = "https://m.media-amazon.com/images/M/MV5BMzg5NjQ0MGYtZDg2Yy00NWFjLWE2MmQtMWY5OTc2ZDgzNTk3XkEyXkFqcGdeQXVyNTI5NjIyMw@@._V1_UY317_CR129,0,214,317_AL_.jpg",
            };
        }

        public async Task SubmitUserTurn(ChatMessage utterance)
        {
            Messages.Add(utterance);
            OnReceivedAgentUtterance(new IncomingMessageEventArgs(utterance.Text, MimicBot));
        }

        public void StartConversation()
        {
            OnReceivedAgentUtterance(new IncomingMessageEventArgs(Greeting, MimicBot));
        }

        public event EventHandler ReceivedAgentUtterance;
        public virtual void OnReceivedAgentUtterance(IncomingMessageEventArgs e)
        {
            Messages.Add((e as IncomingMessageEventArgs).Message);
            ReceivedAgentUtterance?.Invoke(this, e);
        }

    }
}
