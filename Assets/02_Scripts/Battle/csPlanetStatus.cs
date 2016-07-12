using UnityEngine;
using System.Collections;

public class csPlanetStatus : MonoBehaviour {

    public int health = 100;
    public GameObject planetExpEffect;
    public AudioClip expSFX;  

	// Use this for initialization
	void Start () {
	
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
