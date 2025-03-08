using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    private Enemy_Skeleton enemy;
    public SkeletonStunnedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string animBoolName,Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.fx.InvokeRepeating("RedColorBlink", 0, .1f);
        stateTimer = enemy.stunDuration;
        rb.linearVelocity = new Vector2(-enemy.facingDir * enemy.stunDirection.x, enemy.stunDirection.y);
    }

    public override void exit()
    {
        base.exit();
        enemy.fx.Invoke("CancelRedBlink",0);
    }

    public override void Update()
    {
        base.Update();
        if(stateTimer<0)
            stateMachine.ChangeState(enemy.idleState);
    }
}
