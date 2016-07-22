using UnityEngine;
using System.Collections;

public class csFireManager : MonoBehaviour {

    public GameObject missile;
    public GameObject Player;
    public GameObject MissilePositionLeft;
    public GameObject MissilePositionRight;
    public GameObject Target;

    public int dmg = 1;
    public float crit = 50.0f;
    public float critDmg = 2.0f;
    public bool isDead = false;
    bool trail = false;

    // Use this for initialization
    void Start () {
	
	}
    public void FireMissile()
    {
        if (isDead)
            return;

        // 타겟이 있을때만 발사
        if (Target == null)
            return;

        // 미사일 생성
        GameObject missileObj = Instantiate(missile) as GameObject;

        missileObj.GetComponent<csMissile>().damage = dmg;
        missileObj.GetComponent<csMissile>().criticalRate = crit;
        missileObj.GetComponent<csMissile>().criticalDamage = critDmg;

        if(trail)
        {
            missileObj.GetComponent<csMissile>().trailSwtich = true;
            trail = false;
        }
        else
        {
            missileObj.GetComponent<csMissile>().trailSwtich = false;
            trail = true;
        }

        missileObj.transform.parent = Player.transform;
        int posRange = Random.Range(0, 4);
        if(posRange > 1)
        {
            missileObj.transform.position = MissilePositionLeft.transform.position;
            missileObj.GetComponent<csMissile>().isRight = false;
            missileObj.transform.rotation = MissilePositionLeft.transform.rotation;
        }
        else
        {
            missileObj.transform.position = MissilePositionRight.transform.position;
            missileObj.GetComponent<csMissile>().isRight = true;
            missileObj.transform.rotation = MissilePositionRight.transform.rotation;
        }

        missileObj.GetComponent<csMissile>().target = Target;
        //missileObj.transform.localScale = new Vector3(8, 8, 8);
        missileObj.GetComponent<csMissile>().MissileControl3();

        // 플레이어 이속 저하
        Player.GetComponent<csPlayerMovement>().WhileAttacking();
    }
    // Update is called once per frame
    void Update () {

    }
}
