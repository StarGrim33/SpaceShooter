using UnityEngine;

public class HunterBullet : BaseEnemyBullet
{
    private int _damage = 25;
    private float _speed = 8f;
    private float _rotation = 10f;

    protected override void Awake()
    {
        _player = FindObjectOfType<Player>();
        _poolObject = GetComponent<PoolObject>();
        _target = new Vector2(_player.transform.position.x - _rotation, _player.transform.position.y);
    }

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        transform.Rotate(0, 0, _rotation * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }
    }
}
