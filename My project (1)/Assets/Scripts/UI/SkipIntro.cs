using UnityEngine.SceneManagement;
using YG;

public class SkipIntro
{
    public void Skip()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
}
