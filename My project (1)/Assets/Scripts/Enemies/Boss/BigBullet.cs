using UnityEngine;

public class BigBullet : BaseEnemyBullet
{
    private int _damage = 18;
    private float _speed = 10f;
    private float _range = 10f;

    protected override void Update()
    {
        _target = new Vector2(_player.transform.position.x - _range, _player.transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
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
