using UnityEngine;
using System.Collections;

public class csPlayerMovement : MonoBehaviour {

	public float forwardSpeed = 10.0f;
    public float sideSpeed = 7.0f;

    private float speed;

    Vector3 moveDir;
    float dirX = 0;     // check side direction

    bool canMove = true;
    bool isDead = false;

    // Use this for initialization
    void Start () {
        speed = forwardSpeed;
	}

    void Update()
    {
        if (isDead)
            return;

        if (GameObject.FindGameObjectWithTag("Planet") != null && GameObject.FindGameObjectWithTag("Planet").transform.position.z - transform.position.z < 20.0f)
            speed = 0;
        else
            speed = forwardSpeed;


        if (canMove)
        {
            dirX = 0; // -1 is left, 1 is right
            
            moveDir = new Vector3(dirX * sideSpeed, 0, speed);
            moveDir = transform.TransformDirection(moveDir);

            GetComponent<CharacterController>().Move(moveDir * Time.deltaTime);
        }

    }

}
