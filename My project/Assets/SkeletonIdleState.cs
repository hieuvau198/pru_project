using UnityEngine;

public class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }



    //#region States
    //public SkeletonIdleState idleState { get; private set; }
    //public SkeletonMoveState moveState { get; private set; }

    //#endregion



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

