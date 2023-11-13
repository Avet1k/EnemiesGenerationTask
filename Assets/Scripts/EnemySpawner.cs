using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    private Transform[] _spawnPoints;
    private float _spawnInterval;
    private float _runningTime;
    
    private void Start()
    {
        _spawnPoints = new Transform[transform.childCount];
        _spawnInterval = 2f;

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i);

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForTwoSeconds = new WaitForSeconds(_spawnInterval);
        bool isOpen = true;

        while (isOpen)
        {
            Transform spawnPoint = _spawnPoints[Random.Range(0, transform.childCount)];
            
            Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation, spawnPoint);

            yield return waitForTwoSeconds;
        }
    }
}
