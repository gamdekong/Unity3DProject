using UnityEngine;
using System.Collections;

public class InitiateWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnDisable()
    {
        if (GetComponent<UIToggle>().value == false)
        {

            GetComponent<UIToggle>().value = true;
            //GameObject.Find("Equipment").GetComponent<UIToggle>().value = false;
           // GameObject.Find("Evolution").GetComponent<UIToggle>().value = false;
        }

    }

    void OnEnable()
    {


          GetComponent<UIToggledObjects>().Toggle();


        


    }
    public void SetValue()
    {

    }
}
