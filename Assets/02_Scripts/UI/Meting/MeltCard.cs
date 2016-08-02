using UnityEngine;
using System.Collections;

public class MeltCard : MonoBehaviour {

    public GameObject popup;
    public GameObject scrolView;
    public GameObject grid;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Melt()
    {
        int plazma;
        plazma = DBManager.Instance.GetPlayerPlazma();
        plazma += popup.GetComponent<MeltingResult>().price;
        DBManager.Instance.SetPlayerPlazma(plazma);

        DBManager.Instance.DeletePlayerCard(popup.GetComponent<MeltingResult>().idx);


        grid.GetComponent<MakingECardInMetingGrid>().DeleteCard();
        grid.GetComponent<MakingECardInMetingGrid>().CardSet();
        grid.GetComponent<UIGrid>().Reposition();
        scrolView.GetComponent<UIScrollView>().ResetPosition();


    }
}
