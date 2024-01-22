using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Bazooka", menuName = "Weapon/Create new BazookaAsset", order = 51)]
public class BazookaSO : GunSO
{
    [Header("Bullet Stats")]
    [SerializeField] private BulletSO _bulletStats;

    //[SerializeField] private UnityEvent _noBullets;
    //[SerializeField] private UnityEvent _onShoot;
    public BulletSO BulletStats => _bulletStats;

    //public UnityEvent NoBullets => _noBullets;
    //public UnityEvent OnShoot => _onShoot;
}
