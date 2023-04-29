using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _enemyBullet;
    private float _lastAttackTime;

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Shoot();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject instance = Pool.SharedInstance.GetObject(_enemyBullet);
        instance.transform.position = _shootPoint.position;
        instance.SetActive(true);
    }
}
