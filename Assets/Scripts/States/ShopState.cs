using DefaultNamespace;
using IngameStateMachine;
using UnityEngine.SceneManagement;

public class ShopState : IState
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