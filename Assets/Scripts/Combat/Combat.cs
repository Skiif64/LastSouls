using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class Combat : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private WeaponItem _weaponItem;

    #region ���������
    [SerializeField] private float _distance;
    [SerializeField] private float _hOffset;
    [SerializeField] private float _vOffset;
    #endregion

    #region ���������� ������
    private CharacterState _state;
    private bool _canAttack=true;
    private bool _hitActive;
    #endregion

    private void Awake()
    {
        #region ��������� �����������
        _state = GetComponent<CharacterState>();
        #endregion
        #region ������������� �����������
        _weapon = new MeleeWeapon();
        _weapon.SetWeapon(_weaponItem);
        #endregion
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
        var hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(_hOffset * (float)_state.Facing, _vOffset), Vector2.right * (float)_state.Facing, _distance);
        if(hit)
        {            
            _weapon.Attack(hit.collider);
        }
    }

    /// <summary>
    /// ��� �����
    /// </summary>
    private void OnDrawGizmos()
    {
        var dir = 1f;
        if(_state!=null)
        dir = (float)_state.Facing;
        Gizmos.color = Color.green;
        Gizmos.DrawRay((Vector2)transform.position + new Vector2(_hOffset * dir, _vOffset), new Vector2(_distance, 0) * dir);
    }
}
