using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : Weapon
{
    [SerializeField] private GameObject _playerBullet;

    public override void Shoot(Transform shootPoint)
    {
        GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
        instance.transform.position = shootPoint.position;
        instance.SetActive(true);
    }
}
