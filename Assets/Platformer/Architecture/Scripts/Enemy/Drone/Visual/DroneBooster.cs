using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBooster : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Drone _drone;

    private void OnEnable()
    {
        _drone.OnBlackout += Blackout;
        _drone.OnTakeOff += TakeOff;
    }
    private void OnDisable()
    {
        _drone.OnBlackout -= Blackout;
        _drone.OnTakeOff -= TakeOff;
    }

    private void Blackout()
    {
        _particle.Stop();

    }
    private void TakeOff()
    {
        _particle.Play();
    }

    private void OnValidate()
    {
        if(_drone == null)
        {
            _drone = GetComponentInParent<Drone>();
        }
        if(_particle == null)
        {
            _particle = GetComponentInChildren<ParticleSystem>();
        }
    }
}
