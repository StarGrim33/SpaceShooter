using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Pool SharedInstance;

    [SerializeField] private int _poolCount;
    [SerializeField] private GameObject _objectToPool;
    [SerializeField] private GameObject _container;
    [SerializeField] private List<GameObject> _pooledObjects;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        GameObject newObject;

        for(int i = 0; i < _poolCount; i++)
        {
            newObject = Instantiate(_objectToPool, _container.transform);
            newObject.SetActive(false);
            _pooledObjects.Add(newObject);
        }
    }

    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < _poolCount;i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
                return _pooledObjects[i];
        }

        return null;
    }
}
