using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "new enemy", menuName = "new enemy", order = 51)]
public class EnemySO : ScriptableObject
{
    [Header("Health")]
    [SerializeField, Min(1)] private int _maxHealth = 10;

    [Header("Speed")]
    [SerializeField, Min(0.1f)] private float _speed = 5f;
    [SerializeField, Min(1)] private float _acceleration = 100;
    [SerializeField, Min(1)] private float _deceleration = 20;

    public int MaxHealth => _maxHealth;
    public float Speed => _speed;
    public float Acceleration => _acceleration;
    public float Deceleration => _deceleration;
}
