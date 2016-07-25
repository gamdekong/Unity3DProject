using UnityEngine;
using System.Collections;

public class WhatYourLevel : MonoBehaviour {

    public GameObject progress;

    // Use this for initialization
    void Start()
    {

        int playerLevel = DBManager.Instance.GetPlayerLevel();
        
        progress.GetComponent<UISlider>().value = (float)playerLevel / 150f;

        progress.GetComponent<UISlider>().thumb.GetChild(0).GetComponent<UILabel>().text = playerLevel.ToString() + " / 150 Level";


    }

    // Update is called once per frame
    void Update () {
	
	}
}
