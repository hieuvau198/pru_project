using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton _enemy) : base(enemyBase, stateMachine, animBoolName, _enemy)
    {
    }



    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}

