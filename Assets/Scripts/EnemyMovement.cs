using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class EnemyMovement : MonoBehaviour
{
    private float _speed = 0.01f;
    
    private void Update()
    {
        transform.position += transform.forward * _speed;
    }
}
