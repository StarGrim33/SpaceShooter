using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if( _elapsedTime >= _secondsBetweenSpawn )
        {
            _elapsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Spawn(_spawnPoints[spawnPointNumber]);
        }
    }

    private void Spawn(Transform position)
    {
        GameObject instance = Pool.SharedInstance.GetPooledObject();
        instance.transform.position = position.transform.position;
        instance.SetActive(true);
    }
}
