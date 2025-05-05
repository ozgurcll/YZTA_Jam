using UnityEngine;

public class Enemy_MechaGolem : Enemy
{
    [SerializeField] private GameObject laserPrefab;   
    [SerializeField] private Transform laserSpawnPoint;

    public MechaIdleState idleState { get; private set; }
    public MechaMoveState moveState { get; private set; }
    public MechaBattleState battleState { get; private set; }
    public MechaAttackState attackState { get; private set; }
    public MechaLaserState laserState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new MechaIdleState(this, stateMachine, "Idle");
        moveState = new MechaMoveState(this, stateMachine, "Idle");
        battleState = new MechaBattleState(this, stateMachine, "Idle");
        attackState = new MechaAttackState(this, stateMachine, "Attack");
        laserState = new MechaLaserState(this, stateMachine, "Laser");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    public override void AnimationSpecialAttackTrigger()
    {
        base.AnimationSpecialAttackTrigger();
        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        laser.GetComponent<Laser_Controller>().SetupFireBall(stats, 3);
        laser.transform.SetParent(laserSpawnPoint);
    }
}
