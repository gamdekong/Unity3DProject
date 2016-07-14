using UnityEngine;
using System.Collections;

public class csHPText : MonoBehaviour {

    public GameObject target;

    int health;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>().AimingTarget;
	}
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            health = 0;
        else
        {
            if(target.tag == "Asteroid")
                health = target.GetComponent<csAsteroidStatus>().health;
            else
                health = target.GetComponent<csPlanetStatus>().health;
        }

        gameObject.GetComponent<TextMesh>().text = "HP : " + health;
    }
}
