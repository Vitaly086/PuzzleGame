using DefaultNamespace;
using IngameStateMachine;
using UnityEngine.SceneManagement;

public class GameState : IState
{
    private StateMachine _stateMachine;
    
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnEnter()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE);
    }

    public void OnExit()
    {
        
    }
}