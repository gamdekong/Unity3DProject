using UnityEngine;
using System.Collections;

public class csEngine : MonoBehaviour {

    public GameObject player;

    Vector3 defaultScale;
    float playerSpeed;
    float controlValue = 1;
    float angleValue;

    bool cross = false;
	// Use this for initialization
	void Start () {
       player = GameObject.Find("Player");
        defaultScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	if(!player)
        {
            Destroy(gameObject);
        }
    else
        {
            playerSpeed = player.GetComponent<csPlayerMovement>().GetSpeed();
            ActiveEngine();
        }
	}

    void ActiveEngine()
    {
        angleValue += 30.0f * Time.deltaTime;
        transform.localRotation = Quaternion.AngleAxis(angleValue, Vector3.forward);

        if (transform.localScale.x >= defaultScale.x)
        {
            cross = true;
        }
        else if (transform.localScale.x <= (defaultScale.x - 0.2f))
        {
            cross = false;
        }

        if (cross)
        {
            Vector3 scale = transform.localScale;
            scale.x -= controlValue * Time.deltaTime;
            scale.y -= controlValue * Time.deltaTime;
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x += controlValue * Time.deltaTime;
            scale.y += controlValue * Time.deltaTime;
            transform.localScale = scale;
        }

        if (playerSpeed > player.GetComponent<csPlayerMovement>().breakingSpeed)
        {
            if (transform.localScale.z < defaultScale.z + 0.7f)
            {
                Vector3 scale = transform.localScale;
                scale.z += controlValue * Time.deltaTime;
                transform.localScale = scale;
            }
        }
        else
        {
            if(transform.localScale.z > defaultScale.z)
            {
                Vector3 scale = transform.localScale;
                scale.z -= controlValue * Time.deltaTime;
                transform.localScale = scale;
            }
        }
    }
}