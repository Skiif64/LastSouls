using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D),typeof(CharacterState))]
public class Movement : MonoBehaviour
{
    #region ���������    
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _inAirSpeedMult = 0.8f;
    [SerializeField] private float _groundCheckDistance;
    #endregion
    #region ��������� ���������
    private bool _canMove = true;
    private bool _isGrounded;    
    private Rigidbody2D _rb;
    private CharacterState _state;
    #endregion
    #region ������
    
    [SerializeField] private Animator _animator;
    #endregion

    public bool IsGrounded => _isGrounded;
    public float MoveSpeed => _moveSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _state = GetComponent<CharacterState>();
        _state.StateChanged += CheckState;//TODO: ����������� �������
    }    

    private void FixedUpdate()
    {
        _isGrounded = CheckGround();
    }

    private bool CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance))
        {
            _state.ChangeState(State.Still);
            return true;
        }
        _state.ChangeState(State.InAir);
        return false;
    }
    public void Move(float direction)
    {
        if (!_canMove)
        {
            return;
        }
        _animator.SetFloat("Horizontal", Mathf.Abs(direction));
        if (Mathf.Abs(direction) < 0.01) return;
        if (direction > 0)
        {
            _state.ChangeFacing(Facing.Right);
        }
        else
        {
            _state.ChangeFacing(Facing.Left);
        }

        
        Vector2 dir;
        if(_isGrounded)
        {
            dir = new Vector2(direction * _moveSpeed, _rb.velocity.y);
        }
        else
        {
            dir = new Vector2(direction * _moveSpeed*_inAirSpeedMult, _rb.velocity.y);
        }
        _rb.velocity = dir;
    }

    private void CheckState(object sender, State e)
    {
        if (e != State.Dead) return;
        _canMove = false;
    }
}
