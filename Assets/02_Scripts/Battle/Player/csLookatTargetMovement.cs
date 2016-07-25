using UnityEngine;
using System.Collections;

public class csLookatTargetMovement : MonoBehaviour {

    public GameObject TargetingManager;

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
    public int lastPathNum;

    // Use this for initialization
    void Start()
    {
        TargetingManager = GameObject.Find("TargetingSystem");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (transform.position.z > thePath[lastPathNum-1].z)
            return;

        if (TargetingManager.GetComponent<TargetingManager>().isDead)
            return;

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
