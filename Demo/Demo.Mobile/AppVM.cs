using CommonServiceLocator;
using MvvmHelpers;
using Demo.ViewModels;
using Unity;
using Unity.ServiceLocation;
using CodeLifter.Forms.Chat.Services;
using CodeLifter.Forms.Chat.Shared.Services;

namespace Demo
{
    public class AppVM : BaseViewModel
    {
        public static IUnityContainer IOCContainer { get; private set; }

        public AppVM()
        {
            //init dependent Plugins and components
            InitializeDependencies();

            //set up our IOC container
            InitializeIOCContainer();
        }

        public void InitializeIOCContainer()
        {
            IOCContainer = new UnityContainer();

            var unityServiceLocator = new UnityServiceLocator(IOCContainer);
            ServiceLocator.SetLocatorProvider(() => unityServiceLocator);

            IOCContainer.RegisterInstance(this);
            IOCContainer.RegisterType<IChatService, MimicBotService>();
            IOCContainer.RegisterType<InteractionPageVM>();
        }

        public void InitializeDependencies()
        {
        }
    }
}
