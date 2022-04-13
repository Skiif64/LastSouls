using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Movement))]
public class Jump : MonoBehaviour
{
    [SerializeField] float _jumpForce;
    private bool _inAirJump;
    private Rigidbody2D _rb;
    private Movement _movement;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (_movement.IsGrounded) _inAirJump = true;
    }

    public void TryJump()
    {
        if (_movement.IsGrounded)
        {
            DoJump();
        }
        else if(_inAirJump)
        {
            DoJump();
            _inAirJump = false;
        }
    }

    private void DoJump()
    {
        _animator.SetTrigger("jump");
        _rb.AddForce(Vector2.up * _jumpForce);
    }
}
