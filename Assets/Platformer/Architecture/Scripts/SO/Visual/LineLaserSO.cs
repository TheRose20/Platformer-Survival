using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLineLaserStats", menuName = "Visual/Line Laser Stats")]
public class LineLaserSO : ScriptableObject
{
    [Header("Size")]
    [SerializeField] private float _startWidth = 0.1f;
    [SerializeField] private float _endWidth = 0.1f;

    [Header("Material")]
    [SerializeField] private Material _material = new Material(Shader.Find("Sprites/Default"));

    [Header("Colors")]
    [SerializeField] private Color _startColor = Color.white;
    [SerializeField] private Color _endColor = Color.white;

    public float StartWidth => _startWidth;
    public float EndWidth => _endWidth;
    public Color StartColor => _startColor;
    public Color EndColor => _endColor;
    public Material Material => _material;
}
