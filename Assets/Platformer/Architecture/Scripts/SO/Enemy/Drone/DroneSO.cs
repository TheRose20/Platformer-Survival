using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDrone", menuName = "Drone/Create New Drone", order = 51)]
public class DroneSO : EnemySO
{
    [Header("Blackout")]
    [SerializeField, Min(0)] private float _blackoutTime = 2f;

    [Header("AI")]
    [SerializeField, Min(1f)] private float _minDistance = 5f;
    [SerializeField, Min(0.1f)] private float _distanceDeathZone = 0.5f;

    [Header("Visual")]
    [SerializeField] private Sprite _eyes;
    [SerializeField] private Color _eyesColor;

    public float BlackoutTime => _blackoutTime;
    public float MinDistance => _minDistance;
    public float DistanceDeathZone => _distanceDeathZone;
    public Sprite Eyes => _eyes;
    public Color EyesColor => _eyesColor;
}
