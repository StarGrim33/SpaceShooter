using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IHealth
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private ShieldController _shield;

    public event UnityAction<int> Reduced;
    public event UnityAction<int> Incresead;
    public event UnityAction PlayerDead;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);

            if (_health <= 0)
            {
                Die();
            }
        }
    }

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public void Die()
    {
        PlayerDead?.Invoke();
        Time.timeScale = 0f;
    }

    public void TakeDamage(int damage)
    {
        if (_shield.IsShieldActive)
        {
            _shield.TakeDamage(damage);
        }
        else
        {
            CurrentHealth -= damage;
            Reduced?.Invoke(CurrentHealth);
        }
    }

    public void UpgradeHealth(int value)
    {
        if (value < 0)
            throw new ArgumentException("Value cannot be negative", nameof(value));

        _maxHealth += value;
        _health = _maxHealth;
        Incresead?.Invoke(CurrentHealth);
    }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        Incresead?.Invoke(CurrentHealth);
    }
}
