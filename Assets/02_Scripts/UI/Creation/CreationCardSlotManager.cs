using UnityEngine;
using System.Collections;

public class CreationCardSlotManager : MonoBehaviour {

    public UILabel titaniumLabel;
    public UILabel uraniumLabel;
    public UILabel hydrogenLabel;
    public UILabel plutoniumLabel;
    public UILabel plazmaLabel;
    public UILabel Tier;

    public UILabel titaniumLabelH;
    public UILabel uraniumLabelH;
    public UILabel hydrogenLabelH;
    public UILabel plutoniumLabelH;

    public UILabel damage;
    public UILabel energy;
    public UILabel criticalRate;
    public UILabel criticalDamage;

    private int nowTitanium = 0;
    private int nowUranium = 0;
    private int nowPlutonium = 0;
    private int nowHydrogen = 0;



    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        if (transform.childCount > 0)
        {
            CardInfo card = transform.GetChild(0).GetComponent<CardInfo>();
            titaniumLabel.text = card.needTitanium.ToString();
            uraniumLabel.text = card.needUranium.ToString();
            hydrogenLabel.text = card.needHydrogen.ToString();
            plutoniumLabel.text = card.needPlutonium.ToString();
            plazmaLabel.text = card.needPrice.ToString();
            Tier.text = card.cardTier.ToString();
            titaniumLabelH.text = nowTitanium.ToString();
            uraniumLabelH.text = nowUranium.ToString();
            hydrogenLabelH.text = nowHydrogen.ToString();
            plutoniumLabelH.text = nowPlutonium.ToString();

            if (card.AminInt == card.AmaxInt)
                damage.text = card.AminInt.ToString();
            else
                damage.text = card.AminInt.ToString() + " ~ " + card.AmaxInt.ToString();

            if (card.EminInt == card.EmaxInt)
                energy.text = card.EminInt.ToString();
            else
                energy.text = card.EminInt.ToString() + " ~ " + card.EmaxInt.ToString();

            if (card.RminF == card.RmaxF)
                criticalRate.text = (card.RminF * 100).ToString() + "%";
            else
                criticalRate.text = (card.RminF * 100).ToString() + "% ~ " + (card.RmaxF * 100).ToString() + "%";
            if (card.DminF == card.DmaxF)
                criticalDamage.text = (card.DminF * 100).ToString() + "%";
            else
                criticalDamage.text = (card.DminF * 100).ToString() + "% ~ " + (card.DmaxF * 100).ToString() + "%";

            //if (transform.GetChild(0).GetComponent<CardInfo>().type == 1)
            //{
            //    damage.text = card.AminInt.ToString() + " ~ " + card.AmaxInt.ToString();
            //    energy.text = card.EminInt.ToString() + " ~ " + card.EmaxInt.ToString();
            //    criticalRate.text = card.RminF.ToString() + " ~ " + card.RmaxF.ToString();
            //    criticalDamage.text = card.DminF.ToString() + " ~ " + card.DmaxF.ToString();
            //}
            //else if (transform.GetChild(0).GetComponent<CardInfo>().type == 2)
            //{
            //    damage.text = "0";
            //    energy.text = card.minInt.ToString() + " ~ " + card.maxInt.ToString();
            //    criticalRate.text = "0 %";
            //    criticalDamage.text = "0 %";
            //}
            //else if (transform.GetChild(0).GetComponent<CardInfo>().type == 3)
            //{
            //    damage.text = "0";
            //    energy.text = "0";
            //    criticalRate.text = (card.minF * 100).ToString() + "% ~ " + (card.maxF * 100).ToString() + "%";
            //    criticalDamage.text = "0 %";
            //}
            //else if (transform.GetChild(0).GetComponent<CardInfo>().type == 4)
            //{
            //    damage.text = "0";
            //    energy.text = "0";
            //    criticalRate.text = "0 %";
            //    criticalDamage.text = (card.minF * 100).ToString() + "% ~ " + (card.maxF * 100).ToString() + "%";
            //}
        }
        else
        {
            titaniumLabel.text = "0";
            uraniumLabel.text = "0";
            hydrogenLabel.text = "0";
            plutoniumLabel.text = "0";
            plazmaLabel.text = "0";

            Tier.text = "0";
            titaniumLabelH.text = "0";
            uraniumLabelH.text = "0";
            hydrogenLabelH.text = "0";
            plutoniumLabelH.text = "0";

            damage.text = "0";
            energy.text = "0";
            criticalRate.text = "0 %";
            criticalDamage.text = "0 %";
        }
    }

    public void SetNumOfMyResourcse(int tier)
    {
        nowTitanium = DBManager.Instance.GetPlayerTitanium(tier);
        nowUranium = DBManager.Instance.GetPlayerUranium(tier); 
        nowPlutonium = DBManager.Instance.GetPlayerPlutonium(tier); 
        nowHydrogen = DBManager.Instance.GetPlayerHydrogen(tier); 
}
}
