using UnityEngine;
using System.Collections;

public class MakingCardScrollControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }

    public void ScrollViewReSet()
    {
        GetComponent<UIScrollView>().ResetPosition();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
