using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBulletsPool : Pool<HunterBullet>
{
    public static HunterBulletsPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _hunterBullet;
    [SerializeField] private GameObject _hunterBulletContainer;

    private List<GameObject> _hunterBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_hunterBullet, _hunterBulletContainer.transform);
            obj.gameObject.SetActive(false);
            _hunterBullets.Add(obj);
        }
    }

    public override HunterBullet GetObject()
    {
        for (int i = 0; i < _hunterBullets.Count; i++)
        {
            if (_hunterBullets[i].gameObject.activeInHierarchy == false)
            {
                return _hunterBullets[i].gameObject.GetComponent<HunterBullet>();
            }
        }

        return null;
    }
}
