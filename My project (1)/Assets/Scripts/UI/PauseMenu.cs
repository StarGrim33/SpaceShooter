using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private bool _isPaused = false;

    public void PauseGame()
    {
        if (_isPaused == false)
        {
            _isPaused = true;
            _pauseMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
