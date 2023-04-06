using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioSource _musicAudioSource;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;

        if (_musicAudioSource != null)
            _musicAudioSource.Pause();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;

        if (_musicAudioSource != null)
            _musicAudioSource.Pause();
    }
}
