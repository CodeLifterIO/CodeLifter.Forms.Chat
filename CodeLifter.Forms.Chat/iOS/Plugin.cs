using ImageCircle.Forms.Plugin.iOS;

namespace CodeLifter.Forms.Chat.iOS
{
    /// <summary>
    /// iOS chat Plugin intializer
    /// </summary>
    public class Plugin
    {
        /// <summary>
        /// iOS Chat Plugin initializar
        /// </summary>
        public static void Init() 
        {
            //Renderers.UtteranceEntryRenderer.Init();
            ImageCircleRenderer.Init();
        }
    }
}
