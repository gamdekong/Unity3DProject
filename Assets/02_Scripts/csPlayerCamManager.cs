using UnityEngine;
using System.Collections;

public class csPlayerCamManager : MonoBehaviour {

    Vector3 myLocalPosition = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        myLocalPosition = transform.localPosition;
    }

    public void PlayCameraShake()
    {
        StartCoroutine(CameraShakeProcess(1.0f, 0.2f));
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
            pos.z = Random.Range(-shakeSense, shakeSense);

            transform.localPosition += pos;

            yield return new WaitForEndOfFrame();
        }
        transform.localPosition = myLocalPosition;
    }
}
