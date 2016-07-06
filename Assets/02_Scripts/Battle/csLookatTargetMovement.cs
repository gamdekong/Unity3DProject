using UnityEngine;
using System.Collections;

public class csLookatTargetMovement : MonoBehaviour {

    public float maxSpeed;
    public float accelerateSpeed;
    public float breakingSpeed;
    public float restoreSpeedDelay;
    public string pathName;
    public bool whileAttack = false;
    float delay;
    float speed;
    float distance;
    public Vector3[] thePath;
    public float pathLength;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
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
