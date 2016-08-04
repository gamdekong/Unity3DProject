using UnityEngine;
using System.Collections;

public class ResetGrid : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<UIGrid>().Reposition();
	
	}
    void OnEnable()
    {
        GetComponent<UIGrid>().Reposition();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
