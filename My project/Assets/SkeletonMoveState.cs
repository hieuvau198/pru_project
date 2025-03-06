using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }




    //#region States
    //public SkeletonIdleState idleState { get; private set; }
    //public SkeletonMoveState moveState { get; private set; }

    //#endregion


    public override void Enter()
    {
        base.Enter();
    }

    public override void exit()
    {
        base.exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.linearVelocity.y);
        

        if (enemy.IsWallDetected() || !enemy.IsGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);


        }
    }
}

