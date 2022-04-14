using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class Character : MonoBehaviour, IDamageable
{
    #region ��� �����
    [SerializeField] private float _maxHealth; //To remove
    #endregion
    #region ��������� ���������
    private Health _health;
    private bool _canTakeDamage = true;
    //TODO: Stats
    //TODO: Resistance
    private CharacterState _state;
    #endregion
    public float CurrentHealth => _health.CurrentHealth;

    public event EventHandler<float> HealthChanged;
    private void Awake()
    {
        #region ������������� ���������� �����������
        _health = new Health(_maxHealth);
        #endregion
        #region ��������� �����������
        _state = GetComponent<CharacterState>();
        #endregion

        _health.Dying += OnDeath;
    }
    private void OnDisable()
    {
        _health.Dying -= OnDeath;
    }

    public void TakeDamage(DamageInfo damage)
    {
        if (!_canTakeDamage) return;
        //TODO: ������� �������������
        _health.TakeDamage(damage);
        HealthChanged?.Invoke(this, CurrentHealth);
        Debug.Log($"{transform.name} takes {damage.Value} {damage.Type.Name} from {damage.Sender}");
    }

    private void OnDeath(object sender, EventArgs e)
    {
        _state.ChangeState(State.Dead);
        _canTakeDamage = false;
        Destroy(gameObject, 3f);
    }


}
