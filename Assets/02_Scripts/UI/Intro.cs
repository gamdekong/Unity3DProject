using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    public GameObject logo;
    public GameObject touchLabel;
    public Material skyboxMat;

    public float delay = 2.0f;

    bool canClick = false;

    // Use this for initialization
    void Start () {
        GetComponent<UIPlayTween>().Play(true);

        Color color = new Vector4(0.24f, 0.72f, 0.88f, 1);
        skyboxMat.SetColor("_Tint", color);
        RenderSettings.skybox = skyboxMat;
	}

    void OnClick()
    {
        if(canClick)
            SceneManager.LoadScene("LoadingSceneToMain");
    }
	
	// Update is called once per frame
	void Update () {

	if(delay <= 0)
        {
            delay = 0;
            canClick = true;
        }
    else
        {
            delay -= Time.deltaTime;
        }

    if(canClick && !(touchLabel.activeInHierarchy))
        {
            touchLabel.SetActive(true);
        }
	}
}
