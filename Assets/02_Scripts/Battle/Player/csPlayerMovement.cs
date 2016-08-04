using UnityEngine;
using System.Collections;

public class csPlayerMovement : MonoBehaviour {

    public GameObject lookatTarget;
    public GameObject wrapEffect;
    public GameObject[] engines;
    public GameObject playerModel;
    public Vector3 respawnPos;
    public Quaternion respawnRot;
    public Vector3 LastPos;
    public Vector3 axis = Vector3.forward;
    Vector3 startPoint;
    
    public float maxSpeed = 20.0f;
    public float accelerateSpeed = 2.0f;
    public float swtichSpeed = 2.0f;
    public float breakingSpeed = 1.0f;
    public float restoreSpeedDelay = 2.0f;
    public string pathName;
    public bool whileAttack = false;
    public bool fuelEmpty = false;

    float delay;
    float speed;
    float distance;
    Vector3[] thePath;
    int lastPathNum;
    float pathLength;
    csLookatTargetMovement target;
    float firstDelay = 0.5f;    

    // Use this for initialization
    void Start () {
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        pathName = GameObject.Find("StageData").GetComponent<StageData>().GetPathName();

        thePath = iTweenPath.GetPath(pathName);
        lastPathNum = thePath.Length;
        pathLength = iTween.PathLength(thePath);
        target = lookatTarget.GetComponent<csLookatTargetMovement>();

        target.maxSpeed = maxSpeed;
        target.accelerateSpeed = accelerateSpeed;
        target.breakingSpeed = breakingSpeed;
        target.restoreSpeedDelay = restoreSpeedDelay;
        target.pathName = pathName;
        target.pathLength = pathLength;
        target.thePath = thePath;
        target.whileAttack = whileAttack;
        target.lastPathNum = lastPathNum;

        LastPos = thePath[lastPathNum - 1];

        delay = 1.5f;

        wrapEffect.SetActive(false);

        startPoint = Vector3.zero;

        engines = GameObject.FindGameObjectsWithTag("Engine");
    }
	
	// Update is called once per frame
	void Update () {
        playerRotate();
        if (firstDelay > 0)
        {
            firstDelay -= Time.deltaTime;
        }
        else
        {
            firstDelay = 0;
            playerMove();
            SetWarpEffect();
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    void playerMove()
    {
        // 엔진부 on/off
        if (speed <= 0)
        {
            foreach (GameObject engine in engines)
            {
                engine.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject engine in engines)
            {
                engine.SetActive(true);
            }
        }
        // 귀환
        if (fuelEmpty)
        {

            wrapEffect.SetActive(false);
            speed = maxSpeed / 10;

            Vector3 Dir = transform.position - startPoint;
            Vector3 Axis = Vector3.Cross(Dir, transform.forward);

            Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * 50.0f * 15.0f, Axis) * transform.rotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, NewRotation, 10.0f * Time.deltaTime);
            Vector3 Pos = Vector3.forward * Time.deltaTime * speed;

            transform.Translate(Pos);

            return;
        }
        // 공격후 재 점화시간
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            whileAttack = true;
        }
        if (delay < 0)
            whileAttack = false;
        // 가속 및 감속
        //if (whileAttack)
        //{
        //    if (speed > breakingSpeed)
        //        speed -= accelerateSpeed * Time.deltaTime;
        //    else
        //        speed = breakingSpeed;
        //}
        //else if (speed < maxSpeed)
            speed += accelerateSpeed * Time.deltaTime;
        // 최고 속력 제한
        if (speed > maxSpeed)
            speed = maxSpeed;
        // 행성 일정거리 접근 시 속도 제한
        if (GameObject.FindGameObjectWithTag("Planet"))
        {
            GameObject planet = GameObject.FindGameObjectWithTag("Planet");
            float dis = Vector3.Distance(transform.position, planet.transform.position);

            if (dis > 300)
            {
                transform.Translate(playerModel.transform.forward * speed / 5.0f * Time.deltaTime);
            }
            else if (dis < 300 && dis > 150)
            {
                transform.Translate(playerModel.transform.forward * speed / 10.0f * Time.deltaTime);
            }
            else if (dis > 150 && dis > 100)
            {
                transform.Translate(playerModel.transform.forward * speed / 20.0f * Time.deltaTime);
            }
            else
            {
                transform.Translate(playerModel.transform.forward * speed / 60.0f * Time.deltaTime);
            }
        }
        else
        {
            // 행성이 없을시 전진
            transform.Translate(playerModel.transform.forward * speed * Time.deltaTime);
        }

        //distance += speed * Time.deltaTime;

        //float perc = distance / pathLength;
        //iTween.PutOnPath(gameObject, thePath, perc);
    }

    void SetWarpEffect()
    {
        if(speed > breakingSpeed)
        {
            wrapEffect.SetActive(true);
            Vector3 newPos = wrapEffect.transform.localPosition;
            newPos.z = 5.0f;
            wrapEffect.transform.localPosition = newPos;
        }
        else
        {
            wrapEffect.SetActive(false);
        }
    }

    void playerRotate()
    {
        //if (fuelEmpty)
        //    return;

        //if (transform.position.z < LastPos.z)
        //    transform.LookAt(lookatTarget.transform.position);
        //else if (GameObject.FindGameObjectWithTag("Planet"))
        //    transform.LookAt(GameObject.FindGameObjectWithTag("Planet").transform.position);
        //else
        //    return;
    }

    public void WhileAttacking()
    {
        delay = restoreSpeedDelay;
        target.WhileAttacking();
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}