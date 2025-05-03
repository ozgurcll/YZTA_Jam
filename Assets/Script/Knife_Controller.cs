using UnityEngine;

public class Knife_Controller : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private string targetLayerName = "Enemy";
    private float arrowSpeed;
    private Rigidbody2D rb;
    [SerializeField] private bool canMove;
    private int facingDir = 1;

    private Animator anim;


    private void Update()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(arrowSpeed, rb.linearVelocityY);

        if (facingDir == 1 && rb.linearVelocityX < 0)
        {
            facingDir = -1;
            sr.flipX = true;
        }
    }

    public void SetupArrow(float _speed)
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        arrowSpeed = _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            StuckInto(collision);
    }

    private void StuckInto(Collider2D collision)
    {
        // GetComponentInChildren<ParticleSystem>().Stop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("Stab", true);
        canMove = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.parent = collision.transform;
        Destroy(gameObject, Random.Range(5, 7));
    }
}
