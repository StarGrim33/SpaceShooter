using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioSource _faultSound;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private AudioSource _victorySound;
    [SerializeField] private BossSpawner _spawner;

    private BossHealth _boss;

    private void OnEnable()
    {
        _spawner.BossSpawned += OnBossSpawned;
        _health.PlayerDead += OnPlayerDead;
    }

    private void OnBossSpawned()
    {
        _boss = FindObjectOfType<BossHealth>().GetComponent<BossHealth>();
        _boss.BossDead += OnBossDead;
    }

    private void OnBossDead()
    {
        _spawner.BossSpawned -= OnBossSpawned;
        Invoke(nameof(OpenVictoryScreen), 2f);
    }

    private void OnDisable()
    {
        _health.PlayerDead -= OnPlayerDead;

        if (_boss != null)
            _boss.BossDead -= OnBossDead;
    }

    private void OnPlayerDead()
    {
        _gameOverScreen.SetActive(true);
        _faultSound.Play();
    }

    private void OpenVictoryScreen()
    {
        Debug.Log("Victory");
        Time.timeScale = 0f;
        _victorySound.Play();
        _victoryScreen.SetActive(true);
    }
}
