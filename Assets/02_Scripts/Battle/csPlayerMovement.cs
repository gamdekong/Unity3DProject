using UnityEngine;
using System.Collections;

public class csPlayerMovement : MonoBehaviour {

    public float maxSpeed = 20.0f;
    public float accelerateSpeed = 2.0f;
    public float breakingSpeed = 1.0f;
    public float restoreSpeedDelay = 2.0f;
    public bool whileAttack = false;
    float delay;
    float speed;
    float distance;
    Vector3[] thePath;
    float pathLength;

	// Use this for initialization
	void Start () {
        thePath = iTweenPath.GetPath("Path1");
        pathLength = iTween.PathLength(thePath);
    }
	
	// Update is called once per frame
	void Update () {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            whileAttack = true;
        }

        if (delay < 0)
            whileAttack = false;

        if (whileAttack)
            speed = breakingSpeed;
        else if (speed < maxSpeed)
            speed += accelerateSpeed * Time.deltaTime;

        if (speed > maxSpeed)
            speed = maxSpeed;
        
        distance += speed * Time.deltaTime;
        float perc = distance / pathLength;
        iTween.PutOnPath(gameObject, thePath, perc);
    }

    public void WhileAttacking()
    {
        delay = restoreSpeedDelay;
    }
}