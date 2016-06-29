using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {

    public GameObject target;
    public float Speed;
    float delay = 0;
   
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        delay = delay + Time.deltaTime;
        MissileControl3();

        if (delay > 10)
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
