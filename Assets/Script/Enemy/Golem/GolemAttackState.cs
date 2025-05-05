using UnityEngine;

public class GolemAttackState : EnemyState
{
    private Enemy_Golem enemy;
    public GolemAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemyBase as Enemy_Golem;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetZeroVelocity();
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
