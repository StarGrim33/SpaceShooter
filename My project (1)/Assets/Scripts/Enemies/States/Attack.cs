using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _enemyBullet;

    private float _lastAttackTime;

    private void Update()
    {
        StartCoroutine(Assail());
    }

    private void Shoot()
    {
        GameObject instance = Pool.SharedInstance.GetObject(_enemyBullet);
        instance.transform.position = _shootPoint.position;
        instance.SetActive(true);
    }

    private IEnumerator Assail()
    {
        var waitForSeconds = new WaitForSeconds(_delay);

        _lastAttackTime -= Time.deltaTime;

        if (_lastAttackTime <= 0f)
        {
            Shoot();
            _lastAttackTime = _delay;
        }

        yield return waitForSeconds;
    }
}
