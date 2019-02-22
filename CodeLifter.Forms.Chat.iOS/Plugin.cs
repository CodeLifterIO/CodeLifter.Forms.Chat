using System;
namespace CodeLifter.Forms.Chat.iOS
{
    public class Plugin
    {
        public static void Init() 
        {
            Renderers.UtteranceEntryRenderer.Init();
        }
    }
}
