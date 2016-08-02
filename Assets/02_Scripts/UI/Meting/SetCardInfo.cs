using UnityEngine;
using System.Collections;

public class SetCardInfo : MonoBehaviour {
    
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetCard()
    {
        GameObject popup = GameObject.Find("CardMeltingPopup");

        popup.GetComponent<MeltingResult>().idx = GetComponent<Card>().idx;

        int tier = DBManager.Instance.GetCardTier(GetComponent<Card>().idx);

        if(tier == 5)
        {
            popup.GetComponent<MeltingResult>().price = 2150;
        }
        else if (tier == 4)
        {
            popup.GetComponent<MeltingResult>().price = 14875;
        }
        else if (tier == 3)
        {
            popup.GetComponent<MeltingResult>().price = 95000;
        }
        else if (tier == 2)
        {
            popup.GetComponent<MeltingResult>().price = 578125;
        }
        else if (tier == 1)
        {
            popup.GetComponent<MeltingResult>().price = 6875000;
        }


    }
}
