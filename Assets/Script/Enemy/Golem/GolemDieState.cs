using UnityEngine;

public class GolemDieState : EnemyState
{
    private Enemy_Golem enemy;
    public GolemDieState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = (Enemy_Golem)_enemyBase;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.cd.enabled = false;
        stateTimer = .15f;
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer > 0)
            rb.linearVelocity = new Vector2(0, 10);
    }
}
