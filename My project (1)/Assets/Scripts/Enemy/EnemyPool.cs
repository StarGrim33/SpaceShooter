using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool EnemyPoolInstance;

    [SerializeField] private int _droneCount;
    [SerializeField] private GameObject _dronePrefab;
    [SerializeField] private List<GameObject> _droneList;

    [SerializeField] private int _battleDroneCount;
    [SerializeField] private GameObject _battleDronePrefab;
    [SerializeField] private List<GameObject> _battleDroneList;

    [SerializeField] private int _laserDroneCount;
    [SerializeField] private GameObject _laserDronePrefab;
    [SerializeField] private List<GameObject> _laserDroneList;

    [SerializeField] private int _hunterCount;
    [SerializeField] private GameObject _hunterPrefab;
    [SerializeField] private List<GameObject> _hunterList;

    [SerializeField] private int _patrolCount;
    [SerializeField] private GameObject _patrolPrefab;
    [SerializeField] private List<GameObject> _patrolList;

    [SerializeField] private GameObject _container;

    private void Awake()
    {
        EnemyPoolInstance = this;
        CreateObjects(_dronePrefab, _container.transform, _droneCount, _droneList);
        CreateObjects(_battleDronePrefab, _container.transform, _battleDroneCount, _battleDroneList);
        CreateObjects(_laserDronePrefab, _container.transform, _laserDroneCount, _laserDroneList);
        CreateObjects(_patrolPrefab, _container.transform, _patrolCount, _patrolList);
        CreateObjects(_hunterPrefab, _container.transform, _hunterCount, _hunterList);
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

        if (prefab == _dronePrefab)
        {
            list = _droneList;
        }
        else if (prefab == _battleDronePrefab)
        {
            list = _battleDroneList;
        }
        else if (prefab == _laserDronePrefab)
        {
            list = _laserDroneList;
        }
        else if (prefab == _hunterPrefab)
        {
            list = _hunterList;
        }
        else if (prefab == _patrolPrefab)
        {
            list = _patrolList;
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

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
