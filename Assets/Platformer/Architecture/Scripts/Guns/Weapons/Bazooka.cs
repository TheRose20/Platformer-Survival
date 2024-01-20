using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bazooka : Gun
{
    [SerializeField] private BazookaSO _bazookaStats;
    protected override void Shoot()
    {
        Bullet bullet = Instantiate(_bazookaStats.BulletStats.BulletPrefab, _spawnBulletPoint.position, transform.rotation);
        bullet.SetBulletSO(_bazookaStats.BulletStats);
        bullet.GetRB().AddForce(transform.right * _bazookaStats.BulletStats.StartForce, ForceMode2D.Impulse);

        //Перенести параметры патроны сюда

        base.Shoot();
    }

    protected override void Initialization()
    {
        //_damage = _bulletStats.Damage; //Переписать класс Gun ВСЕ В Scriptable Object
        _cooldown = _bazookaStats.Coooldowm;
        _bulletsCount = _bazookaStats.StartAmmoAmount;

        //NoBullets = _bazookaStats.NoBullets;
        //OnShoot = _bazookaStats.OnShoot;

        base.Initialization();
    }
}
