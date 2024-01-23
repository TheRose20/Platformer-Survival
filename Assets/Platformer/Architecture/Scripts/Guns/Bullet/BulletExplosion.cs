using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Bullet))]
public class BulletExplosion : MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private float _radius = 1f;

    [SerializeField] private Bullet _bullet;
    public UnityEvent OnExplosion; 
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explosion(collision);
    }

    private void Explosion(Collision2D collision)
    {
        int layerMask = ExcludeLayer("Bullet");

        collision.collider.TryGetComponent<Health>(out Health mainEnemyHealth);
        if (mainEnemyHealth)
        {
            int damage = _bullet.BulletStats.Damage;
            mainEnemyHealth.ApplyDamage(damage);
        }

        Collider2D[] overlapColliders = Physics2D.OverlapCircleAll(transform.position, _radius, layerMask);
        for (int i = 0; i < overlapColliders.Length; i++)
        {
            var currentOverlap = overlapColliders[i];

            if (currentOverlap.TryGetComponent<Health>(out Health currentEnemy))
            {
                if (currentEnemy == mainEnemyHealth) return;

                int layerMaskBullet = ExcludeLayer("Bullet");

                WallCheck(currentOverlap, currentEnemy, layerMaskBullet);
            }
        }

        OnExplosion?.Invoke();
        ParticleSystem particle = Instantiate(_particleSystem, transform.position, Quaternion.identity);
        particle.Play();
        gameObject.SetActive(false);

        collision.collider.TryGetComponent<Drone>(out Drone drone);
        drone?.Blackout();

    }

    private void WallCheck(Collider2D currentOverlap, Health currentEnemyHealth, int layerMaskBullet)
    {
        RaycastHit2D hit = 
            Physics2D.Raycast(transform.position, currentOverlap.transform.position - transform.position, _radius, layerMaskBullet);

        if (!hit) return;

        Health hitHealthComponent;
        if (hit.collider.TryGetComponent(out hitHealthComponent) && hitHealthComponent == currentEnemyHealth)
        {
            int bulletDamage = _bullet.BulletStats.Damage;
            float bulletExplosionForce = _bullet.BulletStats.ExplosionForce;

            float distance = Vector2.Distance(transform.position, currentEnemyHealth.transform.position);
            if (distance > _radius) distance = _radius;
            int damageUseDistance = Mathf.RoundToInt((_radius - distance) / _radius * bulletDamage);

            currentEnemyHealth.ApplyDamage(damageUseDistance);

            if (currentEnemyHealth.TryGetComponent<Rigidbody2D>(out Rigidbody2D enemyRigidbody))
            {
                AddExplosionForce(bulletExplosionForce, distance, enemyRigidbody);
            }

            Debug.Log($"Health: {currentEnemyHealth}\nDamage: {damageUseDistance}");
        }
    }

    private void AddExplosionForce(float bulletExplosionForce, float distance, Rigidbody2D enemyRigidbody)
    {
        Vector2 direction = enemyRigidbody.position - _bullet.GetRB().position; //Vector2 - Vector2 not Vector3 (transform.position = Vector3)
        direction.Normalize();
        float explosionForceDistance = (_radius - distance) / _radius * bulletExplosionForce;

        enemyRigidbody.AddForce(direction * explosionForceDistance);

        Debug.Log($"Explosion: {explosionForceDistance}");
    }

    private static int ExcludeLayer(string name)
    {
        int layerMask = ~(1 << LayerMask.NameToLayer(name));
        return layerMask;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);

    }

    private void OnValidate()
    {
        if(_bullet == null)
        {
            _bullet = GetComponent<Bullet>();
        }
    }
}
