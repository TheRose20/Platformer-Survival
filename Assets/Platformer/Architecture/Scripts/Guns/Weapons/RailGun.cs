using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class RailGun : Gun
{
    [SerializeField] private Transform _spawnBulletPoint2;

    [Header("Settings")]
    [SerializeField, Min(1)] private float _maxDistanceRay = 50f;
    [SerializeField, Min(0)] private float _throwForce = 50f;

    [Space(10)]
    [SerializeField] private Rigidbody2D _playerRigidbody;

    protected override void Shoot()
    {
        Raycast();

        _playerRigidbody.AddForce(_playerRigidbody.transform.position - SpawnBulletPosition.position * _throwForce, ForceMode2D.Impulse);

        Debug.Log("Shoot Railgun");

        base.Shoot();
    }

    private void Raycast()
    {
        RaycastHit2D[] hits1;
        RaycastHit2D[] hits2;

        hits1 = Physics2D.RaycastAll(SpawnBulletPosition.position, transform.right, _maxDistanceRay);
        hits2 = Physics2D.RaycastAll(_spawnBulletPoint2.position, transform.right, _maxDistanceRay);

        if (hits1.Length > 0 || hits2.Length > 0)
        {
            Debug.Log($"{hits1} and {hits2}");
            RaycastHit2D[] unionHits = GetUnion(hits1, hits2);

            Debug.Log(unionHits);

            foreach (var currentHit in unionHits)
            {
                
                Health hitHealth;
                currentHit.collider.TryGetComponent<Health>(out hitHealth);
                if (hitHealth)
                {
                    hitHealth.ApplyDamage(Damage);
                    Debug.Log(hitHealth);
                }
                        
            }
        }
    }

    private static T[] GetUnion<T>(T[] array1, T[] array2)
    {
        T[] newArray = array1.Union(array2).ToArray();
        return newArray;
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_playerRigidbody == null)
        {
            _playerRigidbody = GetComponentInParent<Rigidbody2D>();
        }
    } 
#endif
}
