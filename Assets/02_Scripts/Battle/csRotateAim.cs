using UnityEngine;
using System.Collections;

public class csRotateAim : MonoBehaviour {

    float speed = 40.0f;
    Quaternion rotation;
	// Update is called once per frame
	void Update () {
        float z = transform.rotation.z;
        transform.Rotate(-Vector3.forward, z + speed * Time.deltaTime);
	}
}
