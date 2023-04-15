using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool SharedInstance;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _playerBullet;
    [SerializeField] private GameObject _playerBulletsContainer;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _playerMachineGunBullet;
    [SerializeField] private GameObject _playerMachineGunContainer;

    [SerializeField] private GameObject _enemyBullet;
    [SerializeField] private GameObject _enemyBulletsContainer;

    [SerializeField] private int _rocketCount;
    [SerializeField] private GameObject _enemyRocket;
    [SerializeField] private GameObject _enemyRocketsContainer;

    [SerializeField] private int _hunterBulletsCount;
    [SerializeField] private GameObject _hunterBullet;
    [SerializeField] private GameObject _hunterBulletContainer;

    [SerializeField] private int _firstBossBulletCount;
    [SerializeField] private GameObject _firstBossBullet;
    [SerializeField] private GameObject _firstBossBulletContainer;

    [SerializeField] private int _secondBossBulletCount;
    [SerializeField] private GameObject _secondBossBullet;
    [SerializeField] private GameObject _secondBossBulletContainer;

    [SerializeField] private int _thirdBossBulletCount;
    [SerializeField] private GameObject _thirdBossBullet;
    [SerializeField] private GameObject _thirdBossBulletContainer;

    private List<GameObject> _playerBullets = new List<GameObject>();
    private List<GameObject> _machineGunBullets = new List<GameObject>();
    private List<GameObject> _enemyBullets = new List<GameObject>();
    private List<GameObject> _enemyRockets = new List<GameObject>();
    private List<GameObject> _hunterBullets = new List<GameObject>();

    private List<GameObject> _firstBossBullets = new List<GameObject>();
    private List<GameObject> _secondBossBullets = new List<GameObject>();
    private List<GameObject> _thirdBossBullets = new List<GameObject>();

    private void Awake()
    {
        SharedInstance = this;
        CreateObjects(_playerBullet, _playerBulletsContainer.transform, _poolCount, _playerBullets);
        CreateObjects(_playerMachineGunBullet, _playerMachineGunContainer.transform, _count, _machineGunBullets);
        CreateObjects(_enemyBullet, _enemyBulletsContainer.transform, _poolCount, _enemyBullets);
    }

    private void Start()
    {
        CreateObjects(_enemyRocket, _enemyRocketsContainer.transform, _rocketCount, _enemyRockets);
        CreateObjects(_hunterBullet, _hunterBulletContainer.transform, _hunterBulletsCount, _hunterBullets);
        CreateObjects(_firstBossBullet, _firstBossBulletContainer.transform, _firstBossBulletCount, _firstBossBullets);
        CreateObjects(_secondBossBullet, _secondBossBulletContainer.transform, _secondBossBulletCount, _secondBossBullets);
        CreateObjects(_thirdBossBullet, _thirdBossBulletContainer.transform, _thirdBossBulletCount, _thirdBossBullets);
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
        else if(prefab == _playerMachineGunBullet)
        {
            list = _machineGunBullets;
        }
        else if(prefab == _firstBossBullet)
        {
            list = _firstBossBullets;
        }
        else if(prefab == _secondBossBullet)
        {
            list = _secondBossBullets;
        }
        else if(prefab == _thirdBossBullet)
        {
            list = _thirdBossBullets;
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

    public void UpdateBullets(GameObject prefab, int value)
    {
        if (prefab == _playerBullet)
        {
            for(int i = 0; i < _playerBullets.Count; i++)
            {
                _playerBullets[i].GetComponent<Bullet>().UpgradeDamage(value);
            }
        }
    }
}
