﻿using UnityEngine;
using System.Collections;

public class csPlayerMovement : MonoBehaviour {

    public GameObject lookatTarget;
    public float maxSpeed = 20.0f;
    public float accelerateSpeed = 2.0f;
    public float breakingSpeed = 1.0f;
    public float restoreSpeedDelay = 2.0f;
    public string pathName;
    public bool whileAttack = false;
    float delay;
    float speed;
    float distance;
    Vector3[] thePath;
    int lastPathNum;
    float pathLength;
    csLookatTargetMovement target;

    // Use this for initialization
    void Start () {
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

        delay = 1.5f;
    }
	
	// Update is called once per frame
	void Update () {
        playerRotate();
        playerMove();
    }

    void playerMove()
    {
        if (transform.position.z > thePath[lastPathNum-1].z)
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

    void playerRotate()
    {
        if (transform.position.z < thePath[lastPathNum-1].z)
            transform.LookAt(lookatTarget.transform.position);
    }

    public void WhileAttacking()
    {
        delay = restoreSpeedDelay;
        target.WhileAttacking();
    }
}