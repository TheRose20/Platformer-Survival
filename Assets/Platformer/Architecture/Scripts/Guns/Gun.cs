using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gun: MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] protected Transform SpawnBulletPosition;
    [SerializeField] protected int BulletCount = 10;
    [SerializeField] protected float Cooldown = 0.1f;
    [SerializeField, Min(1)] protected int Damage = 2;

    [SerializeField] protected GunType _gunType; 

    public UnityEvent NoBullets;
    public UnityEvent OnShoot;
    public Action<int> ChangeBullets;

    private bool _reload = false;
    #endregion

    public void TryShoot()
    {
        if(BulletCount <= 0)
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
        BulletCount--;
        OnShoot?.Invoke();
        ChangeBullets?.Invoke(BulletCount);
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
            BulletCount += countBullets;
            ChangeBullets?.Invoke(BulletCount);
        }
    }

    protected IEnumerator Reload()
    {
        yield return new WaitForSeconds(Cooldown);
        _reload = false;
    }

    protected virtual void Initialization()
    {
        ChangeBullets?.Invoke(BulletCount);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        Initialization();
    } 
#endif
}
