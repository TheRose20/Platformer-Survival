using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDroneTest : MonoBehaviour
{
    [SerializeField] private DroneData _droneData;

    public void CreateDrone()
    {
        DroneFactory.instance.BuildDrone(_droneData, Vector3.zero);
    }
}
