using UnityEngine;

public class Laser_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CharacterStats stats;
    [SerializeField] private string targetLayerName = "Player";
    private int damage;
    private int facingDir = 1;

    void Start()
    {
        Destroy(gameObject, 4f);
    }
    private void Update()
    {
        if (facingDir == 1 && rb.linearVelocityX < 0)
        {
            facingDir = -1;
            sr.flipX = true;
        }
    }

    public void SetupFireBall(CharacterStats _stats, int _damage)
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        stats = _stats;
        damage = _damage;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CharacterStats>()?.isInvincible == true)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            other.GetComponent<CharacterStats>().TakeDamage(damage);
            stats.DoDamage(other.GetComponent<CharacterStats>());
            other.GetComponent<PlayerFx>().HitStopEffect(.1f, .1f);
        }
    }
}
