using System.Collections.Generic;
using UnityEngine;

public abstract class Pool<T> : MonoBehaviour where T : Component
{
    public static Pool<T> SharedInstance;

    private int _poolCount;
    private T _bullet;
    private Transform _container;

    private List<T> objectList = new List<T>();

    protected virtual void Awake()
    {
        SharedInstance = this;
        CreateObjects(_poolCount);
    }

    protected virtual void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_bullet, _container);
            obj.gameObject.SetActive(false);
            objectList.Add(obj);
        }
    }

    public virtual T GetObject()
    {
        for (int i = 0; i < objectList.Count; i++)
        {
            if (!objectList[i].gameObject.activeInHierarchy)
            {
                return objectList[i];
            }
        }

        return null;
    }
}
