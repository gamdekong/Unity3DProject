using UnityEngine;
using System.Collections;

public class csPlanetStatus : MonoBehaviour {

    public int health = 100;

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
            GameObject.Find("UIManager").SendMessage("StageClear", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
