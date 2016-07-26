using UnityEngine;
using System.Collections;

public class Audiomanager : MonoBehaviour {

    public AudioSource click;

	// Use this for initialization
	void Start () {

        GetComponent<AudioSource>().Play();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
