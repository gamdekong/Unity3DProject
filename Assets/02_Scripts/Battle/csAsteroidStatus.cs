using UnityEngine;
using System.Collections;

public class csAsteroidStatus : MonoBehaviour {

    GameObject player;
    GameObject UIManager;
    TargetingManager targetingManager;
    csPlayerCamManager playerCam;
    public GameObject root;
    public GameObject asteroidExpEffect;
    public int health = 10;
    public int plasma;
    public int restore;
    public bool LockOn = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UIManager = GameObject.Find("UIManager");
        targetingManager = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>();
        playerCam = GameObject.Find("PlayerCamPos").GetComponent<csPlayerCamManager>();
    }

	// Update is called once per frame
	void Update () {
        if (!player)
            Destroy(gameObject);

        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (dis > 50 && player.transform.position.z > transform.position.z)
            Destroy(gameObject);

        RotateAsteroid();

    }
    
    void RotateAsteroid()
    {
        transform.Rotate(Vector3.up * 25.0f * Time.deltaTime);
    }

    public void DamageToObject(int damage)
    {
        health -= damage;
        //Debug.Log(name + " : " + health);

        if (health <= 0)
        {
            //UIManager.GetComponent<UIManager>().SendMessage("Vibration");
            targetingManager.AimingTarget = null;
            //Handheld.Vibrate();
            playerCam.AsteroidPlayCameraShake();

            gameObject.SetActive(false);
            UIManager.GetComponent<UIManager>().destructionCount += 1;

            GameObject particleObj = Instantiate(asteroidExpEffect) as GameObject;
            particleObj.transform.position = transform.position;
            Destroy(particleObj, 1.0f);

            GameObject rootObj = Instantiate(root, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            rootObj.GetComponent<csRoot>().fuel = restore;
            rootObj.GetComponent<csRoot>().plasma = plasma;
            Destroy(gameObject);
        }
    }
}
