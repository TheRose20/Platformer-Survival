using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineFactory : MonoBehaviour, ILineFactory
{
    public ILineProduct GetProduct(Vector3 origin, Vector3 hitPosition, LineLaserSO lineStats)
    {
        transform.position = origin;
        ILineProduct product = null;
        return product;
    }
}
