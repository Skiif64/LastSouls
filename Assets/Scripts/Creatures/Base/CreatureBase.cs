using System;
using UnityEngine;

public abstract class CreatureBase : MonoBehaviour, IHealable, IDamageable
{
    [SerializeField]
    protected float _health;
    [SerializeField]
    protected float _maxHealth;
    protected bool _isDead;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public bool IsDead => _isDead;

    public virtual void TakeDamage(DamageInfo damage)
    {
        if (damage.Value < 0) throw new ArgumentException("Damage value below 0",nameof(damage.Value));

        _health -= damage.Value;
        if(_health<0)
        {
            _health = 0;
        }
        CheckDead();
    }

    public virtual void TakeHeal(float value)
    {
        if (value < 0) throw new ArgumentException("Heal value below 0", nameof(value));
        _health += value;
        if(_health>_maxHealth)
        {
            _health = _maxHealth;
        }
    }

    protected void CheckDead()
    {
        if(_health<=0)
        {
            _isDead = true;
        }
    }
}
