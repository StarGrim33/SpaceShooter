using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private GameObject _playerBullet;

    private int _criticalDamage = 15;
    private int _chance = 5;

    public override void Shoot(Transform shootPoint)
    {
        float randomNum = Random.Range(1, 101);

        if (randomNum <= _chance)
        {
            GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
            instance.GetComponent<MachineGunBullet>().UpgradeDamage(_criticalDamage);
            instance.transform.position = shootPoint.position;
            instance.SetActive(true);
        }
        else
        {
            GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
            instance.transform.position = shootPoint.position;
            instance.SetActive(true);
        }
    }
}
