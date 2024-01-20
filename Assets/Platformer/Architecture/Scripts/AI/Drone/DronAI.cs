using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D), typeof(DroneMover))]

public class DronAI : MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] private bool _autoSize = true;
    [SerializeField] private float _size = 1f;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _target; //player
    [SerializeField] private DroneMover _mover;

    public Action<Transform> OnChangeTarget; 
    #endregion

    private void FixedUpdate()
    {
        CheckPlayerPath();
    }

    private void CheckPlayerPath()
    {
        Vector2 direction = _target.position - transform.position;
        float distance = Vector2.Distance(_target.position, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);
        Transform currentTarget = hit.collider.transform;

        if (currentTarget == _target)
        {
            TryChangeTarget(currentTarget);
        }
        else if(currentTarget != _target)
        {

        }
    }

    private void TryChangeTarget(Transform currentTarget)
    {
        if (currentTarget.position != _target.position)
        {
            ChangeTarget(currentTarget);
        }
    }


    private void ChangeTarget(Transform target)
    {
        _target = target;
        OnChangeTarget?.Invoke(target);
    }


    private void OnValidate()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        if(_autoSize)
        {
            _size = GetComponent<CircleCollider2D>().radius;
        }
        if(_mover == null)
        {
            _mover = GetComponent<DroneMover>();
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
