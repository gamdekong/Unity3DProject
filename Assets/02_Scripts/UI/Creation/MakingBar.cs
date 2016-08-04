using UnityEngine;
using System.Collections;

public class MakingBar : MonoBehaviour {

    public UISprite Card;
    public GameObject cardSlot;
    public GameObject success;

    private float currentFillAmount;
    private int type;

	// Use this for initialization
	void Start () {
        Card.fillAmount = 0;
        currentFillAmount = 0;

    }
	
	// Update is called once per frame
	void Update () {
	


	}
    public IEnumerator MakingBarStart2()
    {
        currentFillAmount = 0;
        yield return new WaitForSeconds(0.3f);
        while (currentFillAmount < 1)
        {
            currentFillAmount += (Time.deltaTime / 2f);
            
            Card.fillAmount = currentFillAmount;

            yield return new WaitForEndOfFrame();
        }
        success.SetActive(true);
        success.GetComponent<TweenAlpha>().ResetToBeginning();
        success.GetComponent<TweenAlpha>().Play(true);
        gameObject.SetActive(false);
    }

    public void MakingBarStart(int typ)
    {
        type = typ;
        if(type == 1)
        {
            Card.spriteName = "damageCard";
        }
        else if (type == 2)
        {
            Card.spriteName = "energyCard";
        }
        else if (type == 3)
        {
            Card.spriteName = "CriticalRateCard";
        }
        else if (type == 4)
        {
            Card.spriteName = "criticalDamageCard";
        }
        StartCoroutine(MakingBarStart2());
    }
}
