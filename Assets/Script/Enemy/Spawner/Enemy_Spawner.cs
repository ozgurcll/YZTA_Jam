using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : Enemy
{
    public Vector2 jumpVelocity;
    public float jumpCooldown;
    public float safeDistance;
    [HideInInspector] public float lastTimeJumped;

    [Header("Additional collision check")]
    [SerializeField] private Transform groundBehindCheck;
    [SerializeField] private Vector2 groundBehindCheckSize;

    [SerializeField] private GameObject[] spawnList;
    [SerializeField] private Transform spawnPos;


    public SpawnerIdleState idleState { get; private set; }
    public SpawnerBattleState battleState { get; private set; }
    public SpawnerJumpState jumpState { get; private set; }
    public SpawnerMoveState moveState { get; private set; }
    public SpawnerDieState dieState { get; private set; }
    public SpawnerAttackState attackState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new SpawnerIdleState(this, stateMachine, "Idle");
        battleState = new SpawnerBattleState(this, stateMachine, "Idle");
        jumpState = new SpawnerJumpState(this, stateMachine, "Jump");
        moveState = new SpawnerMoveState(this, stateMachine, "Move");
        dieState = new SpawnerDieState(this, stateMachine, "Die");
        attackState = new SpawnerAttackState(this, stateMachine, "Spawn");
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

    public bool GroundBehind() => Physics2D.BoxCast(groundBehindCheck.position, groundBehindCheckSize, 0, Vector2.zero, 0, whatIsGround);
    public bool WallBehind() => Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDir, wallCheckDistance + 2, whatIsGround);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.DrawWireCube(groundBehindCheck.position, groundBehindCheckSize);
    }

    public override void AnimationSpecialAttackTrigger()
    {
        base.AnimationSpecialAttackTrigger();
        int randomIndex = Random.Range(0, spawnList.Length);
        Instantiate(spawnList[randomIndex], spawnPos.position, Quaternion.identity);
        ImpactPlayer();
    }

    void ImpactPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);
        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
            {
                Player player = hit.GetComponent<Player>();
                player.fx.ScreenShake(player.fx.shakeHighDamage);
                player.SetupKnockbackPower(new Vector2(8, 8));
                player.DamageImpact();
            }
        }
    }
}
