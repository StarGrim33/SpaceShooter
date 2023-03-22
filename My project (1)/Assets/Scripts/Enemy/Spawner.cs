using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _amount;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if( _elapsedTime >= _secondsBetweenSpawn )
        {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        }
    }
}
