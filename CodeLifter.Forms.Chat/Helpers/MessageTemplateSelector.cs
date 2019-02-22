
using CodeLifter.Forms.Chat.Models;
using CodeLifter.Forms.Chat.Views.Cells;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Helpers
{
    class MessageTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;

        public MessageTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingMessageViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingMessageViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as Message;
            if (messageVm == null)
                return null;

            return (messageVm.Sender.IsLocalSender == true) ? outgoingDataTemplate : incomingDataTemplate;
        }

    }
}