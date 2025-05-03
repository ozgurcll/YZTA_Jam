using UnityEngine;

// test için: boþ GameObject + aþaðýdaki script
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
