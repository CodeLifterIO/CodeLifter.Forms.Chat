using System;
using System.Threading.Tasks;

namespace Demo.Services
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
