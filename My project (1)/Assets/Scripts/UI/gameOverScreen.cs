using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOverScreen : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private AudioSource _audioSource;

    private void OnEnable()
    {
        _health.PlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        _health.PlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        _gameObject.SetActive(true);
        _audioSource.Play();
    }
}
