using UnityEngine;
using System.Collections;

public class csPlayerCamManager : MonoBehaviour {

    Vector3 myLocalPosition = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        myLocalPosition = transform.localPosition;
    }

    public void PlayCameraShake(float distance)
    {
        //Debug.Log(distance);
        if (distance > 30)
            return;
        else if(distance > 25)
            StartCoroutine(CameraShakeProcess(0.1f, 0.02f));
        else if (distance > 20)
            StartCoroutine(CameraShakeProcess(0.15f, 0.04f));
        else if (distance > 15)
            StartCoroutine(CameraShakeProcess(0.2f, 0.08f));
        else
            StartCoroutine(CameraShakeProcess(0.25f, 0.16f));
    }

    IEnumerator CameraShakeProcess(float shakeTime, float shakeSense)
    {
        float deltaTime = 0.0f;
        while (deltaTime < shakeTime)
        {
            deltaTime += Time.deltaTime;
            transform.localPosition = myLocalPosition;

            Vector3 pos = Vector3.zero;
            pos.x = Random.Range(-shakeSense, shakeSense);
            pos.y = Random.Range(-shakeSense, shakeSense);
            //pos.z = Random.Range(-shakeSense, shakeSense);

            transform.localPosition += pos;

            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = myLocalPosition;
    }
}
