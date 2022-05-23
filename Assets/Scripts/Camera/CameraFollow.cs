using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    [SerializeField] private Transform _target;
    [SerializeField] private float _boundX = 0.15f;
    [SerializeField] private float _boundY = 0.1f;
    [SerializeField] private float _verticalOffset = 0.1f;
    [SerializeField] private float _minY = 0f;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        var deltaX = Mathf.Clamp(_target.position.x - _transform.position.x, -_boundX, _boundX);
        var deltaY = Mathf.Clamp(_target.position.y + _verticalOffset - _transform.position.y, -_boundY, _boundY);
        _transform.Translate(deltaX, deltaY, 0);
        if (_transform.position.y < _minY) _transform.position =
                new Vector3(_transform.position.x, _minY, _transform.position.z);
    }
}
