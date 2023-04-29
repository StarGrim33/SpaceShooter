using UnityEngine;

public class PauseMenu
{
    [SerializeField] private GameObject _pauseMenu;

    public void PauseGame()
    {
        _pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
