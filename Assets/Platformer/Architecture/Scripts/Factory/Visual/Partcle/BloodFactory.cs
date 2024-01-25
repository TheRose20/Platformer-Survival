using UnityEngine;

public class BloodFactory : MonoBehaviour, IParticleFactory
{
    [SerializeField] private BloodProduct _deathBlood;
    public void GetProduct(Vector3 position)
    {
        BloodProduct currentBlood = Instantiate(_deathBlood, position, Quaternion.identity);
        currentBlood.Initialize();
    }
}
