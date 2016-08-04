using UnityEngine;
using System.Collections;

public class csLine : MonoBehaviour {

    public LineRenderer line;
    public GameObject planet;
    public Vector3[] nodes;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Planet"))
            planet = GameObject.FindGameObjectWithTag("Planet");
        else
            planet = null;

        if (planet)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, planet.transform.position);
        }
	}
}
