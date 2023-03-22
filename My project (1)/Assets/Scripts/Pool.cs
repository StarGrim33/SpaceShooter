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
}
