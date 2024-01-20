using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPositions;

    [Tooltip("Use just one time to all Waves")]
    [SerializeField] private bool _oneTime = true;
    [SerializeField, Range(0, 20)] private float _nextWaveTime = 3f;
    [SerializeField] private Wave[] _waves = new Wave[3];

    private void Start()
    {
        
    }

    private void StartWave(Wave currentWave, Transform[] positions)
    {

    }

    private IEnumerator WaitToNextWave(float timeToNextWave)
    {
        yield return new WaitForSeconds(timeToNextWave);

    }

    private void OnValidate()
    {
        if(gameObject.name != "WaveManager") gameObject.name = "WaveManager";

        Transform[] childrens = GetComponentsInChildren<Transform>();
        List<Transform> clearChildens = new List<Transform>(childrens.Length - 1);
        foreach(Transform currnetChildren in childrens)
        {
            if(currnetChildren != transform)
            {
                clearChildens.Add(currnetChildren);
            }
        }
        _spawnPositions = clearChildens.ToArray();
    }
}

[Serializable]
public class Wave
{
    [SerializeField] private Enemy[] _enemes;
    [SerializeField] private int _enemyCount;
}
