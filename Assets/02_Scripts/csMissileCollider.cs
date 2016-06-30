using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public int damage;

    void OnTriggerEnter(Collider col)
    {
        col.SendMessage("DamageToObject", damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
