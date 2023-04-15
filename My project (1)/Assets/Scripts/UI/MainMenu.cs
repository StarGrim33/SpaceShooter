using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _deadScreen;

    private void OnEnable() => YandexGame.RewardVideoEvent += AdRestart;
    private void OnDisable() => YandexGame.RewardVideoEvent -= AdRestart;

    public void PlayGame()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void AdRestart(int id)
    {
        int heal = 100;

        if(id == 0)
        {
            YandexGame.RewVideoShow(0);
            _player.GetComponent<Health>().Heal(heal);
            _deadScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
