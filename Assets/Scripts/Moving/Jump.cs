using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Jump : MonoBehaviour
{
    [SerializeField] float _jumpForce;
    private bool _inAirJump;
    private Rigidbody2D _rb;    
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }

    public void TryJump(float direction)
    {
        Vector2 vec = Vector2.up;
        vec.x += direction;        
        _rb.AddForce(vec.normalized*_jumpForce);
    }
}
