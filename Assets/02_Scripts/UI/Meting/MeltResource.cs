using UnityEngine;
using System.Collections;

public class MeltResource : MonoBehaviour {


    public GameObject popup;
    public GameObject scrolView;
    public GameObject grid;

    private int totalResourceAmount;

    private int nowResourceAmount;
    private int plazma;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Melt()
    {
        
        plazma = DBManager.Instance.GetPlayerPlazma();
        plazma += popup.GetComponent<MeltingResultResource>().totalPrice;
        DBManager.Instance.SetPlayerPlazma(plazma);
        

        DBManager.Instance.setResource(popup.GetComponent<MeltingResultResource>().RIdx, -(popup.GetComponent<MeltingResultResource>().resourceAmount));


       // grid.GetComponent<MakingCardInMeltingGrid>().Delete();
       // grid.GetComponent<MakingCardInMeltingGrid>().CardSet();
        scrolView.SetActive(false);
        //Wait();
        scrolView.SetActive(true);

        //grid.GetComponent<UIGrid>().Reposition();

        //scrolView.GetComponent<UIScrollView>().ResetPosition();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
