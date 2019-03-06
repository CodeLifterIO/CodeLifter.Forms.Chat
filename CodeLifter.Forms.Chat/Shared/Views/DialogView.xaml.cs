using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using CodeLifter.Forms.Chat.Models;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Xaml.XamlCompilation(Xamarin.Forms.Xaml.XamlCompilationOptions.Compile)]
namespace CodeLifter.Forms.Chat.Views
{
    /// <summary>
    /// The conversation view
    /// </summary>
    public partial class DialogView : ContentView
    { 
        public static readonly BindableProperty MessagesSourceProperty = BindableProperty.Create(
          "MessagesSource", 
          typeof(ObservableCollection<IChatMessage>),
          typeof(DialogView), 
          new ObservableCollection<IChatMessage>()); 

        public ObservableCollection<IChatMessage> MessagesSource
        {
            get { return (ObservableCollection<IChatMessage>)GetValue(MessagesSourceProperty); }
            set
            {
                SetValue(MessagesSourceProperty, value);
                value.CollectionChanged += MessagesSource_CollectionChanged;
            }
        }

        public DialogView()
        {
            InitializeComponent();
        }

        private void MessagesSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            chatListView.ScrollTo(e.NewItems[0], ScrollToPosition.End , true);
        }
    }
}
