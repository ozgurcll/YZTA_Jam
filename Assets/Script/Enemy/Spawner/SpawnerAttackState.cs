using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAttackState : EnemyState
{
    private Enemy_Spawner enemy;

    public SpawnerAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = (Enemy_Spawner)enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}
