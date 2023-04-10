using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _totalHealth = 3000;
    [SerializeField] private int _healthPerPhase = 1000;
    [SerializeField] private float _phaseChangeDelay = 3f;
    [SerializeField] private GameObject[] _attackPrefabs; 
    [SerializeField] private Transform[] _attackSpawnPoint;
    [SerializeField] private GameObject[] _deathEffects;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _stageChange;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _shotDelay = 1f;

    public event UnityAction BossDead;

    private int _currentHealth;
    private float _lastShotTime = 0f;
    private float _speed = 8f;
    private int _currentPhase = 1;
    private int _collisionDamage = 100;

    public int BossHealth
    {
        get { return _currentHealth; }
        private set
        {
            if (_currentHealth <= 0)
                Die();

            _currentHealth = Mathf.Clamp(value, 0, _totalHealth);
        }
    }

    private void Awake()
    {
        _targetPosition = GameObject.Find("BossTargetPosition").transform;
    }

    private void Start()
    {
        _audioSource.Play();
        _currentHealth = _totalHealth;
    }

    private void Update()
    {
        if (Time.time - _lastShotTime >= _shotDelay)
        {
            Shoot();
            _lastShotTime = Time.time;
        }

        Vector3 direction = (_targetPosition.position - transform.position).normalized;
        Vector3 newPosition = transform.position + direction * _speed * Time.deltaTime;
        transform.position = newPosition;

        if (BossHealth <= _healthPerPhase * 2 && _currentPhase < 2)
        {
            StartCoroutine(SecondPhase());
        }
        else if (BossHealth <= _healthPerPhase && _currentPhase < 3)
        {
            StartCoroutine(ThirdPhase());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.TakeDamage(_collisionDamage);
        }
    }

    private void Shoot()
    {
        if (_currentPhase <= _attackPrefabs.Length)
        {
            if(_currentPhase == 2)
            {
                for (int i = 0; i <= 5;  i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_currentPhase - 1]);

                    if(attack != null)
                    {
                        int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
            else if(_currentPhase == 3)
            {
                for (int i = 0; i <= 7; i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_currentPhase - 1]);

                    if(attack != null)
                    {
                        int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    GameObject attack = Pool.SharedInstance.GetObject(_attackPrefabs[_currentPhase - 1]);

                    if(attack != null)
                    {
                        int randomShootPoint = Random.Range(0, _attackSpawnPoint.Length);
                        attack.transform.position = _attackSpawnPoint[randomShootPoint].position;
                        attack.SetActive(true);
                    }
                }
            }
        }
    }

    private IEnumerator SecondPhase()
    {
        _currentPhase = 2;
        _audioSource.clip = _stageChange;
        _audioSource.Play();
        _shotDelay = 0.5f;
        yield return new WaitForSeconds(_phaseChangeDelay);
    }

    private IEnumerator ThirdPhase()
    {
        _currentPhase = 3;
        _audioSource.clip = _stageChange;
        _audioSource.Play();
        _shotDelay = 0.5f;
        yield return new WaitForSeconds(_phaseChangeDelay);
    }

    private void Die()
    {
        BossDead?.Invoke();
        var randomEffect = Random.Range(0, _deathEffects.Length);
        Instantiate(_deathEffects[randomEffect], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        BossHealth -= damage;
    }
}