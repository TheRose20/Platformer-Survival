using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneGunLaser", menuName = "Drone/Create new Drone Laser stats", order = 51)]
public class DroneGunLaserSO : DroneGunSO
{
    [Header("Visual CBE")]
    [SerializeField, Tooltip("CBE - Could be empty")] private LineLaserSO _lineStats;

    public LineLaserSO LineStats => _lineStats;
}
