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
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                Debug.Log("I Attack");
                enemy.ZeroVelocity();
                return;
            }
        }

        if(player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }else if(player.position.x < enemy.transform.position.x) 
        { moveDir = -1; }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocityY);
    }

    public override void exit()
    {
        base.exit();
    }

}

