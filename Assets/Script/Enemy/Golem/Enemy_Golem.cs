using UnityEngine;

public class Enemy_Golem : Enemy
{
    public GolemIdleState idleState { get; private set; }
    public GolemMoveState moveState { get; private set; }
    public GolemBattleState battleState { get; private set; }
    public GolemAttackState attackState { get; private set; }
    public GolemDieState dieState { get; private set; }

    public GameObject dialogPanel;

    protected override void Awake()
    {
        base.Awake();
        idleState = new GolemIdleState(this, stateMachine, "Idle");
        moveState = new GolemMoveState(this, stateMachine, "Move");
        battleState = new GolemBattleState(this, stateMachine, "Idle");
        attackState = new GolemAttackState(this, stateMachine, "Attack");
        dieState = new GolemDieState(this, stateMachine, "Die");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(dieState);
    }

}
