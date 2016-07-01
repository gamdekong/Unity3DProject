using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public AudioClip expSFX;
    public int damage;

    void OnTriggerEnter(Collider col)
    {
        col.SendMessage("DamageToObject", damage, SendMessageOptions.DontRequireReceiver);
        GameObject.FindGameObjectWithTag("PlayerCam").SendMessage("PlayCameraShake", SendMessageOptions.DontRequireReceiver);
        AudioManager.Instance().PlaySfx(expSFX);
        Destroy(gameObject);
    }
}
