using System;
using System.Threading.Tasks;

namespace Pazz.Mobile.Services
{
    public interface IDialogFlowService
    {
        event EventHandler ReceivedAgentUtterance;
        string ConversationText { get; }
        string MostRecentUserUtterance { get; }
        string MostRecentAgentUtterance { get; }
        Task SubmitUserTurn(string userUtterance);
        void OnReceivedAgentUtterance(IncomingMessageEventArgs e);
        void StartConversation();
    }
}
