using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLineLaserStats", menuName = "Drone/Visual/Line Laser Stats")]
public class LineLaserSO : ScriptableObject
{
    [Header("Size")]
    [SerializeField] private float _startWidth = 0.1f;
    [SerializeField] private float _endWidth = 0.1f;

    [Header("Material")]
    [SerializeField] private Material _material;

    [Header("Colors")]
    [SerializeField] private Color _startColor = Color.white;
    [SerializeField] private Color _endColor = Color.white;

    [Header("Time")]
    [SerializeField, Min(0)] private float _deathTime = 0.5f;

    [Header("Fade")]
    [SerializeField] private bool _useFade = true; //add Anumation curve to modify
    [SerializeField, Min(0.01f)] private float _fadeTime = 0.1f;

    public float StartWidth => _startWidth;
    public float EndWidth => _endWidth;
    public Color StartColor => _startColor;
    public Color EndColor => _endColor;
    public Material Material => _material;
    public float DeathTime => _deathTime;
    public bool UseFade => _useFade;
    public float FadeTime => _fadeTime;
}
