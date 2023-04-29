using UnityEngine;

public class PanelsOpener : MonoBehaviour
{
    [SerializeField] private AudioSource _musicAudioSource;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        _musicAudioSource.Pause();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _musicAudioSource.Play();
    }
}
