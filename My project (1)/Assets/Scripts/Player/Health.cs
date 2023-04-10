using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

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
                Die();
        }
    }

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    private void Die()
    {
        PlayerDead?.Invoke();
        Time.timeScale = 0f;
    }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(CurrentHealth);
        Incresead?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(CurrentHealth);
        Reduced?.Invoke(CurrentHealth);
    }

    public void UpgradeHealth(int value)
    {
        _maxHealth += value;
        _health = _maxHealth;
        Incresead?.Invoke(CurrentHealth);
    }
}
