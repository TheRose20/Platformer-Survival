using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bazooka : Gun
{
    [SerializeField] private BazookaSO _bazookaStats;
    protected override void Shoot()
    {
        Bullet bullet = Instantiate(_bazookaStats.BulletStats.BulletPrefab, SpawnBulletPosition.position, transform.rotation);
        bullet.SetBulletSO(_bazookaStats.BulletStats);
        bullet.GetRB().AddForce(transform.right * _bazookaStats.BulletStats.StartForce, ForceMode2D.Impulse);

        //��������� ��������� ������� ����

        base.Shoot();
    }

    protected override void Initialization()
    {
        //_damage = _bulletStats.Damage; //���������� ����� Gun ��� � Scriptable Object
        Cooldown = _bazookaStats.Coooldowm;
        BulletCount = _bazookaStats.StartAmmoAmount;

        //NoBullets = _bazookaStats.NoBullets;
        //OnShoot = _bazookaStats.OnShoot;

        base.Initialization();
    }
}
