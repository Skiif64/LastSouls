using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс оружия
/// </summary>
[System.Serializable]
public abstract class Weapon
{    
    protected float _damage;    
    protected DamageType _type;

    public virtual void SetWeapon(float damage, DamageType type)
    {
        _damage = damage;
        _type = type;
    }

    public abstract void Attack(Collider2D target);
    
}
