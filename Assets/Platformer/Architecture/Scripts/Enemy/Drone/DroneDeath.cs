using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class DroneDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathBlood;

    [SerializeField] private Health _health;

    private WaveManager _waveManager;


    public void Initialize(WaveManager waveManager)
    {
        _health.OnDeath += Die;
        _waveManager = waveManager;
    }

    private void Die()
    {
        CreateBlood(_deathBlood);
        _waveManager.DroneDeath();
        gameObject.SetActive(false);
    }

    private void CreateBlood(ParticleSystem bloonPrefab)
    {
        ParticleSystem currentDeathBlood = Instantiate(bloonPrefab, transform.position, Quaternion.identity, null);
    }

    private void OnDisable()
    {
        _health.OnDeath -= Die;
    }


    private void OnValidate()
    {
        if(_health == null)
        {
            _health = GetComponent<Health>();
        }
    }
}
