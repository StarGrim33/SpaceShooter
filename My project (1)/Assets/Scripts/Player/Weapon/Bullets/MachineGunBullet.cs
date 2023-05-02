using UnityEngine;

public class MachineGunBullet : BasePlayerBullet
{
    private int _damage = 12;
    private float _speed = 16f;

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.right, _speed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }

        if (collision.TryGetComponent<BossHealth>(out BossHealth boss))
        {
            boss.TakeDamage(_damage);
            _poolObject.ReturnToPool();
        }
    }

    public void UpgradeDamage(int value)
    {
        _damage += value;
    }
}
