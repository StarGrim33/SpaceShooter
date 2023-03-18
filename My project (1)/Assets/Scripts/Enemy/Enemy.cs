using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    public Player Target => _target;

    public int EnemyHealth
    {
        get
        { return _health; }
        private set
        {
            if (_health <= 0)
                Die();

            _health = Mathf.Clamp(value, 0, _health);
        }
    }

    public override void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
