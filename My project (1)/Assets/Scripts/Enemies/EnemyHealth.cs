using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;
    [SerializeField] private BuffSpawner _buffSpawner;
    [SerializeField] private DeadEffectSpawner _deadEffectSpawner;

    public event UnityAction<EnemyHealth> Dying;

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

    private bool _canBeDestroyed = false;
    private float _destroyDistance = 8f;

    private void OnEnable()
    {
        if(_health <= 0)
            _health = _maxHealth;
    }

    private void Update()
    {
        if (transform.position.x <= _destroyDistance)
            _canBeDestroyed = true;
    }

    public void Die()
    {
        _buffSpawner.CalculateSpawnBuffProbability();
        _deadEffectSpawner.SpawnDeadEffect();
        Dying?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException("Value cannot be negative", nameof(damage));

        CurrentHealth -= damage;
    }
}
