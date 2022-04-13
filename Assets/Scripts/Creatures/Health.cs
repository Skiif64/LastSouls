using System;
using UnityEngine;

[Serializable]
public abstract class Health : IHealable, IDamageable
{    
    protected float _currHealth;    
    protected float _maxHealth;
    protected bool _isDead;
    public float CurrentHealth => _currHealth;
    public float MaxHealth => _maxHealth;
    public bool IsDead => _isDead;

    public Health(float health, float maxHealth)
    {
        _currHealth = health;
        _maxHealth = maxHealth;
        _isDead = false;
    }
    /// <summary>
    /// Получить урон
    /// </summary>
    /// <param name="damage">Информация об уроне</param>
    public virtual void TakeDamage(DamageInfo damage)
    {
        if (damage.Value < 0) throw new ArgumentException("Damage value below 0",nameof(damage.Value));

        _currHealth -= damage.Value;
        if(_currHealth<0)
        {
            _currHealth = 0;
        }
        CheckDead();
    }
    /// <summary>
    /// Получить решение
    /// </summary>
    /// <param name="value">Величина</param>
    public virtual void TakeHeal(float value)
    {
        if (value < 0) throw new ArgumentException("Heal value below 0", nameof(value));
        _currHealth += value;
        if(_currHealth>_maxHealth)
        {
            _currHealth = _maxHealth;
        }
    }

    protected void CheckDead()
    {
        if(_currHealth<=0)
        {
            _isDead = true;
        }
    }
}
