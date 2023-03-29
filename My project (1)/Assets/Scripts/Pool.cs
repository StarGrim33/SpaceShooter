using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool SharedInstance;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private GameObject _playerBulletsContainer;

    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private GameObject _enemyBulletsContainer;

    [SerializeField] private int _rocketCount;
    [SerializeField] private GameObject _enemyRocket;
    [SerializeField] private GameObject _enemyRocketsContainer;

    [SerializeField] private int _hunterBulletsCount;
    [SerializeField] private GameObject _hunterBullet;
    [SerializeField] private GameObject _hunterBulletContainer;

    private List<GameObject> _playerBullets = new List<GameObject>();
    private List<GameObject> _enemyBullets = new List<GameObject>();
    private List<GameObject> _enemyRockets = new List<GameObject>();
    private List<GameObject> _hunterBullets = new List<GameObject>();

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        CreateObjects(_playerBullet, _playerBulletsContainer.transform, _poolCount, _playerBullets);
        CreateObjects(_enemyBullet, _enemyBulletsContainer.transform, _poolCount, _enemyBullets);
        CreateObjects(_enemyRocket, _enemyRocketsContainer.transform, _rocketCount, _enemyRockets);
        CreateObjects(_hunterBullet, _hunterBulletContainer.transform, _hunterBulletsCount, _hunterBullets);
    }

    private void CreateObjects(GameObject prefab, Transform parent, int count, List<GameObject> list)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            list.Add(obj);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        List<GameObject> list = null;

        if (prefab == _playerBullet)
        {
            list = _playerBullets;
        }
        else if (prefab == _enemyBullet)
        {
            list = _enemyBullets;
        }
        else if (prefab == _enemyRocket)
        {
            list = _enemyRockets;
        }
        else if(prefab == _hunterBullet)
        {
            list = _hunterBullets;
        }
        else
        {
            return null;
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
                return list[i];
        }

        return null;
    }
}
