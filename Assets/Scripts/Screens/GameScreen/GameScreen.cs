using DefaultNamespace.Events;
using JetBrains.Annotations;
using ScreenManager.Core;

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