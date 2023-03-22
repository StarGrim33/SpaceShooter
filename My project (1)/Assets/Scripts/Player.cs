using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator), typeof(Health))]
public class Player : Unit
{
    [SerializeField] private int _coins;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AudioClip _playSound;

    public int Coins {get { return _coins; } private set { _coins = value; } }

    public event UnityAction MoneyChanged;

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
        {
            _currentWeapon.Shoot(_shootPosition);
            AudioSource.PlayClipAtPoint(_playSound, transform.position, 0.2f);
        }
    }

    public override void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    public void AddCoins(int value)
    {
        Coins += value;
        MoneyChanged.Invoke();
    }

    public void Heal(int heal)
    {
        _health.Heal(heal);
    }
}
