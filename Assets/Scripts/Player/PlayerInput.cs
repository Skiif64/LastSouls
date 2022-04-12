using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    #region Ввод
    private MainInput _input;
    private InputAction _move;
    private InputAction _jump;
    private InputAction _lightAttack;
    private InputAction _heavyAttack;
    [SerializeField] private float _inputSensevity = 0.15f;
    #endregion
    private void OnEnable()
    {
        #region Инициализация ввода
        _input = new MainInput();
        _move = _input.General.Move;
        _jump = _input.General.Jump;
        _lightAttack = _input.General.AttackLight;
        _heavyAttack = _input.General.AttackHeavy;
        #endregion

        #region Привязка действий
        _input.Enable();
        _jump.performed += TryJump;
        _lightAttack.performed += TryLightAttack;
        _heavyAttack.performed += TryHeavyAttack;
        #endregion
    }
    private void OnDisable()
    {
        #region Отвязка действий
        _input.Disable();
        _jump.performed -= TryJump;
        _lightAttack.performed -= TryLightAttack;
        _heavyAttack.performed -= TryHeavyAttack;
        #endregion
    }

    private void Update()
    {
        if (_move.ReadValue<float>() > 0.15f)
        {
            Debug.Log(_move.ReadValue<float>());
        }
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
        Debug.Log("Jump");
    }


}
