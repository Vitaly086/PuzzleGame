using GameCore.Dice;
using Score;
using ScreenManager.Core;
using Screens.StoreScreen;

namespace GameStates
{
    public class StoreState : MetaGameState
    {
        private IScoreService _scoreService;

        public StoreState(IScoreProvider scoreProvider, ILevelProvider levelProvider,
            ILevelSettingsProvider levelSettingsProvider, IScoreService scoreService) : base(scoreProvider,
            levelProvider, levelSettingsProvider)
        {
            _scoreService = scoreService;
        }

        public override void OnEnter()
        {
            SubscribeMenuButtons();

            var currentRollsCount = LevelProvider.RollsCount.Value;
            var level = LevelSettingsProvider.GetLevelByRolls(currentRollsCount);

            var levelProgress = LevelSettingsProvider.GetLevelProgress(level, currentRollsCount);
            var score = ScoreProvider.Score.Value;

            ScreensManager.OpenScreen<StoreScreen, StoreScreenContext>(new StoreScreenContext(level, levelProgress,
                score, _scoreService));
        }

        public override void OnExit()
        {
            base.OnExit();
            ScreensManager.CloseScreen<StoreScreen>();
        }
    }
}