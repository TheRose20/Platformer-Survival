using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    #region CONSTANTA
    [SerializeField] private Transform[] _spawnPositions;

    [Tooltip("Use just one time to all Waves")]
    [SerializeField] private bool _oneTime = true;
    [SerializeField, Range(0, 20)] private const float NEXT_WAVE_TIME = 3f;
    [SerializeField] private Wave[] _waves = new Wave[3];

    private int _currentWave = 0;
    private int _currentDronesDeathCount = 0;
    #endregion

    private void Start()
    {
        Wave currentWave = _waves[_currentWave];
        StartCoroutine(SetWave(currentWave));
    }

    public void DroneDeath()
    {
        _currentDronesDeathCount++;
        if (_currentDronesDeathCount >= _waves[_currentWave].EnemyCount)
        {
            _currentWave++;
            if (_currentWave >= _waves.Length)
            {
                WavesOver();
                return;
            }
            _currentDronesDeathCount = 0;
            Wave currentWave = _waves[_currentWave];
            StartCoroutine(SetWave(currentWave));
            Debug.Log($"Start Wave {currentWave}");
        }
    }

    private static void WavesOver()
    {
        Debug.Log("Game Won");
    }

    private void StartWave(Wave currentWave, Transform[] positions)
    {
        int createdEnemies = 0;
        for (int i = 0; i < currentWave.EnemyCount; i++)
        {
            int randomValue = GetRandom(0, _spawnPositions.Length);

            createdEnemies = createdEnemies >= currentWave.Enemies.Length ? 0 : createdEnemies++;

            Drone currentDrone =
                DroneFactory.instance.BuildDrone(currentWave.Enemies[createdEnemies], _spawnPositions[randomValue].position);
            currentDrone.GetComponent<DroneDeath>().Initialize(this);
        }
    }

    private int GetRandom(int value1, int value2) => UnityEngine.Random.Range(value1, value2);

    private IEnumerator SetWave(Wave currentWave)
    {
        float waitTime = _oneTime ? NEXT_WAVE_TIME : currentWave.TimeToNextWave;
        yield return new WaitForSeconds(waitTime);
        StartWave(currentWave, _spawnPositions);
    }

#if UNITY_EDITOR
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
#endif
}

[Serializable]
public class Wave
{
    [SerializeField] private DroneData[] _enemes;
    [SerializeField] private int _enemyCount = 3;
    [SerializeField] private float _timeToNextWave = 2f;

    public DroneData[] Enemies => _enemes;
    public int EnemyCount => _enemyCount;
    public float TimeToNextWave => _timeToNextWave;
}
