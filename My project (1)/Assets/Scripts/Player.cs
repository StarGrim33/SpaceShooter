using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Health))]
public class Player : Unit
{
    [SerializeField] private int _coins;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AudioClip _playSound;
    [SerializeField] private ShieldController _shieldController;
    [SerializeField] private AudioClip _pickupSound;

    public int Coins {get { return _coins; } private set { _coins = value; } }

    public AudioSource Clip => _audioSource;
    public event UnityAction MoneyChanged;

    private Health _health;
    private Weapon _currentWeapon;
    private AudioSource _audioSource;
    private float _shootTimer = 0.15f;

    private float _timer;
    private int _currentWeaponNumber = 0;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _pickupSound;
        _currentWeapon = _weapons[0];
        _health = GetComponent<Health>();
        _timer = _shootTimer;
        ChangeWeapon(_weapons[_currentWeaponNumber]);
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

    public void BuyWeapon(Weapon weapon)
    {
        Coins -= weapon.Price;
        _weapons.Add(weapon);
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void NextWeapon()
    {
        if(_currentWeaponNumber == _weapons.Count - 1) 
        { 
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }
}
