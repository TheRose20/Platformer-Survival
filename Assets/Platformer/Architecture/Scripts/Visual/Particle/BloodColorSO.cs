using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[CreateAssetMenu(fileName = "newColor", menuName ="Create Color for Blood", order = 51)]
public class BloodColorSO : ScriptableObject
{
    [SerializeField] private Color _color;

    public Color Color => _color;
}
