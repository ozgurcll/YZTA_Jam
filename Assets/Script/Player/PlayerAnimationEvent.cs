using UnityEngine;

public class PlayerAnimationEvent : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger() => player.AnimationTrigger();
    private void KnifeAttack() => player.KnifeThrow();
}
