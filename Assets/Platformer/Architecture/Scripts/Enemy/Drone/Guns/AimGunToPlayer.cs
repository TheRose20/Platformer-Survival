using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DroneGun))]
public class AimGunToPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private DroneGunSO _droneGunStats;

    public void Initialize()
    {
        StartCoroutine(WaitForGetPlayerInstance());
        _droneGunStats = GetComponent<DroneGun>().DroneGunStats;
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if (_target == null) return;
        Rotate(_target);
    }

    private void Rotate(Transform target)
    {
        Vector3 offset = new Vector3(0f, 1f);
        Vector2 direction = ((target.position + offset) - transform.position).normalized;

        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, -angle + 180);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _droneGunStats.RotationSpeed * Time.deltaTime);
    }

    private void OnValidate()
    {
        _droneGunStats = GetComponent<DroneGun>().DroneGunStats; // Change to initialization
    }

    private IEnumerator WaitForGetPlayerInstance()
    {
        while (GetPlayer.instance == null)
        {
            yield return null;
        }
        _target = GetPlayer.instance.GetPlayerTransform();
    }
}
