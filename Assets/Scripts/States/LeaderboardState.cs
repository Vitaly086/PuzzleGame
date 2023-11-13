using DefaultNamespace;
using UnityEngine.SceneManagement;
using IngameStateMachine;

public class LeaderboardState : IState
{
    private StateMachine _stateMachine;
    
    public void Initialize(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }
}