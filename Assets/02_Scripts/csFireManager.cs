using UnityEngine;
using System.Collections;

public class csFireManager : MonoBehaviour {

    public GameObject missile;
    public GameObject Player;
    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
    public void FireMissile()
    {
        if (Target == null)
            return;

        GameObject missileObj = Instantiate(missile) as GameObject;
        Vector3 missilePos = Player.transform.position;
        Quaternion missileAng = Player.transform.rotation;
        missilePos.x += Random.Range(-5.0f, 5.0f);
        missileAng.x += 90.0f;
        missileObj.transform.position = missilePos;
        missileObj.transform.rotation = missileAng;

        int range = Random.Range(0, 3);
        switch (range)
        {
            case 0:
                missileObj.transform.Rotate(Vector3.right, Random.Range(60, 90));
                break;
            case 1:
                missileObj.transform.Rotate(Vector3.left, Random.Range(60, 90));
                break;
            case 2:
                missileObj.transform.Rotate(Vector3.up, Random.Range(60, 90));
                break;
            case 3:
                missileObj.transform.Rotate(Vector3.down, Random.Range(60, 90));
                break;
        }
        missileObj.GetComponent<csMissile>().target = Target;
    }
    // Update is called once per frame
    void Update () {



    }
}
