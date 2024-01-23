using UnityEngine;


public interface IProduct
{
    public void Initialize();
}

public interface ILineProduct
{
    public void Initialize(LineLaserSO lineStats);
}

public abstract class Factory : MonoBehaviour
{
    public abstract IProduct GetProduct(Vector3 position);
}

public interface ILineFactory
{
    public abstract void GetProduct(Vector3 origin, Vector3 hitPosition, LineLaserSO lineStats);
}
