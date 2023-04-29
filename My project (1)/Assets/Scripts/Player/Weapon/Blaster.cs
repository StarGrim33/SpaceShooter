using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private GameObject _playerBullet;

    private int _criticalDamage = 15;
    private int _chance = 5;

    private void ResetDamage()
    {
        _criticalDamage = 0;
    }

    public override void Shoot(Transform shootPoint)
    {
        float randomNum = Random.Range(1, 101);

        if (randomNum <= _chance)
        {
            GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
            instance.GetComponent<Bullet>().UpgradeDamage(_criticalDamage);
            Debug.Log("Crit!!!");
            instance.transform.position = shootPoint.position;
            instance.SetActive(true);
            ResetDamage();
        }
        else
        {
            GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
            instance.transform.position = shootPoint.position;
            instance.SetActive(true);
        }
    }
}
