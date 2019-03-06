using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeLifter.Forms.Chat.Models;
using MvvmHelpers;
using Xamarin.Forms;
using CodeLifter.Forms.Chat.Services;

namespace Demo.ViewModels
{
    public class InteractionPageVM : BaseViewModel
    {
        public IList<IChatMessage> Messages { get; set; }

        public ICommand SendMessageCommand { private set; get; }
        private IChatService MimicBotService { get; set; }
        private Sender LocalSender { get; set; }
        private string CurrentUserVocalization { get; set; }

        private string _currentUserUtterance { get; set; }
        public string CurrentUserUtterance
        {
            get
            {
                return _currentUserUtterance;
            }
            set
            {
                if(value != _currentUserUtterance)
                {
                    _currentUserUtterance = value;
                    OnPropertyChanged("CurrentUserUtterance");
                }
            }
        }

        public InteractionPageVM(IChatService mimicService)
        {
            Title = "Interact";
            MimicBotService = mimicService;
            Messages = MimicBotService.Messages;

            LocalSender = new Sender()
            {
                Username = "Andrew Palmer",
                Avatar = "https://en.gravatar.com/userimage/136504514/a5986e5d446a36bb07527596e5edc5ca.jpg?size=200",
                IsLocalSender = true,
                Color = Color.LightGreen,
            };

            SendMessageCommand = new Command(
                execute: async () =>
                {
                    await SubmitUserMessage();
                },
                canExecute: () =>
                {
                    return (!string.IsNullOrWhiteSpace(CurrentUserUtterance));
                });

            MimicBotService.StartConversation();
        }

        public async Task SubmitUserMessage()
        {
            if (string.IsNullOrWhiteSpace(CurrentUserUtterance))
            {
                return;
            }

            ChatMessage chatMessage = new CodeLifter.Forms.Chat.Models.ChatMessage()
            {
                Sender = LocalSender,
                Text = CurrentUserUtterance,
            };

            await MimicBotService.SubmitUserTurn(chatMessage);
        }
    }
}
