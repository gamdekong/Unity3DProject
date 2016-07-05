﻿using UnityEngine;
using System.Collections;

public class csAsteroidStatus : MonoBehaviour {

    GameObject player;
    public int health = 10;
    public int restorationAmount = 10;

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
            player.SendMessage("PlayerHealthRestore", restorationAmount, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
