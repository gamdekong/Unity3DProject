using UnityEngine;
using System.Collections;

public class TargetingManager : MonoBehaviour {

    public GameObject Aim;

	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("Aim"))
        {
            GameObject aim = GameObject.FindGameObjectWithTag("Aim");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (aim.transform.position.z < player.transform.position.z)
            {
                Destroy(aim);
            }
        }

            if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.layer == 8)
                {
                    //Debug.Log("It's Target");
                    Vector3 targetPos = hit.transform.position;
                    targetPos.z -= 20.0f;
                    if (GameObject.FindGameObjectWithTag("Aim"))
                    {
                        GameObject.FindGameObjectWithTag("Aim").transform.position = targetPos;
                    }
                    else
                    {
                        Instantiate(Aim, targetPos, transform.rotation);
                    }
                }
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.layer == 8)
                    {
                        //Debug.Log("It's Target");
                    }
                }
            }
        }

        
    }
}
