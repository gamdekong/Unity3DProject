using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    public GameObject logo;
    public Material skyboxMat;

    // Use this for initialization
    void Start () {
        GetComponent<UIPlayTween>().Play(true);

        Color color = new Vector4(0.24f, 0.72f, 0.88f, 1);
        skyboxMat.SetColor("_Tint", color);
        RenderSettings.skybox = skyboxMat;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
