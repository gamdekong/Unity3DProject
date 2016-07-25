using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour {

    public GameObject Slider;
    public bool isMain = true;
    AsyncOperation async;

    // Use this for initialization
    IEnumerator Start()
    {
        if (isMain)
            async = SceneManager.LoadSceneAsync("BattleScene");
        else
            async = SceneManager.LoadSceneAsync("MainScene");

        while (!async.isDone)
        {
            float progress = async.progress;

            if (progress > 0.89f)
                progress = 1.0f;

            Slider.GetComponent<UISlider>().value = progress;

            yield return true;
        }
    }
}