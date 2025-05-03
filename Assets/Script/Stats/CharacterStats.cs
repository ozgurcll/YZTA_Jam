using UnityEngine;

public enum StatType
{
    Health,
    damage
}
public class CharacterStats : MonoBehaviour
{
    private EntityFx fx;

    [Header("Stats")]
    public Stats maxHealth;
    public Stats damage;


    public int currentHealth;

    public System.Action onHealthChanged;
    public bool isDead { get; private set; }
    public bool isInvincible { get; private set; }



    void Awake()
    {
        currentHealth = GetMaxHealthValue();
    }

    protected virtual void Start()
    {
        fx = GetComponent<EntityFx>();
    }


    public virtual void DoDamage(CharacterStats _targetStats)
    {
        bool criticalStrike = false;

        if (_targetStats.isInvincible)
            return;

        _targetStats.GetComponent<Entity>().SetupKnockbackDir(transform);


        int totalDamage = damage.GetValue();

        fx.CreateHitFX(_targetStats.transform, criticalStrike);

        _targetStats.TakeDamage(totalDamage);


    }


    public virtual void TakeDamage(int _damage)
    {
        if (isInvincible)
            return;

        DecreaseHealthBy(_damage);

        GetComponent<Entity>().DamageImpact();
        fx.StartCoroutine("FlashFX");

        if (currentHealth < 0 && !isDead)
            Die();


    }

    protected virtual void Die()
    {
        isDead = true;
    }

    public void MakeInvincible(bool _invincible) => isInvincible = _invincible;

    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue();
    }

    protected virtual void DecreaseHealthBy(int _damage)
    {

        currentHealth -= _damage;

        // if (_damage > 0)
        // fx.CreatePopUpText(_damage.ToString());

        if (onHealthChanged != null)
            onHealthChanged();
    }
}
