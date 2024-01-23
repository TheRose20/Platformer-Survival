using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGunBullet : DroneGun
{
    [SerializeField] private DroneGunBulletSO _droneGunBulletStats;

    public void Initialize(DroneGunBulletSO gunStats)
    {
        _droneGunBulletStats = gunStats;
        _droneGunStats = _droneGunBulletStats;
        StartCoroutine(Shoting());
    }

    protected override void OnValidate()
    {
        _droneGunStats = _droneGunBulletStats;
    }

    protected override void Shoot()
    {
        DroneBullet currentBullet =
            Instantiate(_droneGunBulletStats.BulletPrefab, _shootPosition.position, _shootPosition.rotation);

        currentBullet.SetDroneGun(_droneGunBulletStats);
    }
}
