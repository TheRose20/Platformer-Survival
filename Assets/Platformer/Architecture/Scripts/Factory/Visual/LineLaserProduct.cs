using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLaserProduct : MonoBehaviour, ILineProduct
{
    public void Initialize(LineLaserSO lineStats, LineRenderer lineComponent)
    {
        lineComponent.startWidth = lineStats.StartWidth;
        lineComponent.endWidth = lineStats.EndWidth;
        lineComponent.startColor = lineStats.StartColor;
        lineComponent.endColor = lineStats.EndColor;
        lineComponent.material = lineStats.Material;
    }
}
