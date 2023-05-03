using System.Collections;
using UnityEngine;

public class BattleDroneAttack : Attack
{
    [SerializeField] private Transform _droneShootPoint;
    private float _shootDelay = 3f;
    private float _lastAttackTime;

    protected override void Shoot()
    {
        Rocket instance = RocketsPool.Instance.GetObject();
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
