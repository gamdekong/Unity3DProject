using UnityEngine;
using System.Collections;

public class CardInGridState : MonoBehaviour {
    private Transform[] childs;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(transform.childCount > 0)
        {
            childs = GetComponentsInChildren<Transform>();

            foreach(Transform child in childs)
            {
                if(child.rotation.z != 0 )
                {
                    if (child.GetComponent<UIPlayTween>() != null)
                        child.GetComponent<UIPlayTween>().Play(true);

                }
            }
        }
	
	}
}
