using UnityEngine;
using System.Collections;

public class csPlayerCamManager : MonoBehaviour {

    public GameObject player;
    public GameObject target;
    public GameObject lookatPos;
    public GameObject playerModel;
    public float followSpeed = 5.0f;
    public float rotateSpeed = 5.0f;

    Vector3 myLocalPosition;
    Quaternion myLocalRotation;

    float playerMaxSpeed;
    float playerBSpeed;

    // Use this for initialization
    void Start()
    {
        myLocalPosition = transform.localPosition;
        myLocalRotation = transform.localRotation;

        playerMaxSpeed = player.GetComponent<csPlayerMovement>().maxSpeed;
        playerBSpeed = player.GetComponent<csPlayerMovement>().breakingSpeed;
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
    }

    void Update()
    {
        Follow();
        CamMove();
    }

    void Follow()
    {
        if (GameObject.Find("TargetingSystem").GetComponent<TargetingManager>().IsHaveTarget())
            target = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>().GetTarget();
        else
            target = null;

        if (target != null && player.GetComponent<csPlayerMovement>().whileAttack)
        {
            lookatPos.transform.LookAt(target.transform);
        }
        else
        {
            lookatPos.transform.localRotation = playerModel.transform.localRotation;
        }
        transform.localRotation = Quaternion.Lerp(transform.localRotation, lookatPos.transform.localRotation, 0.8f * Time.deltaTime);
    }

    void CamMove()
    {
        float speed = player.GetComponent<csPlayerMovement>().GetSpeed();
        Vector3 localPos = transform.localPosition;

        if(speed > playerBSpeed && localPos.z > -1.5f)
        {
            localPos.z -= 0.5f * Time.deltaTime;
            if (localPos.z < -2.0f)
                localPos.z = -2.0f;
            transform.localPosition = localPos;
        }
        else if(speed != playerMaxSpeed)
        {
            localPos.z += 0.5f * Time.deltaTime;
            if (localPos.z > 0)
                localPos.z = 0;
            transform.localPosition = localPos;
        }

    }

    public void PlayCameraShake()
    {
        StartCoroutine(CameraShakeProcess(0.25f, 0.16f));
    }

    public void AsteroidPlayCameraShake()
    {
        StartCoroutine(CameraShakeProcess(0.25f, 0.08f));
    }

    public void PlanetPlayCameraShake()
    {
        StartCoroutine(CameraShakeProcess(1.0f, 0.2f));
    }

    IEnumerator CameraShakeProcess(float shakeTime, float shakeSense)
    {
        float deltaTime = 0.0f;
        while (deltaTime < shakeTime)
        {
            deltaTime += Time.deltaTime;
            transform.localPosition = myLocalPosition;

            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(-shakeSense, shakeSense);
            pos.y = Random.Range(-shakeSense, shakeSense);
            //pos.z = Random.Range(-shakeSense, shakeSense);

            transform.localPosition += pos;

            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = myLocalPosition;
    }
}
