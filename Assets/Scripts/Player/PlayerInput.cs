using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Ввод
    private MainInput _input;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _lightAttackAction;
    private InputAction _heavyAttackAction;
    private InputAction _rollAction;
    #endregion    
    [SerializeField] private Movement _playerMoving;
    [SerializeField] private Jump _jump;
    [SerializeField] private Roll _roll;

    private float _direction = 0;
    private void OnEnable()
    {
        #region Инициализация ввода
        _input = new MainInput();
        _moveAction = _input.General.Move;
        _jumpAction = _input.General.Jump;
        _lightAttackAction = _input.General.AttackLight;
        _heavyAttackAction = _input.General.AttackHeavy;
        _rollAction = _input.General.Roll;
        #endregion

        #region Привязка действий
        _input.Enable();
        _jumpAction.performed += TryJump;
        _lightAttackAction.performed += TryLightAttack;
        _heavyAttackAction.performed += TryHeavyAttack;
        _rollAction.performed += TryRoll;
        #endregion
    }    

    private void OnDisable()
    {
        #region Отвязка действий
        _input.Disable();
        _jumpAction.performed -= TryJump;
        _lightAttackAction.performed -= TryLightAttack;
        _heavyAttackAction.performed -= TryHeavyAttack;
        _rollAction.performed -= TryRoll;
        #endregion
    }

    private void TryRoll(InputAction.CallbackContext obj)
    {
        _roll.TryRoll(_direction);
    }

    private void FixedUpdate()
    {
        _direction = _moveAction.ReadValue<float>();
        _playerMoving.Move(_direction);
    }

    private void TryHeavyAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Heavy Attack");
    }

    private void TryLightAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("Light Attack");
    }

    private void TryJump(InputAction.CallbackContext obj)
    {
        _jump.TryJump();
    }


}
