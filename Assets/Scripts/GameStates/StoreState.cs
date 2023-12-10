using ScreenManager.Core;
using Screens.StoreScreen;

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
            
            var currentRollsCount = LevelProvider.RollsCount.Value;
            var level = LevelSettingsProvider.GetLevelByRolls(currentRollsCount);

            var levelProgress = LevelSettingsProvider.GetLevelProgress(level, currentRollsCount);
            var score = ScoreProvider.Score.Value;
            ScreensManager.OpenScreen<StoreScreen, StoreScreenContext>(new StoreScreenContext(level, levelProgress, score));
        }

        public override void OnExit()
        {
            base.OnExit();
            ScreensManager.CloseScreen<StoreScreen>();
        }
    }
}