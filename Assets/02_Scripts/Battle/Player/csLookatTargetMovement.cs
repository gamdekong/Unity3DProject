using UnityEngine;
using System.Collections;

public class csLookatTargetMovement : MonoBehaviour {

    public GameObject TargetingManager;
    public GameObject Planet;

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

        if (transform.position.z > thePath[lastPathNum - 1].z)
        {
            if (GameObject.FindGameObjectWithTag("Planet"))
            {
                GameObject planet = GameObject.FindGameObjectWithTag("Planet");
                float dis = Vector3.Distance(transform.position, planet.transform.position);
                Vector3 pos = Vector3.MoveTowards(transform.position, planet.transform.position, speed / 30.0f * Time.deltaTime);
                transform.Translate(pos);
            }
            else
                return;
        }

        distance += speed * Time.deltaTime;
        float perc = distance / pathLength;
        iTween.PutOnPath(gameObject, thePath, perc);
    }

    public void WhileAttacking()
    {
        delay = restoreSpeedDelay;
    }
}
