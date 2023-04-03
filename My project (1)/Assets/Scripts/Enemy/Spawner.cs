using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Player _player;

    public event UnityAction AllEnemySpawned;
    public event UnityAction WaveChanged;
    
    public int WaveCount => _waves.Count;
    public int CurrentWave => _currentWaveIndex;

    private float _elapsedTime = 0;
    private Wave _currentWave;
    private int _currentWaveIndex = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWaveIndex);
    }

    private void Update()
    {
        int spawnPoint = Random.Range(0, _spawnPoints.Length);

        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy(spawnPoint);
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Amount <= _spawned)
        {
            if (_waves.Count > _currentWaveIndex + 1)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void InstantiateEnemy(int spawnPoint)
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[spawnPoint].position, _spawnPoints[spawnPoint].rotation, _spawnPoints[spawnPoint]).GetComponent<Enemy>();
        enemy.Dying += OnEnemyDying;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _player.AddCoins(enemy.Reward);
        enemy.Dying -= OnEnemyDying;
    }

    public void NextWave()
    {
        SetWave(++_currentWaveIndex);
        WaveChanged?.Invoke();
        _spawned = 0;
    }
}

[System.Serializable]
public class Wave
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private int _amount;

    public float Delay => _delay;
    public GameObject Template => _enemyPrefab;
    public float Amount => _amount;
}
