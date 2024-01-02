using Events;
using IngameStateMachine;
using LevelsSettings;
using ScreenManager.Core;
using Screens.MetaGameScreen;
using SimpleEventBus.Disposables;
using User;

namespace GameStates
{
    public class MetaGameState : IState
    {
        protected StateMachine StateMachine;
        protected readonly IScoreProvider ScoreProvider;
        protected readonly ILevelProvider LevelProvider;
        protected readonly ILevelSettingsProvider LevelSettingsProvider;
        private CompositeDisposable _subscriptions;

        public MetaGameState(IScoreProvider scoreProvider, ILevelProvider levelProvider,
            ILevelSettingsProvider levelSettingsProvider)
        {
            LevelProvider = levelProvider;
            LevelSettingsProvider = levelSettingsProvider;
            ScoreProvider = scoreProvider;
        }

        public void Initialize(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void OnEnter()
        {
            SubscribeMenuButtons();

            ScreensManager.OpenScreen<MetaGameScreen, MetaGameContext>(new MetaGameContext());
            StateMachine.Enter<MenuState>();
        }

        protected void SubscribeMenuButtons()
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
}