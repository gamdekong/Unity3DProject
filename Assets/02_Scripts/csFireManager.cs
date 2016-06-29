using UnityEngine;
using System.Collections;

public class csFireManager : MonoBehaviour {

    public GameObject missile;
    public GameObject Player;
    public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButtonUp("Jump"))
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
            missileObj.transform.Rotate(Vector3.left, 90);
            missileObj.GetComponent<csMissile>().target = Target;
        }

    }
}
