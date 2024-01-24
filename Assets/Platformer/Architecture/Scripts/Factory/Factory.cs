using UnityEngine;


public interface IProduct
{
    public abstract void Initialize();
}

public interface IParticleProduct
{
    public void Initialize();
}

public interface IParticleFactory
{
    public abstract void GetProduct(Vector3 position);
}

public interface ILineProduct
{
    public abstract void Initialize(LineLaserSO lineStats);
}

public abstract class Factory : MonoBehaviour
{
    public abstract IProduct GetProduct(Vector3 position);
}

public interface ILineFactory
{
    public abstract void GetProduct(Vector3 origin, Vector3 hitPosition, LineLaserSO lineStats);
}
