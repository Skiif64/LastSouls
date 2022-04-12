using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    #region Параметры
    [SerializeField] private float _moveDeadzone = 0.15f;
    [SerializeField] private float _moveSpeed = 1f;
    [SerializeField] private float _groundCheckDistance;
    #endregion
    #region Внутрение параметры
    private bool _canMove = true;
    private bool _isGrounded;
    private bool _isDirectionRight = true;
    private Rigidbody2D _rb;
    private Vector2 _direction = Vector2.zero;
    #endregion
    #region Ссылки
    [SerializeField] private SpriteRenderer _playerRender;
    [SerializeField] private Animator _animator;
    #endregion

    public bool IsGrounded => _isGrounded;

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
        if (Mathf.Abs(direction) < _moveDeadzone) return;
        if (direction > 0)
        {
            _isDirectionRight = true;
        }
        else
        {
            _isDirectionRight = false;
        }

        _playerRender.flipX = !_isDirectionRight;
        _direction = transform.position;
        _direction.x += direction * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_direction);
    }
}
