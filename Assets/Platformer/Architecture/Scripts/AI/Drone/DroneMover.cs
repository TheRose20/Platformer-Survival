using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DroneMover : MonoBehaviour
{
    [SerializeField] private float _speed = 6f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private DronAI _dronAI;

    private Transform _target;

    private void FixedUpdate()
    {
        Move(_target);
    }

    private void ChangeTarget(Transform target)
    {
        _target = target;
    }

    private void Move(Transform position)
    {
        Vector2 direction = _target.position - transform.position;
        direction.Normalize();
        _rigidbody.velocity = direction * _speed;
    }

    private void OnEnable()
    {
        _dronAI.OnChangeTarget += ChangeTarget;
    }

    private void OnDisable()
    {
        _dronAI.OnChangeTarget -= ChangeTarget;
    }

    private void OnValidate()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        if(_dronAI == null)
        {
            _dronAI =  GetComponent<DronAI>();
        }
    }
}
