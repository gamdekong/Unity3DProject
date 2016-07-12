using UnityEngine;
using System.Collections;

public class csAsteroidStatus : MonoBehaviour {

    GameObject player;
    public GameObject root;
    public GameObject asteroidExpEffect;
    public int health = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Update is called once per frame
	void Update () {
        if (!player)
            Destroy(gameObject);

        float dis = Vector3.Distance(player.transform.position, transform.position);
        if (dis > 20 && player.transform.position.z > transform.position.z)
            Destroy(gameObject);

        RotateAsteroid();

    }
    
    void RotateAsteroid()
    {
        transform.Rotate(Vector3.up * 25.0f * Time.deltaTime);
    }

    public void DamageToObject(int damage)
    {
        health -= damage;
        //Debug.Log(name + " : " + health);

        if (health <= 0)
        {
            gameObject.SetActive(false);

            GameObject particleObj = Instantiate(asteroidExpEffect) as GameObject;
            particleObj.transform.position = transform.position;
            Destroy(particleObj, 1.0f);

            Instantiate(root, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
    }
}
