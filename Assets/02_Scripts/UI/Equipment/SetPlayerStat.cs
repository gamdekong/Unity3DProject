using UnityEngine;
using System.Collections;

public class SetPlayerStat : MonoBehaviour {

    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    private int energyTmp1;
    private int damageTmp1;
    private float criticalRateTmp1;
    private float criticalDamageTmp1;

    private int energyTmp2;
    private int damageTmp2;
    private float criticalRateTmp2;
    private float criticalDamageTmp2;

    private int energyTmp3;
    private int damageTmp3;
    private float criticalRateTmp3;
    private float criticalDamageTmp3;

    private int basicEnergy;
    private int basicDamage;
    private float basicCriRate;
    private float basicCriDamage;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        
        
        


    }

    public void SetStat()
    {
       

        if (slot1.transform.childCount > 0)
        {
            energyTmp1 = slot1.transform.GetChild(0).GetComponent<Card>().energy;
            damageTmp1 = slot1.transform.GetChild(0).GetComponent<Card>().power;
            criticalRateTmp1 = slot1.transform.GetChild(0).GetComponent<Card>().criticalRate;
            criticalDamageTmp1 = slot1.transform.GetChild(0).GetComponent<Card>().criticalDamage;

            

        }
        else
        {
            energyTmp1 = 0;
            damageTmp1 = 0;
            criticalRateTmp1 = 0;
            criticalDamageTmp1 = 0;
        }

        if (slot2.transform.childCount > 0)
        {
          
            energyTmp2 = slot2.transform.GetChild(0).GetComponent<Card>().energy;
            damageTmp2 = slot2.transform.GetChild(0).GetComponent<Card>().power;
            criticalRateTmp2 = slot2.transform.GetChild(0).GetComponent<Card>().criticalRate;
            criticalDamageTmp2 = slot2.transform.GetChild(0).GetComponent<Card>().criticalDamage;
        }
        else
        {
            energyTmp2 = 0;
            damageTmp2 = 0;
            criticalRateTmp2 = 0;
            criticalDamageTmp2 = 0;
        }

        if (slot3.transform.childCount > 0)
        {
            energyTmp3 = slot3.transform.GetChild(0).GetComponent<Card>().energy;
            damageTmp3 = slot3.transform.GetChild(0).GetComponent<Card>().power;
            criticalRateTmp3 = slot3.transform.GetChild(0).GetComponent<Card>().criticalRate;
            criticalDamageTmp3 = slot3.transform.GetChild(0).GetComponent<Card>().criticalDamage;
        }
        else
        {
            energyTmp3 = 0;
            damageTmp3 = 0;
            criticalRateTmp3 = 0;
            criticalDamageTmp3 = 0;
        }

        //if (DBManager.Instance.GetPlayerTier() == 1)
        //{
            
            DBManager.Instance.SetCardSlotStat( energyTmp1 + energyTmp2 + energyTmp3 , damageTmp1 + damageTmp2 + damageTmp3,
             criticalRateTmp1 +criticalRateTmp2 + criticalRateTmp3, criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);

        basicEnergy = DBManager.Instance.GetPlayerBasicEnergy();
        basicDamage = DBManager.Instance.GetPlayerBasicDamage();
        basicCriRate = DBManager.Instance.GetPlayerBasicCriticalRate();
        basicCriDamage = DBManager.Instance.GetPlayerBasicCriticalDamage();



        DBManager.Instance.SetPlayerStat(basicEnergy + energyTmp1 + energyTmp2 + energyTmp3, basicDamage + damageTmp1 + damageTmp2 + damageTmp3,
            basicCriRate + criticalRateTmp1 + criticalRateTmp2 + criticalRateTmp3, basicCriDamage + criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);



        //}
        //else if (DBManager.Instance.GetPlayerTier() == 2)
        //{
        //    DBManager.Instance.SetPlayerStat(30 + energyTmp1 + energyTmp2 + energyTmp3, 30 + damageTmp1 + damageTmp2 + damageTmp3,
        //     criticalRateTmp1 + criticalRateTmp2 + criticalRateTmp3, criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);
        //}
        //else if (DBManager.Instance.GetPlayerTier() == 3)
        //{
        //    DBManager.Instance.SetPlayerStat(100 + energyTmp1 + energyTmp2 + energyTmp3, 100 + damageTmp1 + damageTmp2 + damageTmp3,
        //     criticalRateTmp1 + criticalRateTmp2 + criticalRateTmp3, criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);
        //}
        //else if (DBManager.Instance.GetPlayerTier() == 4)
        //{
        //    DBManager.Instance.SetPlayerStat(200 + energyTmp1 + energyTmp2 + energyTmp3, 200 + damageTmp1 + damageTmp2 + damageTmp3,
        //     criticalRateTmp1 + criticalRateTmp2 + criticalRateTmp3, criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);
        //}
        //else if (DBManager.Instance.GetPlayerTier() == 5)
        //{
        //    DBManager.Instance.SetPlayerStat(400 + energyTmp1 + energyTmp2 + energyTmp3, 400 + damageTmp1 + damageTmp2 + damageTmp3,
        //     criticalRateTmp1 + criticalRateTmp2 + criticalRateTmp3, criticalDamageTmp1 + criticalDamageTmp2 + criticalDamageTmp3);
        //}
        //else
        //    Debug.Log("error - Tier");




        //기존 플레이어의 기본 능력치
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
    }
}
