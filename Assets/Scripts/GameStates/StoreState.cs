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
            ScreensManager.OpenScreen<StoreScreen, StoreScreenContext>(new StoreScreenContext());
        }

        public override void OnExit()
        {
            base.OnExit();
            ScreensManager.CloseScreen<StoreScreen>();
        }
    }
}