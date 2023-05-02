using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PoolObject))]
public abstract class BaseEnemyBullet : MonoBehaviour
{
    private int _baseDamage = 10;
    private float _baseSpeed = 6f;

    protected float _baseLifeTime = 2f;
    protected float _baseRange = 10f;

    protected Vector2 _target;
    protected Player _player;
    protected PoolObject _poolObject;

    protected virtual void Awake()
    {
        _player = FindObjectOfType<Player>();
        _poolObject = GetComponent<PoolObject>();
    }

    private void Start()
    {
        _target = new Vector2(_player.transform.position.x - _baseRange, _player.transform.position.y);
    }

    protected virtual void Update()
    {
        _target = new Vector2(_player.transform.position.x - _baseRange, _player.transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, _target, _baseSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        StartCoroutine(Destroy());
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(_baseDamage);
            _poolObject.ReturnToPool();
        }
        
    }

    private IEnumerator Destroy()
    {
        var waitForSeconds = new WaitForSeconds(_baseLifeTime);
        yield return waitForSeconds;
        _poolObject.ReturnToPool();
    }

    public void ReturnToPool()
    {
        _poolObject.ReturnToPool();
    }
}
