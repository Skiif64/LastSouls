using System;
using UnityEngine;

[Serializable]
public class Health : IHealable, IDamageable
{
    [SerializeField]
    private float _currHealth;
    [SerializeField]
    private float _maxHealth;
    private bool _isDead;
    public float CurrentHealth => _currHealth;
    public float MaxHealth => _maxHealth;
    public bool IsDead => _isDead;

    public event EventHandler Dying;
    public Health(float maxHealth)
    {
        _currHealth = maxHealth;
        _maxHealth = maxHealth;
        _isDead = false;
    }
    /// <summary>
    /// �������� ����
    /// </summary>
    /// <param name="damage">���������� �� �����</param>
    public void TakeDamage(DamageInfo damage)
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
    /// �������� �������
    /// </summary>
    /// <param name="value">��������</param>
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
            _isDead = true;
            Dying?.Invoke(this, null);
        }
    }
}
