using UnityEngine;
using System.Collections;

public class csMissileCollider : MonoBehaviour {

    public AudioClip expSFX;
    public GameObject nomalExp;
    public GameObject CritExp;

    public int damage;
    public float criticalRate;
    public float criticalDamage;

    bool isCrit = false;

    void OnTriggerEnter(Collider col)
    {

        // 파괴가능한 타겟인지 확인
        if (col.gameObject.layer == 8)
        {

            GameObject particleObj;
            
            int tmp = (int)(criticalRate * 100);
            int check = Random.Range(0, 10000);
            if (check <= tmp)
            {
                isCrit = true;
                damage = (int)(damage * criticalDamage);
            }
            else
            {
                isCrit = false;
            }

            GameObject playerCam = GameObject.FindGameObjectWithTag("PlayerCam");

            col.SendMessage("DamageToObject", damage, SendMessageOptions.DontRequireReceiver);

            if (isCrit)
            {
                particleObj = Instantiate(CritExp) as GameObject;
                particleObj.transform.position = transform.position;

                Destroy(particleObj, 2.0f);
            }
            else
            {
                particleObj = Instantiate(nomalExp) as GameObject;
                particleObj.transform.position = transform.position;

                Destroy(particleObj, 1.8f);
            }

            //AudioManager.Instance().PlaySfx(expSFX);
            Destroy(gameObject);
        }
    }

}
