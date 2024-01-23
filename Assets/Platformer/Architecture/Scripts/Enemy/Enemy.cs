using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Enemy : MonoBehaviour
{
    protected EnemySO _enemyStats;
    [SerializeField] protected Health _health;

    protected void HealthInitialize(EnemySO enemyStats)
    {
        _health.SetMaxHealth(enemyStats.MaxHealth);
        _health.MaxHealthHeal();
    }

    protected abstract void Move(Transform target);

    protected virtual void OnValidate()
    {
        if (_health == null)
        {
            _health = GetComponent<Health>();
        }
    }
}
