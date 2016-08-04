using UnityEngine;
using System.Collections;

public class MakingBar : MonoBehaviour {

    public UISprite Card;

    private float currentFillAmount;

	// Use this for initialization
	void Start () {
        Card.fillAmount = 0;
        currentFillAmount = 0;

    }
	
	// Update is called once per frame
	void Update () {
	


	}
    public IEnumerator MakingBarStart()
    {
        //yield return new WaitForSeconds(0.2f);
        while (currentFillAmount < 1)
        {
            currentFillAmount += (Time.deltaTime / 1000f);
            Debug.Log(currentFillAmount);
            Card.fillAmount = currentFillAmount;

            yield return new WaitForEndOfFrame();
        }
    }
}
