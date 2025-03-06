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

        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if(CanAttack())
                    stateMachine.ChangeState(enemy.attackState);
            }
        }
        else
        {
            if(stateTimer < 0 
                || Vector2.Distance(player.transform.position, enemy.transform.position) > 3)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }

        if (player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if (player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        float velocityX = enemy.moveSpeed * moveDir;
        float velocityY = rb.linearVelocity.y; 

        enemy.SetVelocity(velocityX, velocityY);
    }


    public override void exit()
    {
        base.exit();
    }

    private bool CanAttack()
    {
        if(Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }
        return false;
    }
}

