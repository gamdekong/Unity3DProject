using UnityEngine;
using System.Collections;

public class MeltingResultResource : MonoBehaviour {

    public int RIdx;
    public int resourceAmount =0;
    public int tier=0;

    public int totalPrice=0;

    public UILabel amount;
    public UILabel price;

    // Use this for initialization
    void Start () {
	
	}
	void OnDisable()
    {
        RIdx = 0;
        resourceAmount = 0;
        tier = 0;
    }
	// Update is called once per frame
	void Update () {

        amount.text = resourceAmount.ToString();
        if(tier == 5)
        {
            totalPrice = resourceAmount * 2150;
            
        }
        else if (tier == 4)
        {
            totalPrice = resourceAmount * 14875;
        }
        else if (tier == 3)
        {
            totalPrice = resourceAmount * 95000;
        }
        else if (tier == 2)
        {
            totalPrice = resourceAmount * 578125;
        }
        else if (tier == 1)
        {
            totalPrice = resourceAmount * 6875000;
        }
        price.text = totalPrice.ToString();

    }
    public void UpButton()
    {
        int nowAmount = DBManager.Instance.GetNumOfResourceOnId(RIdx);
        resourceAmount += 1;

        if (resourceAmount > nowAmount)
            resourceAmount = nowAmount;
        
    }
    public void DownButton()
    {
        resourceAmount -= 1;
        if (resourceAmount < 0)
            resourceAmount = 0;
    }
}
