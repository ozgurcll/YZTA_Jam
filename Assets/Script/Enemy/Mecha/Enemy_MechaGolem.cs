using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class Enemy_MechaGolem : Enemy
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private Transform laserSpawnPoint;

    [SerializeField] private GameObject portalEffect;

    public MechaIdleState idleState { get; private set; }
    public MechaMoveState moveState { get; private set; }
    public MechaBattleState battleState { get; private set; }
    public MechaAttackState attackState { get; private set; }
    public MechaLaserState laserState { get; private set; }
    public MechaDieState dieState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new MechaIdleState(this, stateMachine, "Idle");
        moveState = new MechaMoveState(this, stateMachine, "Idle");
        battleState = new MechaBattleState(this, stateMachine, "Idle");
        attackState = new MechaAttackState(this, stateMachine, "Attack");
        laserState = new MechaLaserState(this, stateMachine, "Laser");
        dieState = new MechaDieState(this, stateMachine, "Idle");
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

    public override void AnimationSpecialAttackTrigger()
    {
        base.AnimationSpecialAttackTrigger();
        GameObject laser = Instantiate(laserPrefab, laserSpawnPoint.position, Quaternion.identity);
        laser.GetComponent<Laser_Controller>().SetupLaser(stats, 3);
        laser.transform.SetParent(this.transform);
    }

    public void SpawnPortal()
    {
        GameObject portal = Instantiate(portalEffect, transform.position, Quaternion.identity);
        portal.transform.rotation = Quaternion.Euler(80, 0, 0);
        portal.transform.position = PlayerManager.instance.player.transform.position + new Vector3(0f, 4f, 0f);
        StartCoroutine(DissolveCoroutine());
    }

    private IEnumerator DissolveCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        PlayerManager.instance.player.stateMachine.ChangeState(PlayerManager.instance.player.tpState);
        StartCoroutine(nextSceneCoroutine());
    }

    private IEnumerator nextSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
