using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csPlayerStatus : MonoBehaviour {

    public int playerFuel = 100;
    public float fuelConsumeDelay = 3.0f;
    public int consumeAmount = 1;
    public bool untouchable = false;
    public GameObject fuelBar;
    public GameObject hitEffect;
    public GameObject playerCam;

    public GameObject targetingManager;
    public GameObject fireManager;

    int fuel;
    int consume;
    float delay;
    float blinkDelay = 0.5f;
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
            }
            else
            {
                GetComponent<csPlayerMovement>().fuelEmpty = true;
                playerCam.transform.DetachChildren();
                targetingManager.GetComponent<TargetingManager>().isDead = true;
                fireManager.GetComponent<csFireManager>().isDead = true;
                fuel = 0;
            }
        }

        if (fuel < 5 && blinkDelay >= 0.5f)
        {
            if (fuel == 0)
            {
                hitEffect.SetActive(false);
                return;
            }

            if (hitEffect.activeInHierarchy)
                hitEffect.SetActive(false);
            else
                hitEffect.SetActive(true);

            blinkDelay = 0;
        }
        else if(fuel > 5)
        {
            hitEffect.SetActive(false);
            blinkDelay = 0.5f;
        }
        else
        {
            blinkDelay += Time.deltaTime;
        }

        fuelBar.GetComponent<Slider>().value = fuel;
    }

    void GetFuel(int amount)
    {
        fuel += amount;
        if (fuel > playerFuel)
            fuel = playerFuel;
    }
}