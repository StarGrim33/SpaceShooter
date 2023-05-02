using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource), typeof(Wallet))]
public class Player : Unit
{
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private AudioClip _playSound;
    [SerializeField] private AudioClip _pickupSound;
    
    public AudioSource Clip => _audioSource;

    private Weapon _currentWeapon;
    private AudioSource _audioSource;
    private Wallet _wallet;

    private float _shootTimer = 0.15f;
    private float _timer;
    private int _currentWeaponNumber = 0;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _pickupSound;
        _currentWeapon = _weapons[0];
        _timer = _shootTimer;
        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void Start()
    {
        if(Time.timeScale == 0f)
            Time.timeScale = 1f;
    }

    private void Update()
    {
        StartCoroutine(Shoot());
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public void BuyWeapon(Weapon weapon)
    {
        _wallet.RemoveCoins(weapon.Price);
        _weapons.Add(weapon);
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

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_shootTimer);

        _timer -= Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            if (_timer <= 0f)
            {
                _currentWeapon.Shoot(_shootPosition);
                AudioSource.PlayClipAtPoint(_playSound, transform.position, 0.2f);
                _timer = _shootTimer;
            }
        }

        yield return waitForSeconds;
    }
}
