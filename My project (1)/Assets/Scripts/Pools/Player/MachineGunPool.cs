using System.Collections.Generic;
using UnityEngine;

public class MachineGunPool : Pool<MachineGunBullet>
{
    public static MachineGunPool Instance;

    [SerializeField] private int _count;
    [SerializeField] private GameObject _machineGunBullet;
    [SerializeField] private GameObject _machineGunContainer;

    private List<GameObject> _machineGunBullets = new List<GameObject>();

    protected override void Awake()
    {
        Instance = this;
        CreateObjects(_count);
    }

    protected override void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(_machineGunBullet, _machineGunContainer.transform);
            obj.gameObject.SetActive(false);
            _machineGunBullets.Add(obj);
        }
    }

    public override MachineGunBullet GetObject()
    {
        for (int i = 0; i < _machineGunBullets.Count; i++)
        {
            if (_machineGunBullets[i].gameObject.activeInHierarchy == false)
            {
                return _machineGunBullets[i].gameObject.GetComponent<MachineGunBullet>();
            }
        }

        return null;
    }

    public void UpdateBullets(int value)
    {
        for (int i = 0; i < _machineGunBullets.Count; i++)
        {
            _machineGunBullets[i].GetComponent<MachineGunBullet>().UpgradeDamage(value);
        }
    }
}
