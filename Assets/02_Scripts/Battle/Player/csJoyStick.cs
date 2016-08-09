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

    Vector3 axis = Vector3.zero;
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
        if(axis != Vector3.zero)
        {
            player.axis = axis;
        }
        else
        {
            return;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (targetingManager.isDead)
        {
            return;
        }
        else
        {
            joystickHandle.SetActive(true);
            joystickPos.SetActive(true);
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
            axis = Vector3.Normalize(oldPos - newPos);
            axis *= -1;
            axis.z = 1;
            playerModel.transform.rotation = Quaternion.Lerp(playerModel.transform.rotation, 
                Quaternion.FromToRotation(transform.forward, axis), 0.8f * Time.deltaTime);
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
            joystickHandle.SetActive(false);
            joystickPos.SetActive(false);
            joystickHandle.transform.localPosition = defaultJoysticPos;
            joystickPos.transform.localPosition = defaultHandlePos;
            axis = Vector3.zero;
        }
    }
}