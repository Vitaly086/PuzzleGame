public class LeaderboardState : MetaGameState
{
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