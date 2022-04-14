using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    public float CurrentHealth => _health.CurrentHealth;

    public event EventHandler<float> Damaged;


    private void Awake()
    {
        _health = new Health(20);
    }
    public void TakeDamage(DamageInfo damage)
    {
        _health.TakeDamage(damage);
        Debug.Log($"{transform.name} takes {damage.Value} {damage.Type.Name} from {damage.Sender}");
        Damaged?.Invoke(this, CurrentHealth);
    }
}
