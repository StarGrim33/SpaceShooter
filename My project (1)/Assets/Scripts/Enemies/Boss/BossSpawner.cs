using UnityEngine;
using UnityEngine.Events;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Transform _bossTargetPosition;

    public event UnityAction BossSpawned;

    private void Start()
    {
        _spawner.ReachedLastWave += OnWaveGeneratedHandler;
    }

    private void OnDestroy()
    {
        _spawner.ReachedLastWave -= OnWaveGeneratedHandler;
    }

    private void OnWaveGeneratedHandler()
    {
        GameObject boss = Instantiate(_bossPrefab, transform.position, Quaternion.identity);
        boss.GetComponent<BossMoving>().SetTargetPosition(_bossTargetPosition);
        BossSpawned?.Invoke();
    }
}
