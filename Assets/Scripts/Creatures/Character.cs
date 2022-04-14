using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private float _maxHealth; //To remove
    //TODO: Stats

    //TODO: Resistance
    private CharacterState _state;
    public float CurrentHealth => _health.CurrentHealth;

    public event EventHandler<float> HealthChanged;


    private void Awake()
    {
        _health = new Health(_maxHealth);
        _state = GetComponent<CharacterState>();
        _health.Dying += OnDeath;//TODO: Реализовать отписку
    }   

    public void TakeDamage(DamageInfo damage)
    {
        //TODO: Просчет сопротивлений
        _health.TakeDamage(damage);        
        HealthChanged?.Invoke(this, CurrentHealth);
        Debug.Log($"{transform.name} takes {damage.Value} {damage.Type.Name} from {damage.Sender}");
    }

    private void OnDeath(object sender, EventArgs e)
    {
        _state.ChangeState(State.Dead);
        Destroy(gameObject, 3f);
    }


}
