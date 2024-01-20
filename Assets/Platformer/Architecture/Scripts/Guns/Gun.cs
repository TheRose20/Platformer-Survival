using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;

public class Gun: MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] protected Transform _spawnBulletPoint;
    [SerializeField] protected int _bulletsCount = 10;
    [SerializeField] protected float _cooldown = 0.1f;
    [SerializeField, Min(1)] protected int _damage = 2;

    [SerializeField] protected GunType _gunType; 

    public UnityEvent NoBullets;
    public UnityEvent OnShoot;
    public Action<int> ChangeBullets;

    private bool _reload = false;
    #endregion

    public void TryShoot()
    {
        if(_bulletsCount <= 0)
        {
            NoBullets?.Invoke();
            return;
        }
        if (_reload) return;
        Shoot();
    }

    protected virtual void Shoot()
    {
        _reload = true;
        StartCoroutine(Reload());
        _bulletsCount--;
        OnShoot?.Invoke();
        ChangeBullets?.Invoke(_bulletsCount);
    }

    public virtual void TryAddBullets(GunType type, int countBullets)
    {
        if(countBullets <= 0)
        {
            Debug.LogError("count bullets not correct " + countBullets);
            return;
        }

        if(type == _gunType)
        {
            _bulletsCount += countBullets;
            ChangeBullets?.Invoke(_bulletsCount);
        }
    }

    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(_cooldown);
        _reload = false;
    }

    protected virtual void Initialization()
    {
        ChangeBullets?.Invoke(_bulletsCount);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        Initialization();
    } 
#endif
}
