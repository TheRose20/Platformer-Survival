using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneGunBullet", menuName = "Drone/Create new DroneGun use Bullet", order = 51)]
public class DroneGunBulletSO : DroneGunSO
{
    [Header("Bullet Settings")]
    [SerializeField] private DroneBullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 10f;

    public float BulletSpeed => _bulletSpeed;
    public DroneBullet BulletPrefab => _bulletPrefab;
}
