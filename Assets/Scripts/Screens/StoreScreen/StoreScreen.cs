using DefaultNamespace.Events;
using ScreenManager.Core;

public class StoreScreen :  UIScreen<StoreScreenContext>
{
    public override void Initialize(StoreScreenContext context)
    {
        EventStreams.UserInterface.Publish(new OpenStoreEvent());
    }
}