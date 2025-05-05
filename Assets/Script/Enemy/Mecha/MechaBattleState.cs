using UnityEngine;

public class MechaBattleState : EnemyState
{
    private Enemy_MechaGolem enemy;
    private Transform player;
    public MechaBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemyBase as Enemy_MechaGolem;
    }

    public override void Enter()
    {
        base.Enter();
        player = PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected())
        {
            stateTimer = enemy.battleTime;

            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                    if (Random.value < 0.5f)
                        stateMachine.ChangeState(enemy.attackState);
                    else
                        stateMachine.ChangeState(enemy.laserState);
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 7)
                stateMachine.ChangeState(enemy.idleState);
        }

        BattleStateFlipControll();
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackCooldown)
        {
            enemy.attackCooldown = Random.Range(enemy.minAttackCooldown, enemy.maxAttackCooldown);
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
    private void BattleStateFlipControll()
    {
        if (player.position.x > enemy.transform.position.x && enemy.facingDir == -1)
            enemy.Flip();
        else if (player.position.x < enemy.transform.position.x && enemy.facingDir == 1)
            enemy.Flip();
    }
}
