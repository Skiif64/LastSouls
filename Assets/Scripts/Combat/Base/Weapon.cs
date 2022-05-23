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

    public virtual void SetWeapon(WeaponItem item)
    {
        var info = item.GetDamageInfo();
        _damage = info.Value;
        _type = info.Type;
    }

    public abstract void Attack(Collider2D target);
    
}
