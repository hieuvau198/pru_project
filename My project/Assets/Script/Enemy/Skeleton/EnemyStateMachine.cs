using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class EnemyStateMachine
{
    public EnemyState currentState { get; private set; }

    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(EnemyState _newState)
    {
        currentState.exit();
        currentState = _newState;
        currentState.Enter();
    }
}

