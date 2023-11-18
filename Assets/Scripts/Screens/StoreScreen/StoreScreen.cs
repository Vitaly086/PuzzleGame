using Events;
using ScreenManager.Core;

namespace Screens.StoreScreen
{
    public class StoreScreen :  UIScreen<StoreScreenContext>
    {
        public override void Initialize(StoreScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenStoreEvent());
        }
    }
}