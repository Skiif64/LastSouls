using System;
using UnityEngine;

public enum State
{
    Still,
    Moving,
    InAir,
    Rolling,
    Attacking,
    Dead
}
public class CharacterState : MonoBehaviour
{
    private State _state = State.Still;

    public State State => _state;
    public event EventHandler<State> Changed;

    public void ChangeState(State state)
    {
        if (_state == state) return;
        _state = state;
        Changed?.Invoke(this, _state);
    }
}
