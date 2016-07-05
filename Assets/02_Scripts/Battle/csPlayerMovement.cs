using UnityEngine;
using System.Collections;

public class csPlayerMovement : MonoBehaviour {

    bool canMove = true;
    bool isDead = false;

    // Use this for initialization
    void Start () {
	}

    void Update()
    {
        if (isDead)
            return;
    }

    void playerDead()
    {
        if (!isDead)
            isDead = true;
        else
            return;
    }

    void playerMove()
    {
        if (canMove)
            canMove = false;
        else
            canMove = true;
    }
}
