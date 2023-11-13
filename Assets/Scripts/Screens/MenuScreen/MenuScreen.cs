using DefaultNamespace.Events;
using ScreenManager.Core;

public class MenuScreen :  UIScreen<MenuScreenContext>
{
    public override void Initialize(MenuScreenContext context)
    {
        EventStreams.UserInterface.Publish(new OpenMenuEvent());
    }
}