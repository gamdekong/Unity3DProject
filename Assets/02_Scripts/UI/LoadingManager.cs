using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour {

    public GameObject Slider;
    public Material skyboxMat;
    public bool isMain = true;
    AsyncOperation async;

    // Use this for initialization
    IEnumerator Start()
    {
        Color color = new Vector4(0.24f, 0.72f, 0.88f, 1);
        skyboxMat.SetColor("_Tint", color);
        RenderSettings.skybox = skyboxMat;

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