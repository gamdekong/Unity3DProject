using UnityEngine;
using System.Collections;

public class SuccessCardTween : MonoBehaviour {

    public UILabel label;
    public GameObject card;
    public GameObject button;

    public UILabel atk;
    public UILabel energy;
    public UILabel rate;
    public UILabel damage;
    public UILabel tier;

    public int atkI;
    public int energyI;
    public float rateI;
    public float damageI;
    public float tierI;
    public float type;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        if (type == 1)
        {
            card.GetComponent<UISprite>().spriteName = "damageCard";
        }
        else if (type == 2)
        {
            card.GetComponent<UISprite>().spriteName = "energyCard";
        }
        else if (type == 3)
        {
            card.GetComponent<UISprite>().spriteName = "CriticalRateCard";
        }
        else if (type == 4)
        {
            card.GetComponent<UISprite>().spriteName = "criticalDamageCard";
        }

        label.GetComponent<TweenAlpha>().ResetToBeginning();
        label.GetComponent<TweenAlpha>().Play(true);
        card.GetComponent<TweenScale>().ResetToBeginning();
        card.GetComponent<TweenScale>().Play(true);
        card.GetComponent<TweenRotation>().ResetToBeginning();
        card.GetComponent<TweenRotation>().Play(true);

        atk.text = atkI.ToString();
        energy.text = energyI.ToString();
        rate.text = (rateI*100).ToString()+"%";
        damage.text = (damageI*100).ToString()+"%";
        tier.text = tierI.ToString()+"등급";

    }
    public void DisableButton()
    {
        button.SetActive(false);
    }

    public void ButtonActive()
    {
        button.SetActive(true);
    }
}
