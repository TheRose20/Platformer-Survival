using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineLaserProduct : MonoBehaviour, ILineProduct
{
    private LineRenderer _lineRenderer;
    public void Initialize(LineLaserSO lineStats)
    {
        _lineRenderer.startWidth = lineStats.StartWidth;
        _lineRenderer.endWidth = lineStats.EndWidth;
        _lineRenderer.startColor = lineStats.StartColor;
        _lineRenderer.endColor = lineStats.EndColor;
        _lineRenderer.material = lineStats.Material;
    }

    public LineRenderer GetLineRenderer() => _lineRenderer;
    private void OnEnable()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
}
