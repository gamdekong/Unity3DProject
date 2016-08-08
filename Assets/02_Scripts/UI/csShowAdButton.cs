using UnityEngine;
using System.Collections;

public class csShowAdButton : MonoBehaviour {

    public Transform card;
    public GameObject makingBar;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeCardAd()
    {
        DBManager.Instance.MakeCard(card,2);
        makingBar.SetActive(true);
        makingBar.GetComponent<TweenScale>().Play(true);
        makingBar.GetComponent<MakingBar>().MakingBarStart(card.GetComponent<CardInfo>().type);
    }
}
