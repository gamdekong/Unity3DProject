using UnityEngine;
using System.Collections;

public class CardInSlotState : MonoBehaviour {

    

	// Use this for initialization
	void Start () {

       

	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).transform.rotation.z == 0)
            {
                if (transform.GetChild(0).GetComponent<UIPlayTween>() != null)
                {
                    transform.GetChild(0).GetComponent<UIPlayTween>().Play(false);
                }

            }
        }
	
	}
}
