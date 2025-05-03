using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger() => player.AnimationTrigger();
    private void KnifeAttack() => player.KnifeThrow();


    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Debug.Log("Hit Enemy");
                EnemyStats _target = hit.GetComponent<EnemyStats>();

                if (_target != null)
                    player.stats.DoDamage(_target);

            }
        }
    }
}
