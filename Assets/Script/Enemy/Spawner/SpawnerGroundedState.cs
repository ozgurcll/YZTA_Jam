using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGroundedState : EnemyState
{
    protected Enemy_Spawner enemy;
    protected Transform player;

    public SpawnerGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = (Enemy_Spawner)enemyBase;
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

        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.transform.position) < enemy.agroDistance)
            stateMachine.ChangeState(enemy.battleState);
    }
}
