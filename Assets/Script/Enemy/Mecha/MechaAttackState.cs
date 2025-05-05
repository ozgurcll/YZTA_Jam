using UnityEngine;

public class MechaAttackState : EnemyState
{
    private Enemy_MechaGolem enemy;

    public MechaAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemyBase as Enemy_MechaGolem;
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = 1.2f;
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

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.battleState);


    }


}
