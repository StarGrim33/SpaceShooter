using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    private Player _player;
    private Vector2 _target;
    private PoolObject _poolObject;
    private float _range = 10f;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void Start()
    {
        _target = new Vector2(_player.transform.position.x - _range, _player.transform.position.y);
    }

    private void Update()
    {
        _target = new Vector2(_player.transform.position.x - _range, _player.transform.position.y);

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
