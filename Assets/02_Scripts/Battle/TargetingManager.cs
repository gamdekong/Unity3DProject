using UnityEngine;
using System.Collections;

public class TargetingManager : MonoBehaviour {

    public GameObject Aim;
    public GameObject btnFire;
    GameObject AimingTarget;
    GameObject[] targetAsteroids;
    GameObject targetPlanet;

    public bool auto = false;

    public float asteroidAimScaleX = 15;
    public float asteroidAimScaleY = 15;

    public float planetAimScaleX = 30;
    public float planetAimScaleY = 30;

    public float MaxTargetingDistance = 80;
    float planetDis = 0;
    float asteroidDis = 0;

    // Update is called once per frame
    void Update () {
        if (AimingTarget == null)
            btnFire.SetActive(false);
        else
            btnFire.SetActive(true);

        if (auto)
            AutoTargeting();
        else
            TouchTargeting();                   
    }
    // ===============================================================================
    // 오토 타겟팅
    // ===============================================================================
    void AutoTargeting()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject aim = GameObject.FindGameObjectWithTag("Aim");
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        GameObject planet = GameObject.FindGameObjectWithTag("Planet");     

        if (aim)
        {
            if ((aim.transform.position.z < player.transform.position.z) || AimingTarget == null)
            {
                Destroy(aim);
                AimingTarget = null;
            }
        }

        if (targetAsteroids != asteroids)
            targetAsteroids = asteroids;

        if (targetPlanet != planet)
            targetPlanet = planet;

        if (targetAsteroids != null)
        {
            foreach(GameObject asteroid in targetAsteroids)
            {
                asteroidDis = Vector3.Distance(asteroid.transform.position, player.transform.position);

                if (AimingTarget == asteroid)
                    break;
 
                if (asteroid.transform.position.z - 3.0f < player.transform.position.z ||
                    asteroidDis > MaxTargetingDistance)
                    continue;

                if(AimingTarget == null)
                {
                    AimingTarget = asteroid;
                }
                else
                {
                    float aimingTargetDis = Vector3.Distance(AimingTarget.transform.position, player.transform.position);
                    if (asteroidDis < aimingTargetDis)
                    {
                        AimingTarget = asteroid;
                    }
               }
            }
            
            if (targetPlanet)
                planetDis = Vector3.Distance(targetPlanet.transform.position, player.transform.position);

            if (targetPlanet != null && AimingTarget == null)
            {
                if (planetDis < MaxTargetingDistance)
                    AimingTarget = targetPlanet;
            }
        }

        if (AimingTarget != null)
        {
            Vector3 targetPos = AimingTarget.transform.position;
            if (AimingTarget.tag == "Asteroid")
                targetPos.z -= 3.0f;
            else
                targetPos.z -= 15.0f;

            if (GameObject.FindGameObjectWithTag("Aim"))
            {
                GameObject aimObj = GameObject.FindGameObjectWithTag("Aim");

                if (AimingTarget.tag == "Asteroid")
                    aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                else
                    aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);

                GameObject.FindGameObjectWithTag("Aim").transform.position = targetPos;
            }
            else
            {
                GameObject aimObj = Instantiate(Aim, targetPos, transform.rotation) as GameObject;
                if (AimingTarget.tag == "Asteroid")
                    aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                else
                    aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);
            }
            GameObject.Find("FireSystem").GetComponent<csFireManager>().Target = AimingTarget;
        }
    }
    // ===============================================================================
    // 터치 / 마우스 타겟팅
    // ===============================================================================
    void TouchTargeting()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject aim = GameObject.FindGameObjectWithTag("Aim");

        if (aim)
        {
            if ((aim.transform.position.z < player.transform.position.z) || AimingTarget == null)
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
                    float targetDis = Vector3.Distance(hit.transform.position, player.transform.position);
                    Vector3 targetPos = hit.transform.position;

                    if (hit.transform.tag == "Asteroid")
                        targetPos.z -= 3.0f;
                    else
                        targetPos.z -= 15.0f;

                    if (targetPos.z < player.transform.position.z || targetDis > MaxTargetingDistance)
                    {
                        return;
                    }

                    AimingTarget = hit.transform.gameObject;

                    if (GameObject.FindGameObjectWithTag("Aim"))
                    {
                        GameObject aimObj = GameObject.FindGameObjectWithTag("Aim");

                        if (AimingTarget.tag == "Asteroid")
                            aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                        else
                            aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);

                        GameObject.FindGameObjectWithTag("Aim").transform.position = targetPos;
                    }
                    else
                    {
                        GameObject aimObj = Instantiate(Aim, targetPos, transform.rotation) as GameObject;
                        if (AimingTarget.tag == "Asteroid")
                            aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                        else
                            aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);
                    }
                    GameObject.Find("FireSystem").GetComponent<csFireManager>().Target = AimingTarget;
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
                        float targetDis = Vector3.Distance(hit.transform.position, player.transform.position);
                        Vector3 targetPos = hit.transform.position;

                        if (hit.transform.tag == "Asteroid")
                            targetPos.z -= 3.0f;
                        else
                            targetPos.z -= 15.0f;

                        if (targetPos.z < player.transform.position.z || targetDis > MaxTargetingDistance)
                        {
                            return;
                        }

                        AimingTarget = hit.transform.gameObject;

                        if (GameObject.FindGameObjectWithTag("Aim"))
                        {
                            GameObject aimObj = GameObject.FindGameObjectWithTag("Aim");

                            if (AimingTarget.tag == "Asteroid")
                                aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                            else
                                aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);

                            GameObject.FindGameObjectWithTag("Aim").transform.position = targetPos;
                        }
                        else
                        {
                            GameObject aimObj = Instantiate(Aim, targetPos, transform.rotation) as GameObject;
                            if (AimingTarget.tag == "Asteroid")
                                aimObj.transform.localScale = new Vector3(asteroidAimScaleX, asteroidAimScaleY, 1);
                            else
                                aimObj.transform.localScale = new Vector3(planetAimScaleX, planetAimScaleY, 1);
                        }
                        GameObject.Find("FireSystem").GetComponent<csFireManager>().Target = AimingTarget;
                    }
                }
            }
        }
    }
}