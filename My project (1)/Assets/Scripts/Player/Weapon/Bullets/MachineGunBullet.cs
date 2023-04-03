using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }

        if (collision.TryGetComponent<SimpleBullet>(out SimpleBullet simpleBullet))
        {
            _poolObject.ReturnToPool();
        }
    }

    private IEnumerator Destroy()
    {
        var waitForSeconds = new WaitForSeconds(_lifeTime);
        yield return waitForSeconds;
        _poolObject.ReturnToPool();
    }
}