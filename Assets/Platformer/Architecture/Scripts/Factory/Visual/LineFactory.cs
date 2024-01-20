using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LineFactory : MonoBehaviour, ILineFactory
{
    #region SINGLETONE
    public static LineFactory instance { get; private set; }
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

    [SerializeField] private LineLaserProduct _linePrefab;

    public void GetProduct(Vector3 origin, Vector3 hitPosition, LineLaserSO lineStats)
    {
        LineLaserProduct currentLine = Instantiate(_linePrefab, transform.parent = transform);
        currentLine.Initialize(lineStats);

        LineRenderer lineRenderer = currentLine.GetLineRenderer();
        lineRenderer.SetPosition(0, origin);
        lineRenderer.SetPosition(1, hitPosition);
    }
}
