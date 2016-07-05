using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public AudioClip expSFX;
    public GameObject myParticle;
    public int damage;

    void OnTriggerEnter(Collider col)
    {
        GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCam");

        col.SendMessage("DamageToObject", damage, SendMessageOptions.DontRequireReceiver);

        GameObject particleObj = Instantiate(myParticle) as GameObject;
        particleObj.transform.position = transform.position;

        Destroy(particleObj, 1.8f);

        float distance = Vector3.Distance(col.transform.position, playerCam.transform.position);
        playerCam.SendMessage("PlayCameraShake", distance, SendMessageOptions.DontRequireReceiver);

        AudioManager.Instance().PlaySfx(expSFX);
        Destroy(gameObject);

    }

}
