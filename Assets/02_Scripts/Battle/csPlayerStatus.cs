using UnityEngine;
using System.Collections;

public class csPlayerStatus : MonoBehaviour {

    public int playerHealth = 100;
    public float healthDmgDelay = 3.0f;
    public int healthDmg = 1;
    int health;
    int damage;
    float delay;
	// Use this for initialization
	void Start () {
        delay = healthDmgDelay;
        health = playerHealth;
        damage = healthDmg;
    }
	
	// Update is called once per frame
	void Update () {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            delay = healthDmgDelay;
            if (health > 0)
            {
                health -= damage;
                Debug.Log("PlayerHP : " + health);
            }
            else
            {
                SendMessage("playerDead", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    void PlayerHealthRestore(int amount)
    {
        health += amount;
        if (health > playerHealth)
            health = playerHealth;
    }
}