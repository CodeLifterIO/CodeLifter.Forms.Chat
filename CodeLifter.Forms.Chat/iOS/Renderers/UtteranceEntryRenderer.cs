using System.ComponentModel;
using CodeLifter.Forms.Chat.iOS.Renderers;
using CodeLifter.Forms.Chat.Views;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(UtteranceEntry), typeof(UtteranceEntryRenderer))]
namespace CodeLifter.Forms.Chat.iOS.Renderers
{
    public class UtteranceEntryRenderer : ViewRenderer
    {
        public new static void Init() { }

        private NSObject ShowObserver { get; set; }
        private NSObject HideObserver { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                if (ShowObserver != null)
                {
                    ShowObserver.Dispose();
                    ShowObserver = null;
                }

                if (HideObserver != null)
                {
                    HideObserver.Dispose();
                    HideObserver = null;
                }
            }

            if (e.NewElement != null)
            {
                if (ShowObserver == null)
                    ShowObserver = UIKeyboard.Notifications.ObserveWillShow(OnShowKeyboard);
                if (HideObserver == null)
                    HideObserver = UIKeyboard.Notifications.ObserveWillHide(OnHideKeyboard);
            }
        }

        void OnShowKeyboard(object sender, UIKeyboardEventArgs args)
        {
            if (Element != null)
            {
                Element.Margin = new Thickness(0, 0, 0, GetKeyboardSize(args)); 
            }
        }

        void OnHideKeyboard(object sender, UIKeyboardEventArgs args)
        {
            if (Element != null)
            {
                Element.Margin = new Thickness(0); 
            }
        }

        System.nfloat GetKeyboardSize(UIKeyboardEventArgs args)
        {
            NSValue result = (NSValue)args.Notification.UserInfo.ObjectForKey(new NSString(UIKeyboard.FrameEndUserInfoKey));
            CGSize keyboardSize = result.RectangleFValue.Size;
            return keyboardSize.Height;
        }
    }
}
