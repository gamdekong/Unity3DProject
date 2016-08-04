using UnityEngine;
using System.Collections;

public class MakeCard : MonoBehaviour {

    public GameObject slot;
    public GameObject grid;

    public GameObject popup;

    public GameObject makingBar;

    int numOfTitanium;
    int numOfUranium;
    int numOfHydrogen;
    int numOfPlutonium;
    int numOfPlazma;

    int titaniumResult;
    int uraniumResult;
    int HydrogenResult;
    int plutoniumResult;
    int plazmaResult;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
	
	}

    public void MakeCardStart()
    {
        if (slot.transform.childCount > 0)
        {
            Transform card = slot.transform.GetChild(0).transform;

            int needTier = card.GetComponent<CardInfo>().tier;

            
                numOfTitanium = DBManager.Instance.GetPlayerTitanium(needTier);
                numOfUranium = DBManager.Instance.GetPlayerUranium(needTier);
                numOfHydrogen = DBManager.Instance.GetPlayerHydrogen(needTier);
                numOfPlutonium = DBManager.Instance.GetPlayerPlutonium(needTier);
            numOfPlazma = DBManager.Instance.GetPlayerPlazma();



            if (card.GetComponent<CardInfo>().needTitanium > numOfTitanium)
            {
                popup.SetActive(true);
                popup.GetComponent<TweenScale>().ResetToBeginning();
                popup.GetComponent<TweenScale>().Play(true);

                return;
            }
            if (card.GetComponent<CardInfo>().needUranium > numOfUranium)
            {
                popup.SetActive(true);
                popup.GetComponent<TweenScale>().ResetToBeginning();
                popup.GetComponent<TweenScale>().Play(true);
                return;
            }
            if (card.GetComponent<CardInfo>().needHydrogen > numOfHydrogen)
            {
                popup.SetActive(true);
                popup.GetComponent<TweenScale>().ResetToBeginning();
                popup.GetComponent<TweenScale>().Play(true);
                return;
            }
            if (card.GetComponent<CardInfo>().needPlutonium > numOfPlutonium)
            {
                popup.SetActive(true);
                popup.GetComponent<TweenScale>().ResetToBeginning();
                popup.GetComponent<TweenScale>().Play(true);
                return;
            }

            if (card.GetComponent<CardInfo>().needPrice > numOfPlazma)
            {
                popup.SetActive(true);
                popup.GetComponent<TweenScale>().ResetToBeginning();
                popup.GetComponent<TweenScale>().Play(true);
                return;
            }

            titaniumResult = numOfTitanium - card.GetComponent<CardInfo>().needTitanium;
            uraniumResult = numOfUranium - card.GetComponent<CardInfo>().needUranium;
            HydrogenResult = numOfHydrogen - card.GetComponent<CardInfo>().needHydrogen;
            plutoniumResult = numOfPlutonium - card.GetComponent<CardInfo>().needPlutonium;
            plazmaResult = numOfPlazma - card.GetComponent<CardInfo>().needPrice;

            DBManager.Instance.setTitaniumOnTier(needTier, titaniumResult);
            DBManager.Instance.setUraniumOnTier(needTier, uraniumResult);
            DBManager.Instance.setHydrogenOnTier(needTier, HydrogenResult);
            DBManager.Instance.setPlutoniumOnTier(needTier, plutoniumResult);
            DBManager.Instance.SetPlayerPlazma(plazmaResult);





            card.parent = grid.transform;

            Vector3 pos = card.localPosition;
            pos.z = 0f;
            card.localPosition = pos;

            card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid.transform.GetChild(0));

            DBManager.Instance.MakeCard(card);

            makingBar.SetActive(true);
            makingBar.GetComponent<TweenScale>().Play(true);
        }
    }
}
