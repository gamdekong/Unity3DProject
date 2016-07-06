using UnityEngine;
using System.Collections;

public class csPlayerStatus : MonoBehaviour {

    public int playerFuel = 100;
    public float fuelConsumeDelay = 3.0f;
    public int consumeAmount = 1;
    public bool untouchable = false;
    int fuel;
    int consume;
    float delay;
	// Use this for initialization
	void Start () {
        delay = fuelConsumeDelay;
        fuel = playerFuel;
        consume = consumeAmount;
    }
	
	// Update is called once per frame
	void Update () {
        if (untouchable)
            return;

        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            delay = fuelConsumeDelay;
            if (fuel > 0)
            {
                fuel -= consume;
                Debug.Log("Fuel : " + fuel);
            }
            else
            {
                SendMessage("playerDead", SendMessageOptions.DontRequireReceiver);
            }
        }
       
    }

    void GetFuel(int amount)
    {
        fuel += amount;
        if (fuel > playerFuel)
            fuel = playerFuel;
    }
}