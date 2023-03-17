using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private Bullet _bullet;

    public int EnemyHealth
    {
        get
        { return _health; }
        private set
        {
            if(_health <= 0)
                Destroy(gameObject);

            _health = Mathf.Clamp(value, 0, _health);
        }
    }

    public override void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }

    public virtual void Attack()
    {
        Instantiate(_bullet, transform.position, Quaternion.identity);
    }
}
