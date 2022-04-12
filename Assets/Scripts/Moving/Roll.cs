using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    [SerializeField] private float _rollSpeed;
    private bool _canRoll=true;
    private Rigidbody2D _rb;

    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TryRoll(float direction)
    {
        if(_canRoll)
        {
            DoRoll(direction);
        }
    }
    private void DoRoll(float direction)
    {
        _animator.SetTrigger("Roll");
        _rb.AddForce(new Vector2( Mathf.Ceil(direction)*_rollSpeed,transform.position.y));
    }
}
