using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletPool : Pool<SimpleBullet>
{
    public static SimpleBulletPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _simpleBullet;
    [SerializeField] private GameObject _simpleBulletContainer;

    private List<GameObject> _simpleBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_simpleBullet, _simpleBulletContainer.transform);
            obj.gameObject.SetActive(false);
            _simpleBullets.Add(obj);
        }
    }

    public override SimpleBullet GetObject()
    {
        for (int i = 0; i < _simpleBullets.Count; i++)
        {
            if (_simpleBullets[i].gameObject.activeInHierarchy == false)
            {
                return _simpleBullets[i].gameObject.GetComponent<SimpleBullet>();
            }
        }

        return null;
    }
}
