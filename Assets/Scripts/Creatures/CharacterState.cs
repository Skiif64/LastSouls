using System;
using UnityEngine;

/// <summary>
/// Перечисление состояний
/// </summary>
public enum State
{
    Still,
    Moving,
    InAir,
    Rolling,
    Attacking,
    Dead
}
/// <summary>
/// Машина состояний существа
/// </summary>
public class CharacterState : MonoBehaviour
{
    private State _state = State.Still;

    public State State => _state;
    public event EventHandler<State> Changed;

    /// <summary>
    /// Изменить состояние
    /// </summary>
    /// <param name="state">новое состояние</param>
    public void ChangeState(State state)
    {
        if (_state == state) return;
        _state = state;
        Changed?.Invoke(this, _state);
    }
}
