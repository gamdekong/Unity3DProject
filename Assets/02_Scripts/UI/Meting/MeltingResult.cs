using UnityEngine;
using System.Collections;

public class MeltingResult : MonoBehaviour {

    public int idx;
    public int price;
    public UILabel amount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        amount.text = price.ToString();
	
	}
}
