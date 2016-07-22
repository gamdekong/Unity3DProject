using UnityEngine;
using System.Collections;

public class csMissile : MonoBehaviour {

    public GameObject player;
    public GameObject target;
    public AudioClip shotSound;
    public AudioClip explosionSound;
    public bool isRight;

    public float Speed;
    public int damage;
    public float criticalRate;
    public float criticalDamage;
    public float delay = 5;
    float propelTime = 0.01f;
    float MaxPropelTime = 0.15f;
    float rotatePropelTime;
    float MaxSpeed;

    public bool trailSwtich = false;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");

        transform.FindChild("missile").GetComponent<csMissileCollider>().damage = damage;
        transform.FindChild("missile").GetComponent<csMissileCollider>().criticalRate = criticalRate;
        transform.FindChild("missile").GetComponent<csMissileCollider>().criticalDamage = criticalDamage;
        transform.FindChild("missile").GetComponent<csMissileCollider>().expSFX = explosionSound;
        AudioManager.Instance().PlaySfx(shotSound);

        MaxSpeed = Speed;
        Speed = Speed / 2;
        rotatePropelTime = MaxPropelTime;
        
        if(trailSwtich)
        {
            transform.FindChild("missile").GetComponent<TrailRenderer>().enabled = false;
            transform.FindChild("Trail").GetComponent<TrailRenderer>().enabled = true;
        }
        else
        {
            transform.FindChild("missile").GetComponent<TrailRenderer>().enabled = true;
            transform.FindChild("Trail").GetComponent<TrailRenderer>().enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;
        MissileControl3();

        if (delay <= 0)
            Destroy(gameObject);
	}

    public void MissileControl3()
    {
        if (!(transform.FindChild("missile")))
        {
            Destroy(gameObject);
            return;
        }

        Vector3 Pos;
        if (target == null)
        {
            Pos = Vector3.forward * Time.deltaTime * MaxSpeed;
            transform.Translate(Pos);
            return;
        }

        if (propelTime > 0)
        {
            propelTime -= Time.deltaTime;
        }
        else
        {
            propelTime = 0;
            if (Speed > MaxSpeed)
            {
                Speed = MaxSpeed;
            }
            else
            {
                if(rotatePropelTime == MaxPropelTime)
                {
                    if (isRight)
                    {
                        transform.Rotate(Vector3.up, Random.Range(20, 40));
                        transform.Rotate(Vector3.right, Random.Range(10, 30));
                    }
                    else
                    {
                        transform.Rotate(Vector3.up, Random.Range(-20, -40));
                        transform.Rotate(Vector3.right, Random.Range(10, 30));
                    }
                }

                if(rotatePropelTime > 0)
                {
                    rotatePropelTime -= Time.deltaTime;
                }
                else
                {
                    if(transform.IsChildOf(player.transform))
                    {
                        transform.parent = null;
                    }

                    rotatePropelTime = 0;

                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    float correctionValue = 1.5f;

                    if (distance < 100)
                    {
                        correctionValue = 3.0f;
                        Speed = MaxSpeed / 3;
                    }
                    else
                        Speed += 60.0f;

                    Vector3 Dir = transform.position - target.transform.position;
                    Vector3 Axis = Vector3.Cross(Dir, transform.forward);

                    Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * Speed * correctionValue, Axis) * transform.rotation;
                    transform.rotation = Quaternion.Lerp(transform.rotation, NewRotation, 60.0f * Time.deltaTime);
                }
            }
        }

        Pos = Vector3.forward * Time.deltaTime * Speed;           

        transform.Translate(Pos);
    } 
}
