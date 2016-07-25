using UnityEngine;
using System.Collections;

public class MakeCard : MonoBehaviour {

    public GameObject slot;
    public GameObject grid;

    public GameObject popup;

    int numOfTitanium;
    int numOfUranium;
    int numOfHydrogen;
    int numOfPlutonium;
    int numOfPlazma;

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
                popup.GetComponent<UIPlayTween>().Play(true);
                Debug.Log("ddd)");
                return;
            }
            if (card.GetComponent<CardInfo>().needUranium > numOfUranium)
            {
                popup.GetComponent<UIPlayTween>().Play(true);
                return;
            }
            if (card.GetComponent<CardInfo>().needHydrogen > numOfHydrogen)
            {
                popup.GetComponent<UIPlayTween>().Play(true);
                return;
            }
            if (card.GetComponent<CardInfo>().needPlutonium > numOfPlutonium)
            {
                popup.GetComponent<UIPlayTween>().Play(true);
                return;
            }

            if (card.GetComponent<CardInfo>().needPrice > numOfPlazma)
            {
                popup.GetComponent<UIPlayTween>().Play(true);
                return;
            }







            card.parent = grid.transform;

            Vector3 pos = card.localPosition;
            pos.z = 0f;
            card.localPosition = pos;

            card.GetComponent<DragAndDropMakingCard>().ResetPosition(grid.transform.GetChild(0));

            DBManager.Instance.MakeCard(card);
        }
    }
}
