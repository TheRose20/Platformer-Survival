using System.Collections;
using UnityEngine;

public abstract class DroneGun : MonoBehaviour
{
    [Header("Shoot Position")] 
    [SerializeField] protected Transform _shootPosition;


    protected DroneGunSO _droneGunStats;
    public DroneGunSO DroneGunStats => _droneGunStats;

    protected virtual void OnEnable()
    {
        StartCoroutine(Shoting());
    }
    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

    protected abstract void OnValidate();
  

    protected IEnumerator Shoting() //static?
    {
        while(gameObject.activeSelf)
        {
            yield return new WaitForSeconds(_droneGunStats.Cooldown);
            Shoot();
        }
    }

    protected abstract void Shoot();
}
