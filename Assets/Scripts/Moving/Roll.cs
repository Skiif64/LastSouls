using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Roll : MonoBehaviour
{
    [SerializeField] private float _rollMult;
    private bool _canRoll=true;
    private Rigidbody2D _rb;
    private Movement _movement;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = GetComponent<Movement>();
    }

    public void TryRoll(float direction)
    {
        if(_canRoll && _movement.IsGrounded && Mathf.Abs(direction)>0.1f)
        {
            DoRoll(direction);
        }
    }
    private void DoRoll(float direction)
    {        
        _animator.SetTrigger("Roll");
        _rb.AddForce(new Vector2( Mathf.Ceil(direction)*_movement.MoveSpeed*_rollMult, transform.position.y));
    }
}
