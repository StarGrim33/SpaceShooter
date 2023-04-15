using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class SkipIntro : MonoBehaviour
{
    public void Skip()
    {
        YandexGame.FullscreenShow();
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
}
