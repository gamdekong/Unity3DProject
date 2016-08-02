using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ResourcePopupManager : MonoBehaviour {


    public UILabel tierLabel;
    public UILabel plazmaLabel;
    public UILabel priceTextLabel;
    public UILabel nameLabel;

    public UIPopupList tierList;
    public UIPopupList amountList;

    public UISprite sprite;

    int tier;
    int amount;
    int plazmaPerTier;
    public int type;

    int totalPlazma;

    // Use this for initialization
    void Start () {

        tier = Int32.Parse(tierList.value);
        amount = Int32.Parse(amountList.value);

    }
	
	// Update is called once per frame
	void Update () {




        if (tier == 5)
            plazmaPerTier = 330;
        else if (tier == 4)
            plazmaPerTier = 1650;
        else if (tier == 3)
            plazmaPerTier = 8250;
        else if (tier == 2)
            plazmaPerTier = 41250;
        else if (tier == 1)
            plazmaPerTier = 412500;

        totalPlazma = plazmaPerTier * amount;

        plazmaLabel.text = totalPlazma.ToString();
        tierLabel.text = tier.ToString();
        priceTextLabel.text = "플라즈마가 " + totalPlazma + " 소모됩니다. 구매하시겠습니까?";

    }
    public void UpdateTier()
    {
        tier = Int32.Parse(tierList.value);
    }
    public void UpdateAmount()
    {
        amount = Int32.Parse(amountList.value);
    }

    public void SetType1()
    {
        type = 1;
        nameLabel.text = "우라늄     등급";
        sprite.spriteName = "uranium";
    }
    public void SetType2()
    {
        type = 2;
        nameLabel.text = "티타늄     등급";
        sprite.spriteName = "titanium";
    }
    public void SetType3()
    {
        type = 3;
        nameLabel.text = "프루토늄      등급";
        sprite.spriteName = "plutonium";
    }
    public void SetType4()
    {
        type = 4;
        nameLabel.text = "러더포듐      등급";
        sprite.spriteName = "ruderpodium";
    }
}
