using Events;
using JetBrains.Annotations;
using ScreenManager.Core;

namespace Screens.MenuScreen
{
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
}