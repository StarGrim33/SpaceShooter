using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneLoader
{
    [SerializeField] private Scenes _scenes;

    private void OnEnable()
    {
        SceneManager.LoadScene(_scenes.GameScene, LoadSceneMode.Single);
    }
}
