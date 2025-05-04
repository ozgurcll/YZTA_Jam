using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartialDieState : EnemyState
{
    private Enemy_MartialHero enemy;
    public MartialDieState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_MartialHero _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = .4f;
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
