using Events;
using JetBrains.Annotations;
using Score;
using ScreenManager.Core;
using UnityEngine;

namespace Screens.MenuScreen
{
    public class MenuScreen : UIScreen<MenuScreenContext>
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private LevelProgressView _levelProgressView;
        
        public override void Initialize(MenuScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenMenuEvent());
            _levelProgressView.SetLevelValue(context.Level);
            _levelProgressView.SetSprite(context.LevelProgress);
            
            _scoreView.UpdateView(context.Score);
        }

        [UsedImplicitly]
        public void PressPlayButton()
        {
            EventStreams.UserInterface.Publish(new PlayButtonPressedEvent());
        }
    }
}