using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MartialHero : Enemy
{
    public Vector2 jumpVelocity;
    public float jumpCooldown;
    public float safeDistance;
    [HideInInspector] public float lastTimeJumped;

    [Header("Additional collision check")]
    [SerializeField] private Transform groundBehindCheck;
    [SerializeField] private Vector2 groundBehindCheckSize;


    public MartialIdleState idleState { get; private set; }
    public MartialMoveState moveState { get; private set; }
    public MartialJumpState jumpState { get; private set; }
    public MartialBattleState battleState { get; private set; }
    public MartialAttackState attackState { get; private set; }
    public MartialDieState dieState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new MartialIdleState(this, stateMachine, "Idle", this);
        moveState = new MartialMoveState(this, stateMachine, "Move", this);
        jumpState = new MartialJumpState(this, stateMachine, "Jump", this);
        battleState = new MartialBattleState(this, stateMachine, "Idle", this);
        attackState = new MartialAttackState(this, stateMachine, "Attack", this);
        dieState = new MartialDieState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(dieState);
    }

    public bool GroundBehind() => Physics2D.BoxCast(groundBehindCheck.position, groundBehindCheckSize, 0, Vector2.zero, 0, whatIsGround);
    public bool WallBehind() => Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDir, wallCheckDistance + 2, whatIsGround);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireCube(groundBehindCheck.position, groundBehindCheckSize);
    }

}
