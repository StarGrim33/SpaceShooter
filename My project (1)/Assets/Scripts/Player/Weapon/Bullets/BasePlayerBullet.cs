using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public abstract class BasePlayerBullet : MonoBehaviour
{
    private int _baseDamage = 10;
    private float _baseSpeed = 6f;
    private float _lifeTime = 2f;
    protected PoolObject _poolObject;

    private void Start()
    {
        _poolObject = GetComponent<PoolObject>();
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, _baseSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_baseDamage);
            _poolObject.ReturnToPool();
        }

        if (collision.TryGetComponent<BossHealth>(out BossHealth boss))
        {
            boss.TakeDamage(_baseDamage);
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
