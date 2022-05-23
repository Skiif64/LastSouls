using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class AnimatorStateController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _playerRender;
    private CharacterState _state;
    private void Awake()
    {
        _state = GetComponent<CharacterState>();
    }
    private void OnEnable()
    {
        _state.StateChanged += ExecuteState;
        _state.FacingChanged += ExecuteFacing;
    }

    

    private void OnDisable()
    {
        _state.StateChanged -= ExecuteState;
        _state.FacingChanged -= ExecuteFacing;
    }

    private void ExecuteState(object sender, State e)
    {
        switch(e)
        {
            case State.Still: _animator.SetBool("isInAir", false);
                break;
            case State.InAir:
                _animator.SetBool("isInAir", true);
                break;
            case State.Rolling:
                _animator.SetTrigger("Roll");
                break;
            case State.Attacking:
                _animator.SetTrigger("Attack");
                break;
            case State.Dead:
                _animator.SetTrigger("Dead");
                break;
        }
    }

    private void ExecuteFacing(object sender, Facing e)
    {
        _playerRender.flipX = e == Facing.Left ? true : false;
    }

    
}
