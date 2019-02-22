using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CodeLifter.Forms.Chat.Models;
using Xamarin.Forms;

namespace CodeLifter.Forms.Chat.Views
{
    public partial class DialogView : ContentView
    { 
        public static readonly BindableProperty MessagesSourceProperty = BindableProperty.Create(
          "MessagesSource", 
          typeof(IList<Message>),
          typeof(DialogView), 
          new ObservableCollection<Message>()); 

        public IList<Message> MessagesSource
        {
            get { return (IList<Message>)GetValue(MessagesSourceProperty); }
            set { SetValue(MessagesSourceProperty, value); }
        }

        public DialogView()
        {
            InitializeComponent();
        }
    }
}
