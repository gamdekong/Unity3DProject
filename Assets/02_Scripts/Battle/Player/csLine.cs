using UnityEngine;
using System.Collections;

public class csLine : MonoBehaviour {

    public LineRenderer line;
    public GameObject planet;
    public Vector3[] nodes;
    Vector3 node = Vector3.zero;

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
            foreach(Vector3 tmp in nodes)
            {
                if(tmp.z > node.z && tmp.z > transform.position.z)
                {
                    if(node == Vector3.zero)
                        node = tmp;

                    if (Vector3.Distance(tmp, transform.position) < Vector3.Distance(node, transform.position))
                    {
                        node = tmp;
                    }
                }
                else
                {
                    node = Vector3.zero;
                }
            }
            if(node == Vector3.zero)
            {
                line.SetPosition(1, planet.transform.position);
            }
            else
            {
                line.SetPosition(1, node);
            }
        }
	}
}
