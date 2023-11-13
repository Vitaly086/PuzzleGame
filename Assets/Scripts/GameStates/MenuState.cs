using DefaultNamespace.Events;
using SimpleEventBus.Disposables;

public class MenuState : MetaGameState
{
    private CompositeDisposable _subscriptions;
    
    public override void OnEnter()
    {
        SubscribeMenuButtons();
        ScreensManager.OpenScreen<MenuScreen, MenuScreenContext>(new MenuScreenContext());
        
        _subscriptions = new CompositeDisposable
        {
            EventStreams.UserInterface.Subscribe<PlayButtonPressedEvent>(EnterGameState)
        };
    }

    private void EnterGameState(PlayButtonPressedEvent obj)
    {
        ScreensManager.CloseScreen<MetaGameScreen>();
        StateMachine.Enter<GameState>();
    }

    public override void OnExit()
    {
        base.OnExit();
        _subscriptions?.Dispose();
        ScreensManager.CloseScreen<MenuScreen>();
    }
}