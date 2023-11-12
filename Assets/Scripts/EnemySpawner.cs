using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    private Transform _spawner;
    private Transform[] _spawnPoints;
    private float _secondsCounter;
    private float _spawnInterval;
    private float _runningTime;
    private Random _random;
    private void Start()
    {
        _spawner = GetComponent<Transform>();
        _spawnPoints = new Transform[_spawner.childCount];
        _secondsCounter = 2f;
        _spawnInterval = _secondsCounter;
        _random = new Random();

        for (int i = 0; i < _spawner.childCount; i++)
            _spawnPoints[i] = _spawner.GetChild(i);
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        if (_runningTime > _secondsCounter)
        {
            Transform spawnPoint = _spawnPoints[_random.Next(_spawner.childCount)];
            
            Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            _secondsCounter += _spawnInterval;
        }
        
    }
}
