using Events;
using IngameStateMachine;
using Score;
using ScreenManager.Core;
using Screens.GameScreen;
using SimpleEventBus.Disposables;

namespace GameStates
{
    public class GameState :IState
    {
        private ILevelProvider _levelProvider;
        private ILevelSettingsProvider _levelSettingsProvider;
        private IScoreService _scoreService;
        
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;

        public GameState(ILevelProvider levelProvider, IScoreService scoreService)
        {
            _levelProvider = levelProvider;
            _scoreService = scoreService;
        }
    
        public void Initialize(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnEnter()
        {
            ScreensManager.OpenScreen<GameScreen, GameScreenContext>(new GameScreenContext(_scoreService));
            _subscriptions = new CompositeDisposable
            {
                EventStreams.UserInterface.Subscribe<MenuButtonPressedEvent>(EnterMetaGameState),
                EventStreams.UserInterface.Subscribe<DicePushed>(UpdateLevelProgress),
                EventStreams.UserInterface.Subscribe<DiceRollCompletedEvent>(UpdateScore)
            };
        }

        private void UpdateScore(DiceRollCompletedEvent obj)
        {
            var newScore = obj.Value;
            _scoreService.Receive(newScore);
        }

        private void UpdateLevelProgress(DicePushed obj)
        {
            _levelProvider.RollsCount.Value++;
        }

        private void EnterMetaGameState(MenuButtonPressedEvent obj)
        {
            ScreensManager.CloseScreen<GameScreen>();
            _stateMachine.Enter<MetaGameState>();
        }

        public void OnExit()
        {
            _subscriptions?.Dispose();
        }
    }
}