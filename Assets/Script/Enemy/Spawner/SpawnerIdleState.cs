using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerIdleState : SpawnerGroundedState
{
    public SpawnerIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        
    }
}
