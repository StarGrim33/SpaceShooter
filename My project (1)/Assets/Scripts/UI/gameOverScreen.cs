using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Boss _boss;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioSource _faultSound;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private AudioSource _victorySound;

    private void OnEnable()
    {
        _health.PlayerDead += OnPlayerDead;
        _boss.BossDead += OnBossDead;
    }

    private void OnDisable()
    {
        _health.PlayerDead -= OnPlayerDead;
        _boss.BossDead -= OnBossDead;
    }

    private void OnBossDead()
    {
        Time.timeScale = 0f;
        _victoryScreen.SetActive(true);
        _victorySound.Play();
    }

    private void OnPlayerDead()
    {
        _gameOverScreen.SetActive(true);
        _faultSound.Play();
    }
}
