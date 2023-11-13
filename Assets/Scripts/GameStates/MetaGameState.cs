using DefaultNamespace.Events;
using IngameStateMachine;
using SimpleEventBus.Disposables;

public class MetaGameState :IState
{
    protected StateMachine StateMachine;
    private CompositeDisposable _subscriptions;
    
    public void Initialize(StateMachine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public virtual void OnEnter()
    {
        _subscriptions = new CompositeDisposable
        {
            EventStreams.UserInterface.Subscribe<StoreButtonPressedEvent>(EnterStoreState),
            EventStreams.UserInterface.Subscribe<MenuButtonPressedEvent>(EnterMenuState),
            EventStreams.UserInterface.Subscribe<LeaderboardButtonPressedEvent>(EnterLeaderboardState),
        };
    }

    private void EnterStoreState(StoreButtonPressedEvent obj)
    {
        StateMachine.Enter<StoreState>();
    }

    private void EnterMenuState(MenuButtonPressedEvent obj)
    {
        StateMachine.Enter<MenuState>();
    }

    private void EnterLeaderboardState(LeaderboardButtonPressedEvent obj)
    {
        StateMachine.Enter<LeaderboardState>();
    }

    public virtual void OnExit()
    {
        _subscriptions?.Dispose();
    }
}