using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHP = 10;
    private int currentHP;
    public BossDeathController deathController;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathController.TriggerBossDeath();
    }
}
