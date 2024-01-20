using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IProduct
{
    public void Initialize();
}

public interface ILineProduct
{
    public void Initialize(LineLaserSO lineStats, LineRenderer lineComponent);
}

public abstract class Factory : MonoBehaviour
{
    public abstract ILineProduct GetProduct(Vector3 position);
}

public interface ILineFactory
{
    public abstract ILineProduct GetProduct(Vector3 origin, Vector3 hitPosition, LineLaserSO lineStats);
}
