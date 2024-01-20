using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class DroneGunLaser : DroneGun
{
    [SerializeField] private DroneGunSO _currentDroneGunStats;

    protected override void OnValidate()
    {
        _droneGunStats = _currentDroneGunStats;
    }

    protected override void Shoot()
    {
        StartCoroutine(WaitToFixedUpdate());   
    }

    private IEnumerator WaitToFixedUpdate()
    {
        yield return new WaitForFixedUpdate();
        Raycast();
    }

    private void Raycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(_shootPosition.position, -_shootPosition.up, 50);

        if (!hit) return;

        if (hit.collider.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.GetComponent<Health>().ApplyDamage(_currentDroneGunStats.Damage);
        }
    }
}
