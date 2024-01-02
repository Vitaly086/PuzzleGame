using LevelsSettings;
using ScreenManager.Core;
using Screens.LeaderboardScreen;
using User;

namespace GameStates
{
    public class LeaderboardState : MetaGameState
    {
        public LeaderboardState(IScoreProvider scoreProvider, ILevelProvider levelProvider,
            ILevelSettingsProvider levelSettingsProvider) : base(scoreProvider,
            levelProvider, levelSettingsProvider)
        {
        }

        public override void OnEnter()
        {
            SubscribeMenuButtons();
            ScreensManager.OpenScreen<LeaderboardScreen, LeaderboardScreenContext>(new LeaderboardScreenContext());
        }

        public override void OnExit()
        {
            base.OnExit();
            ScreensManager.CloseScreen<LeaderboardScreen>();
        }
    }
}