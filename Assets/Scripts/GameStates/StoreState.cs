using Score;
using ScreenManager.Core;
using Screens.StoreScreen;
using UnityEngine;

namespace GameStates
{
    public class StoreState : MetaGameState
    {
        public StoreState(IScoreProvider scoreProvider, ILevelProvider levelProvider,
            ILevelSettingsProvider levelSettingsProvider) : base(scoreProvider,
            levelProvider, levelSettingsProvider)
        {
        }

        public override void OnEnter()
        {
            SubscribeMenuButtons();
            var score = ScoreProvider.Score.Value;
            ScreensManager.OpenScreen<StoreScreen, StoreScreenContext>(new StoreScreenContext(score));
        }

        public override void OnExit()
        {
            base.OnExit();
            ScreensManager.CloseScreen<StoreScreen>();
        }
    }
}