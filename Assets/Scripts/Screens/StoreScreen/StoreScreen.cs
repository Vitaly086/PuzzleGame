using Events;
using Score;
using ScreenManager.Core;
using Screens.MenuScreen;
using UnityEngine;

namespace Screens.StoreScreen
{
    public class StoreScreen :  UIScreen<StoreScreenContext>
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private LevelProgressView _levelProgressView;
        [SerializeField] private DiceHandPresenter _diceHandPresenter;
        
        public override void Initialize(StoreScreenContext context)
        {
            EventStreams.UserInterface.Publish(new OpenStoreEvent());
            
            _levelProgressView.SetLevelValue(context.Level);
            _levelProgressView.SetSprite(context.LevelProgress);
            _scoreView.UpdateView(context.Score);

            _diceHandPresenter.Initialize();
        }
    }
}