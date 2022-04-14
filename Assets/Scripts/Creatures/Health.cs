using System;
using UnityEngine;

[Serializable]
public class Health
{    
    private float _currHealth;    
    private float _maxHealth;
    private bool _canTakeDamage;
    public float CurrentHealth => _currHealth;
    public float MaxHealth => _maxHealth;
    public bool IsDead => _canTakeDamage;

    public event EventHandler Dying;
    public Health(float maxHealth)
    {
        _currHealth = maxHealth;
        _maxHealth = maxHealth;
        _canTakeDamage = true;
    }
    /// <summary>
    /// Получить урон
    /// </summary>
    /// <param name="damage">Информация об уроне</param>
    public void TakeDamage(DamageInfo damage)
    {
        if (!_canTakeDamage) return;
        if (damage.Value < 0) throw new ArgumentException("Damage value below 0",nameof(damage.Value));
        _currHealth -= damage.Value;
        if(_currHealth<0)
        {
            _currHealth = 0;
        }
        CheckDead();
    }
    /// <summary>
    /// Получить лечение
    /// </summary>
    /// <param name="value">Величина</param>
    public void TakeHeal(float value)
    {        
        if (value < 0) throw new ArgumentException("Heal value below 0", nameof(value));
        _currHealth += value;
        if(_currHealth>_maxHealth)
        {
            _currHealth = _maxHealth;
        }
    }

    private void CheckDead()
    {
        if(_currHealth<=0)
        {
            _canTakeDamage = false;
            Dying?.Invoke(this, null);
        }
    }
}
