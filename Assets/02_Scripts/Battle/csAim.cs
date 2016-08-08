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
                    scale.x = 8;
                    scale.y = 8;
                    transform.localScale = scale;
                }
                else if (dis < 350 && dis > 250)
                {
                    scale.x = 6;
                    scale.y = 6;
                    transform.localScale = scale;
                }
                else if (dis < 250 && dis > 0)
                {
                    scale.x = 4;
                    scale.y = 4;
                    transform.localScale = scale;
                }
            }
            else if (targetingManager.AimingTarget.tag == "Planet")
            {
                if (dis < 600 && dis > 400)
                {
                    scale.x = 10;
                    scale.y = 10;
                    transform.localScale = scale;
                }
                else if (dis < 400 && dis > 300)
                {
                    scale.x = 8;
                    scale.y = 8;
                    transform.localScale = scale;
                }
                else if (dis < 300 && dis > 0)
                {
                    scale.x = 6;
                    scale.y = 6;
                    transform.localScale = scale;
                }
            }
        }
    }
}
