using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Spawner _spawner;

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
        Instantiate(_bossPrefab, transform.position, Quaternion.identity);
    }
}
