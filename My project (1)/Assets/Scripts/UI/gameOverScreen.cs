using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private AudioSource _faultSound;

    private void Start()
    {
        _health.PlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _health.PlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        _gameOverScreen.SetActive(true);
        _faultSound.Play();
    }
}
