using System.Collections;
using UnityEngine;

public class PatrolDroneAttack : Attack
{
    [SerializeField] private Transform _droneShootPoint;
    private float _shootDelay = 1.5f;
    private float _lastAttackTime;

    protected override void Shoot()
    {
        SimpleBullet simpleBullet = SimpleBulletPool.Instance.GetObject();
        Rocket rocket = RocketsPool.Instance.GetObject();
        simpleBullet.transform.position = _droneShootPoint.position;
        simpleBullet.gameObject.SetActive(true);
        rocket.transform.position = _droneShootPoint.position;
        rocket.gameObject.SetActive(true);
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
