using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private BulletSO _bulletStats;

    public BulletSO BulletStats => _bulletStats;
    public void SetBulletSO(BulletSO bulletStats) =>  _bulletStats = bulletStats; 

    public Rigidbody2D GetRB() { return rb;}

    private void OnValidate()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation()
    }
}
