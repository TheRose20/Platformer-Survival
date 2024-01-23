using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBullet" , menuName = "Weapon/create new bullet", order = 51)]
public class BulletSO : ScriptableObject
{
    [Header("Prefab")]
    [SerializeField] private Bullet _bulletPrefab;

    [Header("Forces")]
    [SerializeField, Min(1)] private float _explosionForce = 50f;
    [SerializeField, Min(3)] private float _startForce = 10f;

    [Header("Damage")]
    [SerializeField, Min(1)] private int _damage = 20;

    public Bullet BulletPrefab => _bulletPrefab;
    public float StartForce => _startForce;
    public float ExplosionForce => _explosionForce;
    public int Damage => _damage;   
}
