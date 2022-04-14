using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private float _maxHealth; //To remove

    private CharacterState _state;
    public float CurrentHealth => _health.CurrentHealth;

    public event EventHandler<float> HealthChanged;


    private void Awake()
    {
        _health = new Health(_maxHealth);
        _state = GetComponent<CharacterState>();
        _health.Dying += OnDeath;
    }   

    public void TakeDamage(DamageInfo damage)
    {
        _health.TakeDamage(damage);        
        HealthChanged?.Invoke(this, CurrentHealth);
    }

    private void OnDeath(object sender, EventArgs e)
    {
        _state.ChangeState(State.Dead);
        Destroy(gameObject, 3f);
    }


}
