using System;
using UnityEngine;

[Serializable]
public class Health
{    
    private float _currHealth;    
    private float _maxHealth;    
    public float CurrentHealth => _currHealth;
    public float MaxHealth => _maxHealth;    

    public event EventHandler Dying;
    public Health(float maxHealth)
    {
        _currHealth = maxHealth;
        _maxHealth = maxHealth;        
    }
    /// <summary>
    /// Получить урон
    /// </summary>
    /// <param name="damage">Информация об уроне</param>
    public void TakeDamage(DamageInfo damage)
    {        
        if (damage.Value < 1) throw new ArgumentException("Damage value below 1",nameof(damage.Value));
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

    public void UpdateMaxHealth(float newValue)
    {
        if (_maxHealth == newValue) return;
        if (newValue <= 0) throw new ArgumentException("Max health c",nameof(newValue));
    }

    private void CheckDead()
    {
        if(_currHealth<=0)
        {            
            Dying?.Invoke(this, null);
        }
    }
}
