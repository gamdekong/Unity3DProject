using UnityEngine;
using System.Collections;

public class csPlayerCollider : MonoBehaviour {

    public GameObject hitEffect;
    public bool hit = false;

    void OnTriggerEnter(Collider col)
    {
        // 파괴가능한 타겟인지 확인
        if (col.gameObject.layer == 8)
        {

            GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCam");
            GameObject player = GameObject.Find("Player");

            if (player.GetComponent<csPlayerStatus>().fuelBar.GetComponent<csShowFuel>().fuelValue > 0 && hit == false)
            {
                player.SendMessage("ShowEffect", SendMessageOptions.DontRequireReceiver);
                player.SendMessage("DamageToFuel", SendMessageOptions.DontRequireReceiver);
                playerCam.SendMessage("PlayCameraShake", SendMessageOptions.DontRequireReceiver);
            }

            if (player.GetComponent<csPlayerStatus>().fuelBar.GetComponent<csShowFuel>().fuelValue <= 0)
                hit = true;
        }
    }

    
}
