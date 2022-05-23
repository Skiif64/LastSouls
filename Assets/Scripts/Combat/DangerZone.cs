using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] private float _tickDelay;    
    [SerializeField] private DamageType _damageType;
    [SerializeField] private float _damageValue;
    [SerializeField] private bool _isKiller;
    [SerializeField] private Vector2 _size;
    private float _tick=0f;

    private void FixedUpdate()
    {
        if (_tick > 0)
        {
            _tick -= Time.fixedDeltaTime;
            return;
        }
        var contacts = Physics2D.BoxCastAll(transform.position, _size, 0, Vector2.up);
        if (contacts is null) return;
        foreach(var c in contacts)
        {
            if (!c.transform.TryGetComponent(out IDamageable target)) return;
            HitTarget(target);
        }
    } 
    

    private void HitTarget(IDamageable target)
    {
        if(_isKiller) target.TakeDamage(new DamageInfo(this, float.MaxValue, _damageType));

        var damageInfo = new DamageInfo(this, _damageValue, _damageType);
        target.TakeDamage(damageInfo);

        _tick = _tickDelay;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireCube(transform.position, _size);
    }
}
