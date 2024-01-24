using System;
using UnityEngine;

public class DroneFactory : MonoBehaviour
{
    #region SINGLETONE
    public static DroneFactory instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    #region CONSTANTA
    [SerializeField] private Drone _dronePrefab;

    [SerializeField] private DroneGunBullet _gunPrefab;
    [SerializeField] private DroneGun _gunLaserPrefab;

    [SerializeField] private Vector3 _weaponOffset;

    [SerializeField] private float _droneXSize = 2f;
    #endregion

    #region CREATE
    public Drone BuildDrone(DroneData droneData, Vector3 buildPosition)
    {
        Drone curretnDrone = Instantiate(_dronePrefab, buildPosition, Quaternion.identity);
        curretnDrone.Initialize(droneData.DroneStats);

        BuildWeapon(droneData, buildPosition, curretnDrone);

        return curretnDrone;
    }

    private void BuildWeapon(DroneData droneData, Vector3 buildPosition, Drone curretnDrone)
    {
        for (int i = 0; i < droneData.GunsStats.Length; i++)
        {
            Transform currentWeaponPosition;
            if (droneData.GunsStats[i] is DroneGunBulletSO)
            {
                DroneGunBullet currentWeapon = Instantiate
                    (_gunPrefab, buildPosition + _weaponOffset, Quaternion.identity, curretnDrone.transform)
                    as DroneGunBullet;
                currentWeapon.Initialize(droneData.GunsStats[i] as DroneGunBulletSO);

                currentWeapon.TryGetComponent<AimGunToPlayer>(out AimGunToPlayer aim);
                aim?.Initialize();

                currentWeaponPosition = currentWeapon.transform;
            }
            else if (droneData.GunsStats[i] is DroneGunLaserSO)
            {
                DroneGunLaser currentWeapon = Instantiate
                    (_gunLaserPrefab, buildPosition + _weaponOffset, Quaternion.identity, curretnDrone.transform)
                    as DroneGunLaser;
                currentWeapon.Initialize(droneData.GunsStats[i] as DroneGunLaserSO);

                currentWeapon.TryGetComponent<AimGunToPlayer>(out AimGunToPlayer aim);
                aim?.Initialize();

                currentWeaponPosition = currentWeapon.transform;
            }
            else throw new NullReferenceException("Weapons death?");

            SetPositionOnDrone(droneData, buildPosition, i, currentWeaponPosition);
        }
    }

    private void SetPositionOnDrone(DroneData droneData, Vector3 buildPosition, int i, Transform currentWeaponPosition)
    {
        int pointsCount = droneData.GunsStats.Length;
        float distandeBetweenPoints = (pointsCount > 1) ? _droneXSize / (pointsCount - 1) : _droneXSize / 2;

        float shift = _weaponOffset.x - _droneXSize / 2; //  -1____0____1 => 0____1____2
        float xPosition = i * distandeBetweenPoints + shift;
        currentWeaponPosition.transform.position = new Vector3(xPosition, _weaponOffset.y);
    } 
    #endregion

}
