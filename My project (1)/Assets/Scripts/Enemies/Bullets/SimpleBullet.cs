using UnityEngine;

public class SimpleBullet : BaseEnemyBullet
{
    private int _damage = 10;
    private float _speed = 8f;
    private float _range = 10f;


    protected override void Awake()
    {
        _player = FindObjectOfType<Player>();
        _target = new Vector2(_player.transform.position.x - _range, _player.transform.position.y);
        _poolObject = GetComponent<PoolObject>();
    }

    protected override void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
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
}
