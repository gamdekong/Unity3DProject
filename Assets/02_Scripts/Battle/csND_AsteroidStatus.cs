using UnityEngine;
using System.Collections;

public class csND_AsteroidStatus : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (!player)
            Destroy(gameObject);

        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (dis > 20 && player.transform.position.z > transform.position.z)
            Destroy(gameObject);
    }
}
