using UnityEngine;
using System.Collections;

public class csFireManager : MonoBehaviour {

    public GameObject missile;
    public GameObject Player;
    public GameObject Target;

    public bool isDead = false;

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
        Vector3 missilePos = Player.transform.position;
        Quaternion missileAng = Player.transform.rotation;
        missileAng.x += 90.0f;
        missileObj.transform.rotation = missileAng;
        int range = Random.Range(0, 4);
        switch (range)
        {
            case 0:
                missilePos.y += Random.Range(0, 1.0f);
                missileObj.transform.Rotate(Vector3.down, Random.Range(80, 120));
                break;
            case 1:
                missilePos.y += Random.Range(0, 1.0f);
                missileObj.transform.Rotate(Vector3.right, Random.Range(60, 80));
                break;
            case 2:
                missileObj.transform.Rotate(new Vector3(1,1,0) , Random.Range(80, 120));
                break;
            case 3:
                missileObj.transform.Rotate(new Vector3(-1,-1,0), Random.Range(80, 120));
                break;
        }
        missileObj.transform.position = missilePos;
        missileObj.GetComponent<csMissile>().target = Target;

        // 플레이어 이속 저하
        Player.GetComponent<csPlayerMovement>().WhileAttacking();
    }
    // Update is called once per frame
    void Update () {

    }
}
