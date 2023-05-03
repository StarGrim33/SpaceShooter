using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BossHealth))]
public class Boss : Unit
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _stageChange;

    public event UnityAction<int> StageChanged;

    public int CurrentPhase => _currentPhase;

    private BossHealth _health;

    private int _healthPerPhase = 8000;
    private float _phaseChangeDelay = 2f;
    private int _currentPhase = 1;
    private int _secondsStage = 2;
    private int _thirdStage = 3;

    protected override int CollisionDamage => 250;

    private void Awake()
    {
        _health = GetComponent<BossHealth>();
    }

    private void Start()
    {
        _audioSource.Play();
    }

    private void Update()
    {
        StageSwitch();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health player))
        {
            player.TakeDamage(CollisionDamage);
        }
    }

    private void StageSwitch()
    {
        if (_health.CurrentHealth <= _healthPerPhase * _secondsStage && _currentPhase < _secondsStage)
        {
            StartCoroutine(StageTransition(_secondsStage));
            StageChanged?.Invoke((int)BossStages.Second);
        }
        else if (_health.CurrentHealth <= _healthPerPhase  && _currentPhase < _thirdStage)
        {
            StartCoroutine(StageTransition(_thirdStage));
            StageChanged?.Invoke((int)BossStages.Third);
        }
    }

    private IEnumerator StageTransition(int index)
    {
        var waitForSeconds = new WaitForSeconds(_phaseChangeDelay);
        _currentPhase = index;
        _audioSource.clip = _stageChange;
        _audioSource.Play();
        yield return waitForSeconds;
    }
}