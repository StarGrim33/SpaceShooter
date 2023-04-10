using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipIntro : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
    }
}
