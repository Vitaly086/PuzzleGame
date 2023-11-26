using Events;
using JetBrains.Annotations;
using ScreenManager.Core;
using UnityEngine;

namespace Screens.MenuScreen
{
    public class MenuScreen : UIScreen<MenuScreenContext>
    {
        [SerializeField] private LevelProgressView _levelProgressView;
        
        public override void Initialize(MenuScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenMenuEvent());
            _levelProgressView.SetSprite(context.LevelProgress);
        }

        [UsedImplicitly]
        public void PressPlayButton()
        {
            EventStreams.UserInterface.Publish(new PlayButtonPressedEvent());
        }
    }
}