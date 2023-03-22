using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private GameObject[] _dieEffects;

    private bool _canBeDestroyed = false;
    public event UnityAction<Enemy> Dying;
    public int Reward => _reward;

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
        var randomEffect = Random.Range(0, _dieEffects.Length);
        Instantiate(_dieEffects[randomEffect], transform.position, Quaternion.identity);
        Dying?.Invoke(this);
        gameObject.SetActive(false);
    }
}
