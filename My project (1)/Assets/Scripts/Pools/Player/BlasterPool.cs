using System.Collections.Generic;
using UnityEngine;

public class BlasterPool : Pool<Bullet>
{
    public static BlasterPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _blasterBullet;
    [SerializeField] private GameObject _blasterBulletContainer;

    private List<GameObject> _blasterBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_blasterBullet, _blasterBulletContainer.transform);
            obj.gameObject.SetActive(false);
            _blasterBullets.Add(obj);
        }
    }

    public override Bullet GetObject()
    {
        for (int i = 0; i < _blasterBullets.Count; i++)
        {
            if (_blasterBullets[i].gameObject.activeInHierarchy == false)
            {
                return _blasterBullets[i].gameObject.GetComponent<Bullet>();
            }
        }

        return null;
    }


    public void UpdateBullets(int value)
    {
        for (int i = 0; i < _blasterBullets.Count; i++)
        {
            _blasterBullets[i].GetComponent<Bullet>().UpgradeDamage(value);
        }
    }
}
