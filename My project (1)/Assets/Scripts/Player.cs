using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : Unit
{
    [SerializeField] private int _coins;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;

    public int Coins => _coins;

    private Animator _animator;
    private Health _health;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
    public override void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void AddCoin(int value)
    {
        _coins += value;
    }

    public void Heal(int heal)
    {
        _health.Heal(heal);
    }

    public void Shoot()
    {
        Bullet newBullet = Instantiate(_bullet, _shootPosition.position, _bullet.transform.rotation);
    }
}
