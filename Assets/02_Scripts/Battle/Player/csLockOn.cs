using UnityEngine;
using System.Collections;

public class csLockOn : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8 && col.tag == "Asteroid")
        {
            col.GetComponent<csAsteroidStatus>().LockOn = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.layer == 8 && col.tag == "Asteroid")
        {
            col.GetComponent<csAsteroidStatus>().LockOn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == 8 && col.tag == "Asteroid")
        {
            col.GetComponent<csAsteroidStatus>().LockOn = false;
        }
    }
}
