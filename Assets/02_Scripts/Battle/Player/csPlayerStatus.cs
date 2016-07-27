using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csPlayerStatus : MonoBehaviour {

    public int playerFuel = 20;
    public float fuelConsumeDelay = 3.0f;
    public int consumeAmount = 1;
    public int plasma;
    public bool untouchable = false;
    public GameObject fuelBar;
    public GameObject hitEffect;
    public GameObject playerCam;

    public GameObject targetingManager;
    public GameObject fireManager;
    public GameObject uiManager;
    public GameObject dbManager;

    public AudioClip warningSFX;

    public bool playonce = false;
    bool whileCorutine = false;
    int fuel;
    int consume;
    float delay;
    float blinkDelay = 1.5f;

	// Use this for initialization
	void Start () {
        dbManager = GameObject.Find("DBManager");
        playerFuel = dbManager.GetComponent<DBManager>().GetPlayerEnergy();
        consumeAmount = GameObject.Find("SpawnManager").GetComponent<SpawnManager>().fuelDamage;

        fuelBar.GetComponent<csShowFuel>().maxFuel = (float)playerFuel;
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

                if (!playonce)
                {
                    playonce = true;
                    GameObject.Find("Player").GetComponent<csPlayerMovement>().respawnPos = GameObject.Find("Player").transform.position;
                    GameObject.Find("Player").GetComponent<csPlayerMovement>().respawnRot = GameObject.Find("Player").transform.rotation;
                    GameObject.Find("UIManager").SendMessage("WaitForContinue", SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        if (!whileCorutine)
        {
            if (fuel < (playerFuel / 4) && blinkDelay >= 1.5f)
            {
                if (fuel == 0)
                {
                    hitEffect.SetActive(false);
                    return;
                }

                StartCoroutine(ShowEffect());

                blinkDelay = 0;
            }
            else if (fuel > (playerFuel / 4))
            {
                hitEffect.SetActive(false);
                blinkDelay = 1.5f;
            }
            else
            {
                blinkDelay += Time.deltaTime;
            }
        }

        fuelBar.GetComponent<csShowFuel>().fuelValue = (float)fuel;
    }

    void GetFuel(int amount)
    {
        if (GetComponent<csPlayerMovement>().fuelEmpty)
            return;

        fuel += amount;
        if (fuel > playerFuel)
            fuel = playerFuel;
    }

    public void DamageToFuel()
    {
        fuel -= playerFuel / 10;
    }

    public void SetFuel(int value)
    {
        fuel = value;
    }

    IEnumerator ShowEffect()
    {
        whileCorutine = true;
        hitEffect.SetActive(true);

        AudioManager.Instance().PlaySfx(warningSFX);

        yield return new WaitForSeconds(0.5f);

        hitEffect.SetActive(false);
        whileCorutine = false;
    }
}