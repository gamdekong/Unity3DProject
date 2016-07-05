using UnityEngine;
using System.Collections;

public class csMainSceneController : MonoBehaviour {


    //왼쪽 오른쪽 스프라이트

    private GameObject MainUI;
    private GameObject RightPopup;
    private GameObject LeftPopup;
    private GameObject CharacterPopup;


    // Use this for initialization
    void Awake()
    {
        MainUI = GameObject.Find("UI Root");
        RightPopup = MainUI.transform.FindChild("RightPopup").gameObject;
        LeftPopup = MainUI.transform.FindChild("LeftPopup").gameObject;
        CharacterPopup = MainUI.transform.FindChild("CharacterPopup").gameObject;

        RightPopup.SetActive(false);
        LeftPopup.SetActive(false);
        CharacterPopup.SetActive(false);

    }
    public void ActiveCharacter()
    {
        CharacterPopup.SetActive(true);

    }
    public void ActiveRight()
    {
        RightPopup.SetActive(true);

    }

    public void ActiveLeft()
    {
        LeftPopup.SetActive(true);
    }
    public void DeActiveRight()
    {
        RightPopup.SetActive(false);
    }


    public void DeActiveCharacter()
    {
        CharacterPopup.SetActive(false);
    }

    public void DeActiveLeft()
    {
        LeftPopup.SetActive(false);
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update () {
	
	}
}
