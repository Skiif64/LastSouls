using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Базовый класс оружия
/// </summary>
public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected DamageType _type;

    public virtual void SetWeapon()
    {

    }

    public abstract void Attack(Collider2D target);
    
}
