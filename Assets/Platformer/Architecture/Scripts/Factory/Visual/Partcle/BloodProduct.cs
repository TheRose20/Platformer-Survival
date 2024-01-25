using UnityEngine;

public class BloodProduct : MonoBehaviour, IParticleProduct
{
    [SerializeField] private ParticleSystem _particleSystem;
    public void Initialize()
    {
        _particleSystem.Play();
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_particleSystem == null) _particleSystem = GetComponent<ParticleSystem>();
    } 
#endif
}
