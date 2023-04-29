using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class MainMenuNavigator : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _deadScreen;
    [SerializeField] private Scenes _scenes;

    private void OnEnable() => YandexGame.RewardVideoEvent += AdRestart;
    private void OnDisable() => YandexGame.RewardVideoEvent -= AdRestart;

    public void PlayGame()
    {
        SceneManager.LoadScene(_scenes.GameScene, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(_scenes.GameScene, LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }

    public void AdRestart(int id)
    {
        var player = _player.GetComponent<Health>();
        int heal = player.MaxHealth;

        if(id == 0)
        {
            YandexGame.RewVideoShow(0);
            player.Heal(heal);
            _deadScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
