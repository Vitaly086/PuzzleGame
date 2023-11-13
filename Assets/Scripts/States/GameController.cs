using IngameStateMachine;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private StateMachine _stateMachine;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        CreateAndInitializeStateMachine();
    }

    private void CreateAndInitializeStateMachine()
    {
        _stateMachine = new StateMachine
        (
            new MenuState(),
            new GameState(),
            new ShopState(),
            new LeaderboardState()
        );

        _stateMachine.Initialize();
        _stateMachine.Enter<MenuState>();
    }
}