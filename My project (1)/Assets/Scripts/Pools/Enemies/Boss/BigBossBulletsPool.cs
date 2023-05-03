using System.Collections.Generic;
using UnityEngine;

public class BigBossBulletsPool : Pool<BigBullet>
{
    public static BigBossBulletsPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _bigBullet;
    [SerializeField] private GameObject _bigBulletContainer;

    private List<GameObject> _bigBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_bigBullet, _bigBulletContainer.transform);
            obj.gameObject.SetActive(false);
            _bigBullets.Add(obj);
        }
    }

    public override BigBullet GetObject()
    {
        for (int i = 0; i < _bigBullets.Count; i++)
        {
            if (_bigBullets[i].gameObject.activeInHierarchy == false)
            {
                return _bigBullets[i].gameObject.GetComponent<BigBullet>();
            }
        }

        return null;
    }
}
