using UnityEngine;
using System.Collections;

public class csDistanceText : MonoBehaviour {

    public GameObject player;

    float distance;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        distance = Vector3.Distance(transform.position, player.transform.position);
        
        gameObject.GetComponent<TextMesh>().text = distance.ToString("0.#") + " m";
	}
}
