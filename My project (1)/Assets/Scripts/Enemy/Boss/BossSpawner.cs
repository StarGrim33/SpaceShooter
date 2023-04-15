using System;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bossPrefab;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Boss _boss;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private AudioSource _victorySound;

    private void Start()
    {
        _spawner.ReachedLastWave += OnWaveGeneratedHandler;
    }

    private void OnBossDead()
    {
        Invoke("OpenVictoryScreen", 2f);
    }

    private void OnDestroy()
    {
        if (_boss != null)
        {
            _boss.BossDead -= OnBossDead;
        }

        _spawner.ReachedLastWave -= OnWaveGeneratedHandler;
    }

    private void OnWaveGeneratedHandler()
    {
        GameObject boss = Instantiate(_bossPrefab, transform.position, Quaternion.identity);
        _boss = boss.GetComponent<Boss>();

        if (_boss != null)
        {
            _boss.BossDead += OnBossDead;
        }
    }

    private void OpenVictoryScreen()
    {
        Time.timeScale = 0f;
        _victorySound.Play();
        _victoryScreen.SetActive(true);
    }
}
