using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public AudioClip expSFX;
    public int damage;

    void OnTriggerEnter(Collider col)
    {
        GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCam");

        col.SendMessage("DamageToObject", damage, SendMessageOptions.DontRequireReceiver);

        float distance = Vector3.Distance(col.transform.position, playerCam.transform.position);
        playerCam.SendMessage("PlayCameraShake", distance, SendMessageOptions.DontRequireReceiver);

        AudioManager.Instance().PlaySfx(expSFX);
        Destroy(gameObject);

    }
}
