using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    private string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        player = _player;
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("I enter" + animBoolName);
    }

    public virtual void Update()
    {
        Debug.Log("Im in" + animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("I exit" + animBoolName);

    }
}
