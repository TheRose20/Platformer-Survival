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

    private int _currentWave = 0;

    private void Start()
    {
        if (_oneTime) StartCoroutine(WaitToNextWave(_nextWaveTime));
    }

    private void StartWave(Wave currentWave, Transform[] positions)
    {
        for (int i = 0; i < currentWave.EnemyCount; i++)
        {
            int randomValue = GetRandom(0, _spawnPositions.Length);
            DroneFactory.instance.BuildDrone(currentWave.Enemies[i], _spawnPositions[randomValue].position);
        }
    }

    private int GetRandom(int value1, int value2) => UnityEngine.Random.Range(value1, value2);

    private IEnumerator WaitToNextWave(float timeToNextWave)
    {
        yield return new WaitForSeconds(timeToNextWave);
        StartWave(_waves[_currentWave], _spawnPositions);
    }

    private void OnValidate()
    {
        if (gameObject.name != "WaveManager") gameObject.name = "WaveManager";

        Transform[] childrens = GetComponentsInChildren<Transform>();
        List<Transform> clearChildens = new List<Transform>(childrens.Length - 1);
        foreach (Transform currnetChildren in childrens)
        {
            if (currnetChildren != transform)
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
    [SerializeField] private DroneData[] _enemes;
    [SerializeField] private int _enemyCount = 3;

    public DroneData[] Enemies => _enemes;
    public int EnemyCount => _enemyCount;
}
