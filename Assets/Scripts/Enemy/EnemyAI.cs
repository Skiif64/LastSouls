using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _visionDistance = 100f;
    [SerializeField] private float _attackDistance = 1.25f;

    private bool _isActive;
    private bool _canAttack;
    private Character _target;

    private Movement _movement;
    private Combat _combat;
    private Character _character;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _combat = GetComponent<Combat>();
        _character = GetComponent<Character>();
        _canAttack = true;
        _isActive = true;
    }

    private void Update()
    {
        if (!_isActive) return;

        if (!_target) _target = TryGetTarget();
        if (!_target) return;
        if (_target.CurrentHealth == 0)
        {
            _target = null;
            return;
        }
        if (Vector2.Distance(transform.position, _target.transform.position) > _attackDistance)
        {
            Move();
            return;
        }

        if (_canAttack) Attack();


    }

    private Character TryGetTarget()
    {
        var obj = Physics2D.CircleCastAll(transform.position, _visionDistance, Vector2.up);

        foreach (var o in obj)
        {
            if (o.transform.TryGetComponent(out Character character))
            {
                if (character.CharaterType == CharaterType.Player)
                {
                    return character;
                }
            }
        }
        return null;
    }

    private void Move()
    {
        if (transform.position.x < _target.transform.position.x)
        {
            _movement.Move(1f);
        }
        else
        {
            _movement.Move(-1f);
        }
    }

    private void Attack()
    {
        _combat.TryLightAttack();
    }
}
