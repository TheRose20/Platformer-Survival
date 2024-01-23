using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class DroneGun : MonoBehaviour
{
    #region CONSTANTA
    [Header("Shoot Position")]
    [SerializeField] protected Transform _shootPosition;

    [Header("Shoot modify")]
    public UnityEvent ShootEvent;


    protected DroneGunSO _droneGunStats;
    public DroneGunSO DroneGunStats => _droneGunStats; 
    #endregion

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    protected abstract void OnValidate();


    protected IEnumerator Shoting()
    {
        while(gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_droneGunStats.Cooldown);
            Shoot();
        }
    }

    protected abstract void Shoot();
}
