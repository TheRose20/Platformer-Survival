using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    protected EnemySO _enemyStats;
    [SerializeField] protected Health _health;

    protected virtual void Initialization(EnemySO enemyStats)
    {
        _health.SetMaxHealth(enemyStats.Health);
        _health.MaxHealthHeal();
    }

    private void Start()//pizdez перенести  в OnEnable
    {
        Initialization(_enemyStats);
    }

    protected abstract void Move(Transform target);

    protected virtual void OnValidate()
    {
        if (_health == null)
        {
            _health = GetComponent<Health>();
        }
        Initialization(_enemyStats);
    }
}
