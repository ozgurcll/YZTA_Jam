using UnityEngine;
using System.Collections;


public class Player : Entity
{
    public PlayerFx fx { get; private set; }

    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce;
    public int jumpCount = 1;

    [Header("Dash Info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }
    public bool isBusy { get; private set; }

    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private float knifeSpeed = 10;

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    public PlayerThrowState throwState { get; private set; }
    public PlayerDashState dashState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        throwState = new PlayerThrowState(this, stateMachine, "Throw");
        dashState = new PlayerDashState(this, stateMachine, "Move");
    }

    protected override void Start()
    {
        base.Start();
        fx = GetComponent<PlayerFx>();
        stateMachine.Initialize(idleState);
    }


    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;

        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }

    public void CheckForDashInput()
    {
        if (IsWallDetected())
            return;

        dashDir = Input.GetAxisRaw("Horizontal");

        if (dashDir == 0)
            dashDir = -facingDir;


        stateMachine.ChangeState(dashState);
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinishTrigger();

    public void KnifeThrow()
    {
        GameObject newKnife = Instantiate(knifePrefab, attackCheck.position, Quaternion.identity);
        newKnife.GetComponent<Knife_Controller>().SetupArrow(knifeSpeed * facingDir, stats);
    }
}
