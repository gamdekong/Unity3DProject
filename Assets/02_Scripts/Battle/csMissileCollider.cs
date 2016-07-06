using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public AudioClip expSFX;
    public GameObject myParticle;
    public int damage;

    void OnTriggerEnter(Collider col)
    {

        // 파괴가능한 타겟인지 확인
        if (col.gameObject.layer == 8)
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

}
