using UnityEngine;

// test i�in: bo� GameObject + a�a��daki script
public class DamageTest : MonoBehaviour
{
    public BossHealth boss;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            boss.TakeDamage(5);
        }
    }
}
