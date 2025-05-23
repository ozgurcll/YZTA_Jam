using System.Collections;
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
        enemy.StartCoroutine(DieCoroutine());
        if (enemy.dialogPanel != null)
            enemy.dialogPanel.SetActive(true);
    }

    public override void Update()
    {
        base.Update();
    }
    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2f);
        rb.linearVelocity = new Vector2(0, 10);
        if (enemy.dialogPanel != null)
            enemy.dialogPanel.SetActive(false);
    }
}
