using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

    public GameObject progress;
  

	// Use this for initialization
	void Start () {

        int playerLevel = DBManager.Instance.GetPlayerLevel();

        int playerExp = DBManager.Instance.GetPlayerExp();
        int expData = DBManager.Instance.GetExpData(playerLevel);
        progress.GetComponent<UISlider>().value = (float)playerExp / (float)expData;

        progress.GetComponent<UISlider>().thumb.GetComponentsInChildren<UILabel>()[0].text = playerExp.ToString()+" / "+expData.ToString() + " EXP";


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
