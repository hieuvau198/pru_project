using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }


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

        float velocityX = enemy.moveSpeed * enemy.facingDir;
        float velocityY = rb.linearVelocity.y; 


        enemy.SetVelocity(velocityX, velocityY);

        bool wallDetected = enemy.IsWallDetected();
        bool groundDetected = enemy.IsGroundDetected();

        if (wallDetected || !groundDetected)
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }

}

