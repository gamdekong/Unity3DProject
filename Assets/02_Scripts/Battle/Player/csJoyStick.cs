using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class csJoyStick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{

    public GameObject joystickPos;
    public GameObject joystickHandle;
    public Vector3 defaultJoysticPos = new Vector3(0, 0, 0);
    public Vector3 defaultHandlePos = new Vector3(0, 0, 0);
    public csPlayerMovement player;
    public GameObject playerModel;

    TargetingManager targetingManager;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<csPlayerMovement>();
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        targetingManager = GameObject.Find("TargetingSystem").GetComponent<TargetingManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetingManager.isDead)
        {
            return;
        }
        else
        {
            joystickPos.transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (targetingManager.isDead)
        {
            return;
        }
        else
        {
            Vector3 oldPos = joystickPos.transform.position;
            Vector3 newPos = eventData.position;
            Vector3 axis = Vector3.Normalize(oldPos - newPos);
            axis *= -1;
            axis.z = 1;
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, 
                Quaternion.FromToRotation(transform.forward, axis), 0.8f * Time.deltaTime);
            player.axis = axis;
            joystickHandle.transform.position = newPos;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (targetingManager.isDead)
        {
            return;
        }
        else
        {
            joystickHandle.transform.localPosition = defaultJoysticPos;
            joystickPos.transform.localPosition = defaultHandlePos;
            StartCoroutine(ToForward());
        }
    }

    IEnumerator ToForward()
    {
        int i = 25;
        while(i != 0)
        {
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation,
                Quaternion.FromToRotation(transform.forward, Vector3.zero), 0.2f);
            yield return new WaitForSeconds(0.02f);
            i--;
        }
        player.axis = Vector3.forward;
        playerModel.transform.rotation = Quaternion.Euler(Vector3.zero);
        yield return true;
    }
}