using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeLifter.Http;
using Pazz.Mobile.Models;
using RestSharp;

namespace Pazz.Mobile.Services
{
    public class IncomingMessageEventArgs : EventArgs
    {
        public string MessageText { get; set; }
        public IncomingMessageEventArgs(string message)
        {
            MessageText = message;
        }
    }

    public class PazzService : IDialogFlowService
    {
        List<QueryResponse> Conversation { get; set; }

        private string Greeting = "Hello! I am Pazz!";
        private IRestApiClient ApiClient { get; set; }
        private Guid SessionId { get; set; }

        private string _conversationText { get; set; }
        public string ConversationText
        {
            get
            {
                return _conversationText;
            }
            private set
            {
                _conversationText = value;
            }
        }

        private string _mostRecentUserUtterance { get; set; }
        public string MostRecentUserUtterance
        {
            get
            {
                return _mostRecentUserUtterance;
            }
            private set
            {
                _mostRecentUserUtterance = value;
                ConversationText += $"USER: {_mostRecentUserUtterance}\n";
            }
        }

        private string _mostRecentAgentUtterance { get; set; }
        public string MostRecentAgentUtterance
        {
            get
            {
                return _mostRecentAgentUtterance;
            }
            private set
            {
                _mostRecentAgentUtterance = value;
                ConversationText += $"PAZZ: {_mostRecentAgentUtterance}\n";
                OnReceivedAgentUtterance(new IncomingMessageEventArgs(_mostRecentAgentUtterance));
            }
        }

        public PazzService(IRestApiClient restApiClient)
        {
            ApiClient = restApiClient;
            restApiClient.AddHeader("Authorization", $"Bearer 9f5560093bda4fd182fb107a99d3d27e");
            SessionId = Guid.NewGuid();
            Conversation = new List<QueryResponse>();
        }

        public async Task SubmitUserTurn(string utterance)
        {
            MostRecentUserUtterance = utterance;

            string contexts = string.Empty;
            if(Conversation.Count == 0)
            {
                contexts = "ctx-core";
            }
            else
            {
                QueryResponse lastResponse = Conversation[Conversation.Count - 1];
                foreach(Context context in lastResponse.Result.Contexts)
                {
                    contexts += $"{context.Name},";
                }
            }

            string queryString = $"?v=20150910&contexts={contexts}&lang=en&query={utterance}&sessionId={SessionId}&timezone=America/New_York";

            RestRequest request = new RestRequest($"query{queryString}", RestSharp.Method.GET);
            QueryResponse response = await ApiClient.Get<QueryResponse>(request);
            Conversation.Add(response);
            MostRecentAgentUtterance = response.Result.Fulfillment.Speech;
        }

        public void StartConversation()
        {
            MostRecentAgentUtterance = $"{Greeting}";
        }

        public event EventHandler ReceivedAgentUtterance;
        public virtual void OnReceivedAgentUtterance(IncomingMessageEventArgs e)
        {
            ReceivedAgentUtterance?.Invoke(this, e);
        }

    }
}
