using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : Unit
{
    [SerializeField] private int _coins;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private List<Weapon> _weapons;

    public int Coins {get { return _coins; } private set { _coins = value; } }

    private Animator _animator;
    private Health _health;
    private Weapon _currentWeapon;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            _currentWeapon.Shoot(_shootPosition);
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

    public void AddCoins(int money)
    {
        Coins += money;
    }
}
