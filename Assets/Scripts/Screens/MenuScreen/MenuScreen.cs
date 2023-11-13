using DefaultNamespace.Events;
using JetBrains.Annotations;
using ScreenManager.Core;

public class MenuScreen :  UIScreen<MenuScreenContext>
{
    public override void Initialize(MenuScreenContext context)
    {
        EventStreams.UserInterface.Publish(new OpenMenuEvent());
    }
    
    [UsedImplicitly]
    public void PressPlayButton()
    {
        EventStreams.UserInterface.Publish(new PlayButtonPressedEvent());
    }
}