using ScreenManager.Core;
using Screens.StoreScreen;

namespace GameStates
{
    public class StoreState : MetaGameState
    {
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