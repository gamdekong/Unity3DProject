using UnityEngine;
using System.Collections;

public class MeltingSlotManager : MonoBehaviour {

    public UILabel plazma;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.childCount > 0)
        {
            Resource res = transform.GetChild(0).GetComponent<Resource>();

            plazma.text = (res.plazma *res.numOfResource).ToString();
           
           
        }
        else
        {
            plazma.text = "0";


        }
    }
}
