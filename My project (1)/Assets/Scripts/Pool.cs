using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool SharedInstance;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private GameObject _playerBulletsContainer;
    [SerializeField] private List<GameObject> _playerBullets;

    [SerializeField] private List<GameObject> _enemyBullets;
    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private GameObject _enemyBulletsContainer;

    [SerializeField] private int _rocketCount;
    [SerializeField] private List<GameObject> _enemyRockets;
    [SerializeField] private GameObject _enemyRocket;
    [SerializeField] private GameObject _enemyRocketsContainer;


    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _playerBullets = new List<GameObject>();

        for (int i = 0; i < _poolCount; i++)
        {
            var playerBullets = Instantiate(_playerBullet, _playerBulletsContainer.transform);
            playerBullets.SetActive(false);
            _playerBullets.Add(playerBullets);
        }

        _enemyBullets = new List<GameObject>();

        for (int i = 0; i < _poolCount; i++)
        {
            var enemyBullets = Instantiate(_enemyBullet, _enemyBulletsContainer.transform);
            enemyBullets.SetActive(false);
            _enemyBullets.Add(enemyBullets);
        }

        _enemyRockets = new List<GameObject>();

        for(int i = 0; i < _rocketCount; i++)
        {
            var enemyRockets = Instantiate(_enemyRocket, _enemyRocketsContainer.transform); 
            enemyRockets.SetActive(false);
            _enemyRockets.Add(enemyRockets);
        }
    }

    public GameObject GetPlayerBullets()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            if (!_playerBullets[i].activeInHierarchy)
                return _playerBullets[i];
        }

        return null;
    }

    public GameObject GetEnemyBullets()
    {
        for (int i = 0; i < _poolCount; i++)
        {
            if (!_enemyBullets[i].activeInHierarchy)
                return _enemyBullets[i];
        }

        return null;
    }

    public GameObject GetEnemyRockets()
    {
        for (int i = 0; i < _rocketCount; i++)
        {
            if (!_enemyRockets[i].activeInHierarchy)
                return _enemyRockets[i];
        }

        return null;
    }
}
