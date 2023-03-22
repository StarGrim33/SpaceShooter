using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    private bool _canBeDestroyed = false;

    private void Update()
    {
        if (transform.position.x < 17f)
            _canBeDestroyed = true;
    }

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
        if (_canBeDestroyed)
            EnemyHealth -= damage;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
