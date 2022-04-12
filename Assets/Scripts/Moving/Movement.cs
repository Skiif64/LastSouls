using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    private bool _canMove = true;
    private Rigidbody2D _rb;
    private Vector2 _direction =Vector2.zero;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move(float direction)
    {
        if(!_canMove)
        {
            return;
        }
        _direction.x = direction * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition((Vector2)transform.position + _direction);
    }
}
