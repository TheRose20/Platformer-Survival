using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGunBullet : DroneGun
{
    [SerializeField] private DroneGunBulletSO _droneGunBulletStats;

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
