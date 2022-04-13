using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� ����� ������
/// </summary>
[System.Serializable]
public abstract class Weapon
{
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected DamageType _type;

    public virtual void SetWeapon(float damage, DamageType type)
    {
        _damage = damage;
        _type = type;
    }

    public abstract void Attack(Collider2D target);
    
}