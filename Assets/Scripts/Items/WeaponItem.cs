using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapons/Weapon")]
public class WeaponItem : Item, IEquipment, IWeapon
{
    [SerializeField] private float _damage;
    [SerializeField] private DamageType _type;
    public DamageInfo GetDamageInfo()
    {
        return new DamageInfo(this, _damage, _type);
    }
}
