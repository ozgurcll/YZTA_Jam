using UnityEngine;

public class Enemy_Golem : Enemy
{



    public GolemIdleState idleState { get; private set; }
    public GolemMoveState moveState { get; private set; }
    public GolemBattleState battleState { get; private set; }
    public GolemAttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new GolemIdleState(this, stateMachine, "Idle");
        moveState = new GolemMoveState(this, stateMachine, "Move");
        battleState = new GolemBattleState(this, stateMachine, "Idle");
        attackState = new GolemAttackState(this, stateMachine, "Attack");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    public override void Die()
    {
        base.Die();
    }

}
