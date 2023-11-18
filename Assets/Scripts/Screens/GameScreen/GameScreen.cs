using Events;
using JetBrains.Annotations;
using ScreenManager.Core;

namespace Screens.GameScreen
{
    public class GameScreen :  UIScreen<GameScreenContext>
    {
        public override void Initialize(GameScreenContext context)
        {
        
        }
    
        [UsedImplicitly]
        public void PressMenuButton()
        { 
            EventStreams.UserInterface.Publish(new MenuButtonPressedEvent());
        }
    }
}