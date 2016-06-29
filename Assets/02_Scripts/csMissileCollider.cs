using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
        Destroy(gameObject);
    }
}
