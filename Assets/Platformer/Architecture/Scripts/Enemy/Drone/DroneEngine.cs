using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneEngine : MonoBehaviour
{
    private Drone _drone;
    private void OnValidate()
    {
        if(_drone == null)
        {
            _drone.GetComponentInParent<Drone>();
        }
    }

    private void OnEnable()
    {
        if (_drone == null) _drone = GetComponentInParent<Drone>();
    }
}
