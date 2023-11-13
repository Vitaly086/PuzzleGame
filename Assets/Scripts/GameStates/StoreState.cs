public class StoreState : MetaGameState
{
    public override void OnEnter()
    {
        base.OnEnter();
        
        ScreensManager.OpenScreen<StoreScreen, StoreScreenContext>(new StoreScreenContext());
    }

    public override void OnExit()
    {
        base.OnExit();
        ScreensManager.CloseScreen<StoreScreen>();
    }
}