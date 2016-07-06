using UnityEngine;
using System.Collections;

public class csAsteroidStatus : MonoBehaviour {

    GameObject player;
    public GameObject root;
    public int health = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
        if (!player)
            Destroy(gameObject);
	}

    public void DamageToObject(int damage)
    {
        health -= damage;
        //Debug.Log(name + " : " + health);

        if (health <= 0)
        {
            Instantiate(root, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }
}
