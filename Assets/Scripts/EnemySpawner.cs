using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    
    private SpawnPoint[] _spawnPoints;
    private float _spawnInterval;
    private float _runningTime;
    
    private void Start()
    {
        _spawnPoints = new SpawnPoint[transform.childCount];
        _spawnInterval = 2f;

        for (int i = 0; i < transform.childCount; i++)
            _spawnPoints[i] = transform.GetChild(i).GetComponent<SpawnPoint>();

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForTwoSeconds = new WaitForSeconds(_spawnInterval);
        bool isOpen = true;

        while (isOpen)
        {
            int index = Random.Range(0, transform.childCount);
            SpawnPoint spawnPoint = _spawnPoints[index];
            Transform spawnTransform = spawnPoint.transform;
            
            var enemy = Instantiate(_enemy, spawnTransform.position, spawnTransform.rotation);
            enemy.SetColor(spawnPoint.GetCurrentColor);
            enemy.SetTarget(spawnPoint.GetTarget);
            
            yield return waitForTwoSeconds;
        }
    }
}
