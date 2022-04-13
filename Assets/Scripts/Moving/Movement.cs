using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    #region Параметры    
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _inAirSpeedMult = 0.8f;
    [SerializeField] private float _groundCheckDistance;
    #endregion
    #region Внутрение параметры
    private bool _canMove = true;
    private bool _isGrounded;
    private bool _isDirectionRight = true;
    private Rigidbody2D _rb;    
    #endregion
    #region Ссылки
    [SerializeField] private SpriteRenderer _playerRender;
    [SerializeField] private Animator _animator;
    #endregion

    public bool IsGrounded => _isGrounded;
    public float MoveSpeed => _moveSpeed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _isGrounded = CheckGround();
    }

    public bool CheckGround()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _groundCheckDistance))
        {
            return true;
        }
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
            _isDirectionRight = true;
        }
        else
        {
            _isDirectionRight = false;
        }

        _playerRender.flipX = !_isDirectionRight;
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
}
