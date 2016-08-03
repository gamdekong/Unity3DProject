using UnityEngine;
using System.Collections;

public class BuyResource : MonoBehaviour {
    public GameObject popup;
    public GameObject alertPopup;

    int totalPlazma;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Buy()
    {

        int nowPlazma = DBManager.Instance.GetPlayerPlazma();


        if(popup.GetComponent<ResourcePopupManager>().tier == 5)
        {
            totalPlazma = 330 * popup.GetComponent<ResourcePopupManager>().amount;
        }
        else if (popup.GetComponent<ResourcePopupManager>().tier == 4)
        {
            totalPlazma = 1650 * popup.GetComponent<ResourcePopupManager>().amount;
        }
        else if (popup.GetComponent<ResourcePopupManager>().tier == 3)
        {
            totalPlazma = 8250 * popup.GetComponent<ResourcePopupManager>().amount;
        }
        else if (popup.GetComponent<ResourcePopupManager>().tier == 2)
        {
            totalPlazma = 41250 * popup.GetComponent<ResourcePopupManager>().amount;
        }
        else if (popup.GetComponent<ResourcePopupManager>().tier == 1)
        {
            totalPlazma = 412500 * popup.GetComponent<ResourcePopupManager>().amount;
        }

        if( totalPlazma > nowPlazma)
        {
            alertPopup.SetActive(true);
            alertPopup.GetComponent<TweenScale>().ResetToBeginning();
            alertPopup.GetComponent<TweenScale>().Play(true);
            return;
        }
        else
        {
            DBManager.Instance.SetPlayerPlazma(nowPlazma - totalPlazma);
            if(popup.GetComponent<ResourcePopupManager>().type ==1)
            {
                DBManager.Instance.setUraniumOnTier(popup.GetComponent<ResourcePopupManager>().tier,
                    DBManager.Instance.GetPlayerUranium(popup.GetComponent<ResourcePopupManager>().tier) +
                   popup.GetComponent<ResourcePopupManager>().amount);
            }
            else if (popup.GetComponent<ResourcePopupManager>().type == 2)
            {
                Debug.Log(popup.GetComponent<ResourcePopupManager>().tier);
                DBManager.Instance.setTitaniumOnTier(popup.GetComponent<ResourcePopupManager>().tier,
                    DBManager.Instance.GetPlayerTitanium(popup.GetComponent<ResourcePopupManager>().tier) +
                    popup.GetComponent<ResourcePopupManager>().amount);
            }
            else if (popup.GetComponent<ResourcePopupManager>().type == 3)
            {
                DBManager.Instance.setPlutoniumOnTier(popup.GetComponent<ResourcePopupManager>().tier,
                    DBManager.Instance.GetPlayerPlutonium(popup.GetComponent<ResourcePopupManager>().tier) +
                    popup.GetComponent<ResourcePopupManager>().amount);
            }
            else if (popup.GetComponent<ResourcePopupManager>().type == 4)
            {
                DBManager.Instance.setHydrogenOnTier(popup.GetComponent<ResourcePopupManager>().tier,
                    DBManager.Instance.GetPlayerHydrogen(popup.GetComponent<ResourcePopupManager>().tier) +
                    popup.GetComponent<ResourcePopupManager>().amount);
            }

        }


    }
}
