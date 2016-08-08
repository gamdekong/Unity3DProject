using UnityEngine;
using System.Collections;

public class MakeCard : MonoBehaviour {

    public GameObject slot;
    public GameObject grid1;
    public GameObject grid2;
    public GameObject grid3;
    public GameObject grid4;
    public GameObject grid5;

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

            makingBar.SetActive(true);
            makingBar.GetComponent<TweenScale>().Play(true);
            makingBar.GetComponent<MakingBar>().MakingBarStart(card.GetComponent<CardInfo>().type);


            if( needTier == 5)
            {
                card.parent = grid5.transform;
                Vector3 pos = card.localPosition;
                pos.z = 0f;
                card.localPosition = pos;

                card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid5.transform.GetChild(0));
            }
            else if (needTier == 4)
            {
                card.parent = grid4.transform;
                Vector3 pos = card.localPosition;
                pos.z = 0f;
                card.localPosition = pos;

                card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid4.transform.GetChild(0));
            }
            else if (needTier == 3)
            {
                card.parent = grid3.transform;
                Vector3 pos = card.localPosition;
                pos.z = 0f;
                card.localPosition = pos;

                card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid3.transform.GetChild(0));
            }
            else if (needTier == 2)
            {
                card.parent = grid2.transform;
                Vector3 pos = card.localPosition;
                pos.z = 0f;
                card.localPosition = pos;

                card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid2.transform.GetChild(0));
            }
            else if (needTier == 1)
            {
                card.parent = grid1.transform; Vector3 pos = card.localPosition;
                pos.z = 0f;
                card.localPosition = pos;

                card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid1.transform.GetChild(0));
            }
            

            

            DBManager.Instance.MakeCard(card);


            makingBar.SetActive(true);
            makingBar.GetComponent<TweenScale>().Play(true);
            makingBar.GetComponent<MakingBar>().MakingBarStart(card.GetComponent<CardInfo>().type);

        }
    }
}
