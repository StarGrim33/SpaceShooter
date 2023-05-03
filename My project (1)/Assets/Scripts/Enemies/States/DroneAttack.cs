using System.Collections;
using UnityEngine;

public class DroneAttack : Attack
{
    [SerializeField] private Transform _droneShootPoint;
    private float _shootDelay = 2f;
    private float _lastAttackTime;

    protected override void Shoot()
    {
        SimpleBullet instance = SimpleBulletPool.Instance.GetObject();
        instance.transform.position = _droneShootPoint.position;
        instance.gameObject.SetActive(true);
    }

    protected override IEnumerator Assail()
    {
        var waitForSeconds = new WaitForSeconds(_shootDelay);

        _lastAttackTime -= Time.deltaTime;

        if (_lastAttackTime <= 0f)
        {
            Shoot();
            _lastAttackTime = _shootDelay;
        }

        yield return waitForSeconds;
    }
}
