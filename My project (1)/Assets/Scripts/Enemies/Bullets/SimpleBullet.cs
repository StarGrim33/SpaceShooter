using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    public float Speed => _speed;
    private Vector2 _target;
    private float _range = 10f;
    private Player _player;

    private PoolObject _poolObject;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _target = new Vector2(_player.transform.position.x - _range, _player.transform.position.y);
        _poolObject = GetComponent<PoolObject>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }

        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            _poolObject.ReturnToPool();
        }

        if(collision.TryGetComponent<MachineGunBullet>(out MachineGunBullet machineGunBullet))
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

    public void ReturnToPool()
    {
        _poolObject.ReturnToPool();
    }
}
