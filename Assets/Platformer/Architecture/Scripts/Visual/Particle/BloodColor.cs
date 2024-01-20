using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodColor : MonoBehaviour
{
    [SerializeField] private BloodColorSO _bloodColorSO;

    public Color Color => _bloodColorSO.Color;
}
