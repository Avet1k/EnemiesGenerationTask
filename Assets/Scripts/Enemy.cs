using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Enemy : MonoBehaviour
{
    private Renderer _renderer;
    private Target _target;
    private EnemyMovement _movement;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _movement = GetComponent<EnemyMovement>();
    }

    private void Start()
    {
        _movement.SetTarget(_target);
    }
    
    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}
