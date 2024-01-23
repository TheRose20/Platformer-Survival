using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDroneData", menuName = "Drone/Drone Data", order = 51)]
public class DroneData : ScriptableObject
{
    /*
    [SerializeField] private Drone _dronePrefab;
    [SerializeField] private Gun _gunLaserPrefab;
    [SerializeField] private Gun _gunBulletPrefab;
    */

    [SerializeField] private DroneSO _droneStats;
    [SerializeField] private DroneGunSO[] _gunsStats = new DroneGunSO[1];

    public DroneSO DroneStats => _droneStats;
    public DroneGunSO[] GunsStats => _gunsStats;


#if UNITY_EDITOR
    private DroneGunSO[] _returnGunsStats = new DroneGunSO[1];
    private int _maxGuns = 4;
    private void OnValidate()
    {
        if (_gunsStats.Length == 0)
        {
            Debug.LogWarning("Guns Stats Cat't be null, The drone needs at least one weapon", this);
            _gunsStats = new DroneGunSO[1];
        }
        else if(_gunsStats.Length > _maxGuns)
        {
            _gunsStats = new DroneGunSO[_maxGuns];
            Array.Copy(_returnGunsStats, _gunsStats, _maxGuns);
        }
        else if (_gunsStats.Length <= _maxGuns && _gunsStats.Length > 0)
        {
            _returnGunsStats = new DroneGunSO[_gunsStats.Length];
            Array.Copy(_gunsStats, _returnGunsStats, _gunsStats.Length);
        }

        foreach (DroneGunSO currentGun in _gunsStats)
        {
            if (currentGun == null) Debug.LogWarning($"The Gun Stats is empty", this);
        }
    }
#endif
}
