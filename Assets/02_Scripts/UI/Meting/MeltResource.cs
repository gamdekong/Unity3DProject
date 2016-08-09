using UnityEngine;
using System.Collections;

public class MeltResource : MonoBehaviour {


    public GameObject popup;
    public GameObject scrolView1;
    public GameObject scrolView2;
    public GameObject scrolView3;
    public GameObject scrolView4;
    public GameObject scrolView5;
    public GameObject grid;

    public GameObject cardMelting;
    public GameObject resourceMelting;




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
       // scrolView.SetActive(false);
        //Wait();

        if(popup.GetComponent<MeltingResultResource>().tier ==5)
        {
            scrolView5.SetActive(false);
            scrolView5.SetActive(true);
            scrolView5.GetComponent<UIScrollView>().ResetPosition();
        }
        else if (popup.GetComponent<MeltingResultResource>().tier == 4)
        {
            scrolView4.SetActive(false);
            scrolView4.SetActive(true);
            scrolView4.GetComponent<UIScrollView>().ResetPosition();
        }
        else if (popup.GetComponent<MeltingResultResource>().tier == 3)
        {
            scrolView3.SetActive(false);
            scrolView3.SetActive(true);
            scrolView3.GetComponent<UIScrollView>().ResetPosition();
        }
        else if (popup.GetComponent<MeltingResultResource>().tier == 2)
        {
            scrolView2.SetActive(false);
            scrolView2.SetActive(true);
            scrolView2.GetComponent<UIScrollView>().ResetPosition();
        }
        else if (popup.GetComponent<MeltingResultResource>().tier == 1)
        {
            scrolView1.SetActive(false);
            scrolView1.SetActive(true);
            scrolView1.GetComponent<UIScrollView>().ResetPosition();

        }


    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
