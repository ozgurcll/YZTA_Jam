using UnityEngine;
using System.Collections;
public class MechaDieState : EnemyState
{
    private Enemy_MechaGolem enemy;
    public MechaDieState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = (Enemy_MechaGolem)enemyBase;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.cd.enabled = false;
        enemy.StartCoroutine(DieCoroutine());
        stateTimer = .4f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            rb.linearVelocity = new Vector2(0, 10);
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2f);
        enemy.SpawnPortal();
    }


}
