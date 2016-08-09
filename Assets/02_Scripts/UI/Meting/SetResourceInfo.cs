using UnityEngine;
using System.Collections;

public class SetResourceInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<UIPlayTween>().tweenTarget = GameObject.Find("UIManager").GetComponent<MeltResource>().resourceMelting;
    }
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SetResource()
    {
        GameObject popup = GameObject.Find("ResourceMeltingPopup");

        popup.GetComponent<MeltingResultResource>().RIdx = GetComponent<Resource>().resourceId;

        popup.GetComponent<MeltingResultResource>().tier = GetComponent<Resource>().tier;

        


    }
}
