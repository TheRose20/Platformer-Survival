using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TarodevController;
using UnityEngine;

public class DroneGunLaser : DroneGun
{
    [Header("Main Stats")]
    [SerializeField] private DroneGunSO _currentDroneGunStats;

    [Header("Visual CBE")]
    [SerializeField, Tooltip("CBE - Could be empty")] private LineLaserSO _lineStats;
    


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

        if (!hit) return;;
        VisualLaser(_shootPosition.position, hit.point, _lineStats);

        if (hit.collider.TryGetComponent<PlayerController>(out PlayerController player))
        {
            player.GetComponent<Health>().ApplyDamage(_currentDroneGunStats.Damage);
        }
    }

    private void VisualLaser(Vector3 startPosition, Vector3 hitPosition, LineLaserSO lineStats)
    {
        if (_lineStats != null) LineFactory.instance.GetProduct(startPosition, hitPosition, lineStats);
    }

#if UNITY_EDITOR
    protected override void OnEnable()
    {
        if (!_lineStats)
        {
            Debug.LogWarning("Line stats is empty", this);
        }
        base.OnEnable();
    }
#endif
}
