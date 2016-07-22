using UnityEngine;
using System.Collections;

public class StatusSetting : MonoBehaviour {

    public UILabel energy;
    public UILabel damage;
    public UILabel criRate;
    public UILabel criDamage;

    public UILabel basicEnergy;
    public UILabel basicDamage;
    public UILabel basicCriRate;
    public UILabel basicCriDamage;

    public UILabel plusEnergy;
    public UILabel plusDamage;
    public UILabel plusCriRate;
    public UILabel plusCriDamage;

    public UILabel levelLabel;
    public UILabel statPointLebel;


    public UIButton energyButton;
    public UIButton damageButton;
    public UIButton criRateButton;
    public UIButton criDamageButton;





    private int level;
    private int energyR;
    private int damageR;
    private float criRateR;
    private float criDamageR;
    private int stat;

    private int basicEnergyStat;
    private int basicDamageStat;
    private float basicCriRateStat;
    private float basicCriDamageStat;




    // Use this for initialization
    void Start () {
        SetStat();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {

        SetStat();
    }

    void SetStat()
    {

        level = DBManager.Instance.GetPlayerLevel();

        energyR = DBManager.Instance.GetPlayerEnergy();
        damageR = DBManager.Instance.GetPlayerDamage();
        criRateR = DBManager.Instance.GetPlayerCriticalRate();
        criDamageR = DBManager.Instance.GetPlayerCriticalDamage();
        stat = DBManager.Instance.GetPlayerStat();

        basicEnergyStat = DBManager.Instance.GetPlayerBasicEnergy();
        basicDamageStat = DBManager.Instance.GetPlayerBasicDamage();
        basicCriRateStat = DBManager.Instance.GetPlayerBasicCriticalRate();
        basicCriDamageStat = DBManager.Instance.GetPlayerBasicCriticalDamage();


        levelLabel.text = level.ToString();
        statPointLebel.text = stat.ToString();
        
        if(stat > 0 )
        {
            energyButton.gameObject.SetActive(true);
            damageButton.gameObject.SetActive(true);
            criRateButton.gameObject.SetActive(true);
            criDamageButton.gameObject.SetActive(true);
        }
        else
        {
            energyButton.gameObject.SetActive(false);
            damageButton.gameObject.SetActive(false);
            criRateButton.gameObject.SetActive(false);
            criDamageButton.gameObject.SetActive(false);
        }


       
            basicEnergy.text = basicEnergyStat.ToString();
            basicDamage.text = basicDamageStat.ToString();
            basicCriRate.text = (basicCriRateStat*100).ToString() + "%";
            basicCriDamage.text = (basicCriDamageStat*100).ToString() + "%";

            plusEnergy.text = "+ " + (energyR - basicEnergyStat).ToString();
            plusDamage.text = "+ " + (damageR - basicDamageStat).ToString();
            plusCriRate.text = "+ " + ((criRateR - basicCriRateStat) * 100).ToString() + "%";
            plusCriDamage.text = "+ " + ((criDamageR- basicCriDamageStat) * 100).ToString() + "%";

            energy.text = energyR.ToString();
            damage.text = damageR.ToString();
            criRate.text = (criRateR * 100).ToString() + "%";
            criDamage.text = (criDamageR * 100).ToString() + "%";
       
        //else if (level >= 11 && level <= 30)
        //{
        //    basicEnergy.text = "30";
        //    basicDamage.text = "30";
        //    basicCriRate.text = "0";
        //    basicCriDamage.text = "0";

        //    plusEnergy.text = "+ " + (energyR - 30).ToString();
        //    plusDamage.text = "+ " + (damageR - 30).ToString();
        //    plusCriRate.text = "+ " + (criRateR * 100).ToString() + "%";
        //    plusCriDamage.text = "+ " + (criDamageR * 100).ToString() + "%";

        //    energy.text = energyR.ToString();
        //    damage.text = damageR.ToString();
        //    criRate.text = (criRateR * 100).ToString() + "%";
        //    criDamage.text = (criDamageR * 100).ToString() + "%";

        //}
        //else if (level >= 31 && level <= 60)
        //{
        //    basicEnergy.text = "100";
        //    basicDamage.text = "100";
        //    basicCriRate.text = "0";
        //    basicCriDamage.text = "0";

        //    plusEnergy.text = "+ " + (energyR - 100).ToString();
        //    plusDamage.text = "+ " + (damageR - 100).ToString();
        //    plusCriRate.text = "+ " + (criRateR * 100).ToString() + "%";
        //    plusCriDamage.text = "+ " + (criDamageR * 100).ToString() + "%";

        //    energy.text = energyR.ToString();
        //    damage.text = damageR.ToString();
        //    criRate.text = (criRateR * 100).ToString() + "%";
        //    criDamage.text = (criDamageR * 100).ToString() + "%";
        //}
        //else if (level >= 61 && level <= 100)
        //{
        //    basicEnergy.text = "200";
        //    basicDamage.text = "200";
        //    basicCriRate.text = "0";
        //    basicCriDamage.text = "0";

        //    plusEnergy.text = "+ " + (energyR - 200).ToString();
        //    plusDamage.text = "+ " + (damageR - 200).ToString();
        //    plusCriRate.text = "+ " + (criRateR * 100).ToString() + "%";
        //    plusCriDamage.text = "+ " + (criDamageR * 100).ToString() + "%";

        //    energy.text = energyR.ToString();
        //    damage.text = damageR.ToString();
        //    criRate.text = (criRateR * 100).ToString() + "%";
        //    criDamage.text = (criDamageR * 100).ToString() + "%";
        //}
        //else if (level >= 101 && level <= 150)  // 5티어
        //{
        //    basicEnergy.text = "400";
        //    basicDamage.text = "400";
        //    basicCriRate.text = "0";
        //    basicCriDamage.text = "0";

        //    plusEnergy.text = "+ " + (energyR - 400).ToString();
        //    plusDamage.text = "+ " + (damageR - 400).ToString();
        //    plusCriRate.text = "+ " + (criRateR * 100).ToString() + "%";
        //    plusCriDamage.text = "+ " + (criDamageR * 100).ToString() + "%";

        //    energy.text = energyR.ToString();
        //    damage.text = damageR.ToString();
        //    criRate.text = (criRateR * 100).ToString() + "%";
        //    criDamage.text = (criDamageR * 100).ToString() + "%";
        //}

    }
}
