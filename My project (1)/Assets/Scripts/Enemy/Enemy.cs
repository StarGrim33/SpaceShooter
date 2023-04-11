using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : Unit
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private GameObject[] _dieEffects;
    [SerializeField] private GameObject[] _buffs;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Vector3 _offset;

    private int _collisionDamage = 40;

    private bool _canBeDestroyed = false;

    public event UnityAction<Enemy> Dying;
    public int Health => _health;

    public int Reward => _reward;

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

    private void Update()
    {
        DisplayHealth();

        if (transform.position.x < 17f)
            _canBeDestroyed = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_collisionDamage);
            Die();
        }
    }

    public override void TakeDamage(int damage)
    {
        if (_canBeDestroyed)
            EnemyHealth -= damage;
    }

    public void Die()
    {
        int minNumber = 0;
        int maxNumber = 100;
        int chance = 50;

        var randomEffect = Random.Range(0, _dieEffects.Length);
        Instantiate(_dieEffects[randomEffect], transform.position, Quaternion.identity);

        if (Random.Range(minNumber, maxNumber) <= chance)
        {
            var randomBuff = Random.Range(0, _buffs.Length);
            Instantiate(_buffs[randomBuff], transform.position, Quaternion.identity);
        }

        Dying?.Invoke(this);
        gameObject.SetActive(false);
    }

    public void DisplayHealth()
    {
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position + _offset);
        //_text.transform.position = screenPos;
        _text.text = EnemyHealth.ToString();
    }
}
