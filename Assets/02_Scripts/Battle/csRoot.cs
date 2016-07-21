using UnityEngine;
using System.Collections;

public class csRoot : MonoBehaviour {

    public float speed = 10;
    public int fuel = 10;
    public int plasma = 0;

    public GameObject player;
    public AudioClip rootSound;

    void Start()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player");
        }
        else
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
       }
        else
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            AudioManager.Instance().PlaySfx(rootSound);
            player.SendMessage("GetFuel", fuel, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
