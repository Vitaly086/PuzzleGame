using DefaultNamespace.Events;
using IngameStateMachine;
using SimpleEventBus.Disposables;
using UnityEngine;

namespace ScreenManager.Loaders.Scenes
{
    public class MainManager : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Awake()
        {
            CreateAndInitializeStateMachine();
        }
        
        private void CreateAndInitializeStateMachine()
        {
            _stateMachine = new StateMachine
            (
                new MetaGameState(),
                new MenuState(),
                new StoreState(),
                new LeaderboardState(),
                new GameState()
            );

            _stateMachine.Initialize();
            _stateMachine.Enter<MetaGameState>();
        }
    }
}
        