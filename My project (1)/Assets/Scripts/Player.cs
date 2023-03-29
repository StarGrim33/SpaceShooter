using System.Collections;
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
    [SerializeField] private ShieldController _shieldController;

    public int Coins {get { return _coins; } private set { _coins = value; } }

    public event UnityAction MoneyChanged;

    private Animator _animator;
    private Health _health;
    private Weapon _currentWeapon;
    private float _shootTimer = 0.15f;
    private float _timer;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _timer = _shootTimer;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if(_timer <= 0f)
            {
                _currentWeapon.Shoot(_shootPosition);
                AudioSource.PlayClipAtPoint(_playSound, transform.position, 0.2f);
                _timer = _shootTimer;
            }
        }
    }

    public override void TakeDamage(int damage)
    {
        if(_shieldController.IsShieldActive)
        {
            _shieldController.TakeDamage(damage);
        }

        else if(_shieldController.IsShieldActive == false) 
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
