using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterState))]
public class AnimatorStateController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private CharacterState _state;
    private void Awake()
    {
        _state = GetComponent<CharacterState>();
    }
    private void OnEnable()
    {
        _state.Changed += Execute;
    }

    private void OnDisable()
    {
        _state.Changed -= Execute;
    }

    private void Execute(object sender, State e)
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
        }
    }

    
}
