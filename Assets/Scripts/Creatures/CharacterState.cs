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
    Blocking,
    Frozen,
    Dead
}
public enum Facing
{
    Left = -1,
    Right = 1
}
/// <summary>
/// Машина состояний существа
/// </summary>
public class CharacterState : MonoBehaviour
{
    private State _state = State.Still;
    private Facing _facing = Facing.Right;

    public State State => _state;
    public Facing Facing => _facing;
    public event EventHandler<State> StateChanged;
    public event EventHandler<Facing> FacingChanged;

    /// <summary>
    /// Изменить состояние
    /// </summary>
    /// <param name="state">новое состояние</param>
    public void ChangeState(State state)
    {
        if (_state == state) return;
        _state = state;
        StateChanged?.Invoke(this, _state);
    }

    public void ChangeFacing(Facing facing)
    {
        if (_facing == facing) return;
        _facing = facing;
        FacingChanged?.Invoke(this, _facing);
    }
}
