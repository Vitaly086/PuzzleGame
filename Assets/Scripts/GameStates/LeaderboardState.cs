public class LeaderboardState : MetaGameState
{
    public override void OnEnter()
    {
        base.OnEnter();
        
        ScreensManager.OpenScreen<LeaderboardScreen, LeaderboardScreenContext>(new LeaderboardScreenContext());
    }

    public override void OnExit()
    {
        base.OnExit();
        ScreensManager.CloseScreen<LeaderboardScreen>();
    }
}