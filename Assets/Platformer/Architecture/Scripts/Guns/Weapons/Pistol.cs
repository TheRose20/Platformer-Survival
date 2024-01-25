using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] private GunSO _pistolStats;
    [SerializeField] private float _explosionForce = 25f;
    [SerializeField] private ParticleSystem _blood;
    protected override void Shoot()
    {
        Raycast();

        base.Shoot();
    }

    private void Raycast()
    {

        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));

        RaycastHit2D hit =
            Physics2D.Raycast(transform.position, transform.right, 50, layerMask);

        if (!hit) return;
        if (hit.collider.TryGetComponent<Health>(out Health health))
        {
            health.ApplyDamage(_pistolStats.Damage);

            Rigidbody2D enemyRigidbody = health.GetComponent<Rigidbody2D>();

            Vector3 directionForce = (health.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(directionForce * _explosionForce, ForceMode2D.Force);

            ParticleSystem blood = Instantiate(_blood, hit.point, Quaternion.LookRotation(hit.normal, Vector3.up));
            if(hit.collider.TryGetComponent<BloodColor>(out BloodColor bloodColor))
            {
                SetColor(blood, bloodColor.Color);
            }
        }
    }
    private void SetColor(ParticleSystem ps, Color color)
    {
        var currentGradient = new ParticleSystem.MinMaxGradient(color * 0.9f, color * 1.2f);

        var main = ps.main;
        main.startColor = currentGradient;
    }

    protected override void Initialization()
    {
        Cooldown = _pistolStats.Coooldowm;
        BulletCount = _pistolStats.StartAmmoAmount;
        Damage = _pistolStats.Damage;
        base.Initialization();
    }
}
