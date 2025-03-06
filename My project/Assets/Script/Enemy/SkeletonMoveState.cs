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

        // Log movement inputs
        float velocityX = enemy.moveSpeed * enemy.facingDir;
        float velocityY = rb.linearVelocity.y; // Use linearVelocity instead of velocity

        Debug.Log($"[Update] MoveSpeed: {enemy.moveSpeed}, FacingDir: {enemy.facingDir}, Calculated VelocityX: {velocityX}, Current LinearVelocity: ({rb.linearVelocity.x}, {rb.linearVelocity.y})");

        // Apply velocity
        enemy.SetVelocity(velocityX, velocityY);

        // Check collisions and log them
        bool wallDetected = enemy.IsWallDetected();
        bool groundDetected = enemy.IsGroundDetected();

        Debug.Log($"[Collision] WallDetected: {wallDetected}, GroundDetected: {groundDetected}");

        // Handle flipping and state change
        if (wallDetected || !groundDetected)
        {
            Debug.Log("[State Change] Flipping and switching to Idle State");
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }

}

