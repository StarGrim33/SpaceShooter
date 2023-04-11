using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HunterBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    public float Speed => _speed;

    private PoolObject _poolObject;
    private Vector2 _target;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _poolObject = GetComponent<PoolObject>();
        _target = new Vector2(_player.transform.position.x - 10f, _player.transform.position.y);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        transform.Rotate(0, 0, 10 * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
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
