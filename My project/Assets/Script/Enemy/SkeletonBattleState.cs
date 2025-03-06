using UnityEngine;

public class SkeletonBattleState : EnemyState

{
    private Transform player;
    private Enemy_Skeleton enemy;
    private int moveDir;
    public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;

    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }
    public override void Update()
    {
        base.Update();

        // Check if the player is detected
        RaycastHit2D playerHit = enemy.IsPlayerDetected();

        if (playerHit)
        {
            float playerDistance = playerHit.distance;
            Debug.Log($"[Player Detection] Player detected at distance: {playerDistance}, Attack Distance: {enemy.attackDistance}");

            // If player is within attack range, change to attack state
            if (playerDistance < enemy.attackDistance)
            {
                Debug.Log("[State Change] Switching to Attack State");
                stateMachine.ChangeState(enemy.attackState);
                return; // Stop movement if attacking
            }
        }

        // Determine movement direction based on player's position
        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        // WARNING: You are overriding moveDir with "moveDir = 1;" -> Removing it
        // moveDir = 1;  <-- This line was forcing the enemy to always move right. Removed!

        // Set velocity based on move direction
        float velocityX = enemy.moveSpeed * moveDir;
        float velocityY = rb.linearVelocity.y; // Using linearVelocity.y for compatibility

        Debug.Log($"[Movement] MoveDir: {moveDir}, Calculated VelocityX: {velocityX}, Current LinearVelocity: ({rb.linearVelocity.x}, {rb.linearVelocity.y})");

        // Apply movement
        enemy.SetVelocity(velocityX, velocityY);
    }


    public override void exit()
    {
        base.exit();
    }

}

