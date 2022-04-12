using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _verticalOffset = 1f;
    [SerializeField] private float _horizontalBounds = 2f;
    [SerializeField] private float _verticalBounds = 1f;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _distance = 10f;
    [SerializeField] private Transform _target;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        float posX = Mathf.Clamp(Mathf.Lerp(_transform.position.x, _target.position.x, Time.fixedDeltaTime * _speed),
            _transform.position.x - _horizontalBounds, _transform.position.x + _horizontalBounds);
        float posY = Mathf.Clamp(Mathf.Lerp(_transform.position.y, _target.position.y, Time.fixedDeltaTime * _speed),
            _transform.position.y - _verticalBounds, _transform.position.y + _verticalBounds);
        _transform.position = new Vector3(posX,posY+_verticalOffset,-_distance);
    }
}
