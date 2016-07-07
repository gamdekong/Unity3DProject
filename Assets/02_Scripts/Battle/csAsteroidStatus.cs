using UnityEngine;
using System.Collections;

public class csAsteroidStatus : MonoBehaviour {

    GameObject player;
    public GameObject root;
    public int health = 10;
    float targetingDis;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        targetingDis = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>().MaxTargetingDistance;
    }

	// Update is called once per frame
	void Update () {
        if (!player)
            Destroy(gameObject);

        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (dis > targetingDis && player.transform.position.z > transform.position.z)
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
