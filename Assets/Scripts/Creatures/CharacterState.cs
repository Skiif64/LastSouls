using System;
using UnityEngine;

/// <summary>
/// ������������ ���������
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
/// ������ ��������� ��������
/// </summary>
public class CharacterState : MonoBehaviour
{
    private State _state = State.Still;

    public State State => _state;
    public event EventHandler<State> Changed;

    /// <summary>
    /// �������� ���������
    /// </summary>
    /// <param name="state">����� ���������</param>
    public void ChangeState(State state)
    {
        if (_state == state) return;
        _state = state;
        Changed?.Invoke(this, _state);
    }
}
