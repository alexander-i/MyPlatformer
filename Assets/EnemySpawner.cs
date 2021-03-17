using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] MyEnemy _myEnemy;
    [SerializeField] Transform _enemySpawnPoint;

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        _myEnemy.Initalize(_enemySpawnPoint.position);
    }
}
