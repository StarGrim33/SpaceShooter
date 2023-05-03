using System.Collections.Generic;
using UnityEngine;

public class LaserBossBulletsPool : Pool<LaserBullet>
{
    public static LaserBossBulletsPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _laserBullet;
    [SerializeField] private GameObject _laserBulletContainer;

    private List<GameObject> _laserBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_laserBullet, _laserBulletContainer.transform);
            obj.gameObject.SetActive(false);
            _laserBullets.Add(obj);
        }
    }

    public override LaserBullet GetObject()
    {
        for (int i = 0; i < _laserBullets.Count; i++)
        {
            if (_laserBullets[i].gameObject.activeInHierarchy == false)
            {
                return _laserBullets[i].gameObject.GetComponent<LaserBullet>();
            }
        }

        return null;
    }
}
