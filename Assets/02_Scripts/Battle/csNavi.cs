using UnityEngine;
using System.Collections;

public class csNavi : MonoBehaviour {

    public GameObject player;
    public GameObject planet;
    public UILabel label;

	// Use this for initialization
	void Start () {
        label = GetComponent<UILabel>();
        player = GameObject.Find("Player");
        if(GameObject.FindGameObjectWithTag("Planet"))
        {
            planet = GameObject.FindGameObjectWithTag("Planet");
        }
        else
        {
            planet = null;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(planet)
        {
            float dis = Vector3.Distance(player.transform.position, planet.transform.position);
            label.text = "Planet : " + dis.ToString("0.#") + " m";
        }
        else
        {
            label.text = "Planet : -- m";
        }
	}
}
