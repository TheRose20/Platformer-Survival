using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneBullet : MonoBehaviour
{
    private DroneGunBulletSO _droneGunBulletStats;

    public void SetDroneGun(DroneGunBulletSO droneGunSO) => _droneGunBulletStats = droneGunSO;


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(_droneGunBulletStats == null)
        {
            transform.Translate(Vector3.down * 1 * Time.fixedDeltaTime);
            return;
        }

        transform.Translate(Vector3.down * _droneGunBulletStats.BulletSpeed * Time.fixedDeltaTime);

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, Vector3.down, 0.1f);
        if (hit)
        {
            if (hit.collider.TryGetComponent<Health>(out Health hittingHealht))
            {
                hittingHealht.ApplyDamage(_droneGunBulletStats.Damage);

            }
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, -transform.up * 2);
    }
}
