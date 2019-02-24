using System;
using ImageCircle.Forms.Plugin.iOS;

namespace CodeLifter.Forms.Chat.iOS
{
    public class Plugin
    {
        public static void Init() 
        {
            Renderers.UtteranceEntryRenderer.Init();
            ImageCircleRenderer.Init();
        }
    }
}
