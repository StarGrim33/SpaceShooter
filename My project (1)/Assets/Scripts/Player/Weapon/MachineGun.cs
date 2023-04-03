using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private GameObject _playerBullet;

    public override void Shoot(Transform shootPosition)
    {
        GameObject instance = Pool.SharedInstance.GetObject(_playerBullet);
        instance.transform.position = shootPosition.position;
        instance.SetActive(true);
    }
}
