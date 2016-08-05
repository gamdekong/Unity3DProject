using UnityEngine;
using System.Collections;

public class csAim : MonoBehaviour {

    public GameObject player;
    TargetingManager targetingManager;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        targetingManager = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);

        if (targetingManager.AimingTarget)
        {
            float dis = Vector3.Distance(player.transform.position, transform.position);
            Vector3 scale = transform.localScale;

            if (targetingManager.AimingTarget.tag == "Asteroid")
            {
                if (dis < 400 && dis > 350)
                {
                    scale.x = 60;
                    scale.y = 60;
                    transform.localScale = scale;
                }
                else if (dis < 350 && dis > 250)
                {
                    scale.x = 45;
                    scale.y = 45;
                    transform.localScale = scale;
                }
                else if (dis < 250 && dis > 0)
                {
                    scale.x = 30;
                    scale.y = 30;
                    transform.localScale = scale;
                }
            }
            else if (targetingManager.AimingTarget.tag == "Planet")
            {
                if (dis < 600 && dis > 400)
                {
                    scale.x = 160;
                    scale.y = 160;
                    transform.localScale = scale;
                }
                else if (dis < 400 && dis > 300)
                {
                    scale.x = 140;
                    scale.y = 140;
                    transform.localScale = scale;
                }
                else if (dis < 300 && dis > 0)
                {
                    scale.x = 100;
                    scale.y = 100;
                    transform.localScale = scale;
                }
            }
        }
    }
}
