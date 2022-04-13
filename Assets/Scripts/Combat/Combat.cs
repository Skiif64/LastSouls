using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class Combat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Collider2D _blade;
    private CharacterState _state;
    private bool _canAttack=true;
    private bool _hitActive;

    private void Awake()
    {
        _state = GetComponent<CharacterState>();

        _weapon = new MeleeWeapon();
        _weapon.SetWeapon(10, null);
    }

    public void TryLightAttack()
    {
        if(_canAttack && (_state.State==State.Still))
        {
            LightAttack();
        }
    }

    public void RecoverAttack()
    {
        _canAttack = true;
    }

    private void LightAttack()
    {
        _state.ChangeState(State.Attacking);
        _canAttack = false;
        var hit = Physics2D.BoxCast(new Vector2(transform.position.x-1.5f,transform.position.y),new Vector2(0.5f,0.01f),0,Vector2.up);
        if(hit)
        {
            _weapon.Attack(hit.collider);
        }
    }

    
}
