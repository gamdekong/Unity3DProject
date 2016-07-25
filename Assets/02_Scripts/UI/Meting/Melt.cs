using UnityEngine;
using System.Collections;

public class Melt : MonoBehaviour {

    public GameObject slot;
    public GameObject grid;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MeltResource()
    {
        if (slot.transform.childCount > 0)
        {



            Transform resource = slot.transform.GetChild(0);
            int pastPlazma = DBManager.Instance.GetPlayerPlazma();

            int resourceId = resource.GetComponent<Resource>().resourceId;   // 카드 자원아이디
            int plazma = DBManager.Instance.GetPlazmaOnResourceId(resourceId);
            int amount = resource.GetComponent<Resource>().numOfResource;  // 카드 자원 개수

            DBManager.Instance.SetPlayerPlazma(pastPlazma + (plazma * amount));


            DBManager.Instance.DeletePlayerResource(resourceId);

            Destroy(resource.gameObject);
        }
    }

}

