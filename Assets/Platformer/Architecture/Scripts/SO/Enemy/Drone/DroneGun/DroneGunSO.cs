using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[CreateAssetMenu(fileName = "DroneGun", menuName = "Drone/Create new DroneGun", order = 51)]
public class DroneGunSO : ScriptableObject
{
    [Header("Main Settings")]
    [SerializeField, Min(1)] private int _damage = 1;
    [SerializeField, Min(0.001f)] private float _cooldown = 2f;
    [SerializeField, Min(1f)] private float _rotateSpeed = 10f;
    


    public int Damage => _damage;
    public float Cooldown => _cooldown;
    public float RotationSpeed => _rotateSpeed;
}
