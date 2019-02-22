using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeLifter.Forms.Chat.Models;
using MvvmHelpers;
using Demo.Models;
using Demo.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Demo.ViewModels
{
    public class InteractionPageVM : BaseViewModel
    {
        public IList<CodeLifter.Forms.Chat.Models.Message> Messages { get; set; } = new ObservableRangeCollection<CodeLifter.Forms.Chat.Models.Message>();

        public ICommand SendMessageCommand { private set; get; }

        private ISpeechToText SpeechToTextService { get; set; }
        private IDialogFlowService PazzService { get; set; }

        private Sender LocalSender { get; set; }
        private Sender PazzBot { get; set; }

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

        public InteractionPageVM(IDialogFlowService pazzService, ISpeechToText speechToTextService)
        {
            Title = "Pazz";

            SpeechToTextService = speechToTextService;
            //SpeechToTextService.StopSpeechToText();
            PazzService = pazzService;

            LocalSender = new Sender()
            {
                Username = "Andrew Palmer",
                Avatar = "https://en.gravatar.com/userimage/136504514/a5986e5d446a36bb07527596e5edc5ca.jpg?size=200",
                IsLocalSender = true,
                Color = Color.LightGreen,
            };

            PazzBot = new Sender()
            {
                Username = "Pazz",
                Avatar = "https://m.media-amazon.com/images/M/MV5BMzg5NjQ0MGYtZDg2Yy00NWFjLWE2MmQtMWY5OTc2ZDgzNTk3XkEyXkFqcGdeQXVyNTI5NjIyMw@@._V1_UY317_CR129,0,214,317_AL_.jpg",
            };

            MessagingCenter.Subscribe<ISpeechToText, string>(this, "STT", (sender, args) => {
                CurrentUserVocalization = args;
            });

            MessagingCenter.Subscribe<ISpeechToText>(this, "Final", async (sender) => {
                await SubmitUserMessage(CurrentUserVocalization);
            });

            SendMessageCommand = new Command(
                execute: async () =>
                {
                    string message = CurrentUserUtterance;
                    CurrentUserUtterance = string.Empty;
                    await SubmitUserMessage(message);
                },
                canExecute: () =>
                {
                    return true;
                });

            PazzService.ReceivedAgentUtterance += PazzService_ReceivedAgentUtterance;

            PazzService.StartConversation();
        }

        public async Task SubmitUserMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            SpeechToTextService.StopSpeechToText();

            Messages.Add(new CodeLifter.Forms.Chat.Models.Message()
            {
                Sender = LocalSender,
                Text = message,
            });

            await PazzService.SubmitUserTurn(message);
        }

        void PazzService_ReceivedAgentUtterance(object sender, System.EventArgs e)
        {
            string message = (e as IncomingMessageEventArgs).MessageText;
            Messages.Add(new CodeLifter.Forms.Chat.Models.Message()
            {
                Sender = PazzBot,
                Text = message,
            });
            SpeakNow(message);
        }

        public async void SpeakNow(string text)
        {
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f
            };

            await TextToSpeech.SpeakAsync(text).ContinueWith((t) =>
            {
                SpeechToTextService.StartSpeechToText();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
