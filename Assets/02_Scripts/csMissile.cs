using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {

    public GameObject target;
    public AudioClip shotSound;
    public AudioClip explosionSound;

    public float Speed;
    public int damage;
    public float delay = 5;
   
    // Use this for initialization
    void Start () {
        transform.FindChild("missile").GetComponent<csMissileCollider>().damage = damage;
        transform.FindChild("missile").GetComponent<csMissileCollider>().expSFX = explosionSound;
        AudioManager.Instance().PlaySfx(shotSound);
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        MissileControl3();

        if (delay <= 0)
            Destroy(gameObject);	
	}

    void MissileControl3()
    {
        if (!(transform.FindChild("missile")))
            Destroy(gameObject);

        Vector3 Pos;
        if (target == null)
        {
            Pos = Vector3.forward * Time.deltaTime * Speed;
            transform.Translate(Pos);
            return;
        }    

        Vector3 Dir = transform.position - target.transform.position;
        Vector3 Axis = Vector3.Cross(Dir, transform.forward);

        Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * Speed * 10, Axis) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRotation, 50.0f * Time.deltaTime);
        Pos = Vector3.forward * Time.deltaTime * Speed;           

        transform.Translate(Pos);
    } 
}
