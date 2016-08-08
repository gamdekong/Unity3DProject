using UnityEngine;
using System.Collections;

public class csAsteroidMove : MonoBehaviour {

    GameObject player;
    public bool attackPlayer = false;
    public float speed = 200;
    float delay;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("PlayerModel");
    }
	
	// Update is called once per frame
	void Update () {

        if(transform.childCount < 1)
        {
            Destroy(gameObject);
        }

        if (attackPlayer)
        {
            MoveToPlayer();
        }

    }

    void MoveToPlayer()
    {
        Vector3 Pos;

        if (player == null)
        {
            Destroy(gameObject);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.transform.position);
        float correctionValue = 1.5f;

        Vector3 Dir = transform.position - player.transform.position;
        Vector3 Axis = Vector3.Cross(Dir, transform.forward);

        Quaternion NewRotation = Quaternion.AngleAxis(Time.deltaTime * speed * correctionValue, Axis) * transform.rotation;
        transform.rotation = Quaternion.Lerp(transform.rotation, NewRotation, 250.0f * Time.deltaTime);

        Pos = Vector3.forward * Time.deltaTime * speed;

        transform.Translate(Pos);
    }
}
