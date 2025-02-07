using SimpleEventBus.Events;

namespace ScreenManager.Loaders
{
    public class RegisterNewBundleUrlEvent : EventBase
    {
        public RegisterNewBundleUrlEvent(string scene, string url)
        {
            Scene = scene;
            Url = url;
        }

        public string Url;
        public string Scene;
    }
}
