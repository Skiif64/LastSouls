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

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (_movement.IsGrounded) _inAirJump = true;
    }

    public void TryJump(float direction)
    {
        if (_movement.IsGrounded)
        {
            DoJump(direction);
        }
        else if(_inAirJump)
        {
            DoJump(direction);
            _inAirJump = false;
        }
    }

    private void DoJump(float direction)
    {
        Vector2 vec = Vector2.up;
        vec.x += direction;
        _rb.AddForce(vec.normalized * _jumpForce);
    }
}
