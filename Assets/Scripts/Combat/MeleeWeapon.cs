using UnityEngine;

public class MeleeWeapon : WeaponBase
{
    public override void Attack(Collider2D target)
    {
        if (target.TryGetComponent(out IDamageable damageable))
        {
            var damageInfo = new DamageInfo(this, _damage, _type);
            damageable.TakeDamage(damageInfo);
        }
    }
}
