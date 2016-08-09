using UnityEngine;
using System.Collections;

public class csPlanetStatus : MonoBehaviour {

    public int health = 100;
    public GameObject planetExpEffect;
    GameObject UIManager;
    csPlayerCamManager playerCam;
    public AudioClip expSFX;  

	// Use this for initialization
	void Start () {
        UIManager = GameObject.Find("UIManager");
        playerCam = GameObject.Find("PlayerCamPos").GetComponent<csPlayerCamManager>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void DamageToObject(int damage)
    {
        health -= damage;
        //Debug.Log(name + " : " + health);

        if (health <= 0)
        {
            //UIManager.GetComponent<UIManager>().SendMessage("Vibration");
            //Handheld.Vibrate();
            playerCam.PlanetPlayCameraShake();

            gameObject.SetActive(false);

            GameObject particleObj = Instantiate(planetExpEffect) as GameObject;
            particleObj.transform.position = transform.position;
            Destroy(particleObj, 5.0f);

            GameObject.Find("UIManager").SendMessage("StageClear", SendMessageOptions.DontRequireReceiver);
            AudioManager.Instance().PlaySfx(expSFX);
            Destroy(gameObject);
        }
    }
}
