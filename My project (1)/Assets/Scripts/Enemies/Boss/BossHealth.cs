using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DeadEffectSpawner))]
public class BossHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _health;

    public event UnityAction BossDead;

    public int MaxHealth => _maxHealth;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            if (_health <= 0)
                Die();

            _health = Mathf.Clamp(value, 0, _maxHealth);
        }
    }

    private DeadEffectSpawner _spawner;

    private int _maxHealth = 24200;

    private void Start()
    {
        _spawner = GetComponent<DeadEffectSpawner>();
        CurrentHealth = _maxHealth;
    }

    public void Die()
    {
        BossDead?.Invoke();
        Debug.Log("Its over");
        Destroy(gameObject);
        _spawner.SpawnDeadEffect();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
