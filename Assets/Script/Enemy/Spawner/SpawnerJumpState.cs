using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerJumpState : EnemyState
{
    private Enemy_Spawner enemy;

    public SpawnerJumpState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = (Enemy_Spawner)enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        rb.linearVelocity = new Vector2(enemy.jumpVelocity.x * enemy.facingDir, enemy.jumpVelocity.y);

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
