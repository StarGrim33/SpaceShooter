using UnityEngine;
using UnityEngine.Events;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Spawner _spawner;

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
        Debug.Log("Spawned");
        Instantiate(_bossPrefab, transform.position, Quaternion.identity);
        BossSpawned?.Invoke();
    }
}
