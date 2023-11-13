using DefaultNamespace.Events;
using IngameStateMachine;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace ScreenManager.Loaders.Scenes
{
    public class MainManager : MonoBehaviour
    {
        private StateMachine _stateMachine;
        private CompositeDisposable _subscriptions;

        private void Awake()
        {
            _subscriptions = new CompositeDisposable
            {
               EventStreams.UserInterface.Subscribe<OpenMetaGameScreenEvent>(EnterMenuState)
            };

            CreateAndInitializeStateMachine();
            ScreensManager.OpenScreen<MetaGameScreen, MetaGameContext>(new MetaGameContext());
        }

        private void EnterMenuState(OpenMetaGameScreenEvent obj)
        {
            _stateMachine.Enter<MenuState>();
        }
        
        private void CreateAndInitializeStateMachine()
        {
            _stateMachine = new StateMachine
            (
                new MenuState(),
                new StoreState(),
                new LeaderboardState(),
                new GameState()
            );

            _stateMachine.Initialize();
        }

        private void OnDisable()
        {
            _subscriptions?.Dispose();
        }
    }
}
        