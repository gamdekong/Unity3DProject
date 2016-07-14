using UnityEngine;
using System.Collections;

public class csPlayerCollider : MonoBehaviour {

    public GameObject hitEffect;

    void OnTriggerEnter(Collider col)
    {
        // 파괴가능한 타겟인지 확인
        if (col.gameObject.layer == 8)
        {

            GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCam");
            GameObject player = GameObject.Find("Player");

            player.SendMessage("ShowEffect", SendMessageOptions.DontRequireReceiver);
            player.SendMessage("DamageToFuel", 1, SendMessageOptions.DontRequireReceiver);
            playerCam.SendMessage("PlayCameraShake", SendMessageOptions.DontRequireReceiver);
        }
    }

    
}
