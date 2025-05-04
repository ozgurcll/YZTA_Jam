using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MartialAttackState : EnemyState
{
    private Enemy_MartialHero enemy;

    private int attackCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;
    public MartialAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_MartialHero _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        if (attackCounter > 1 || Time.time >= lastTimeAttacked + comboWindow)
            attackCounter = 0;

        enemy.anim.SetInteger("AttackCounter", attackCounter);

    }

    public override void Exit()
    {
        base.Exit();
        attackCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        if (triggerCalled)
            enemy.stateMachine.ChangeState(enemy.battleState);
    }
}
