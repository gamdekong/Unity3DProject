using UnityEngine;
using System.Collections;

public class csWorldMapSceneController : MonoBehaviour {

    private GameObject MainUI;
    private GameObject Chapter1;
    private GameObject Chapter2;
    private GameObject Chapter3;
    private GameObject Chapter4;
    private GameObject Chapter5;

    private GameObject ChapterLock1;
    private GameObject ChapterLock2;
    private GameObject ChapterLock3;
    private GameObject ChapterLock4;
    private GameObject ChapterLock5;

    public bool VisibleChapter1;
    public bool VisibleChapter2;
    public bool VisibleChapter3;
    public bool VisibleChapter4;
    public bool VisibleChapter5;

    public bool VisibleChapterLock1;
    public bool VisibleChapterLock2;
    public bool VisibleChapterLock3;
    public bool VisibleChapterLock4;
    public bool VisibleChapterLock5;



    // Use this for initialization
    void Start () {
        MainUI = GameObject.Find("UI Root");

        Chapter1 = MainUI.transform.FindChild("Chapter1").gameObject;
        Chapter2 = MainUI.transform.FindChild("Chapter2").gameObject;
        Chapter3 = MainUI.transform.FindChild("Chapter3").gameObject;
        Chapter4 = MainUI.transform.FindChild("Chapter4").gameObject;
        Chapter5 = MainUI.transform.FindChild("Chapter5").gameObject;

        ChapterLock1 = MainUI.transform.FindChild("Chapter1").FindChild("RockBG").gameObject;
        ChapterLock2 = MainUI.transform.FindChild("Chapter2").FindChild("RockBG").gameObject;
        ChapterLock3 = MainUI.transform.FindChild("Chapter3").FindChild("RockBG").gameObject;
        ChapterLock4 = MainUI.transform.FindChild("Chapter4").FindChild("RockBG").gameObject;
        ChapterLock5 = MainUI.transform.FindChild("Chapter5").FindChild("RockBG").gameObject;

        Chapter1.SetActive(VisibleChapter1);
        Chapter2.SetActive(VisibleChapter2);
        Chapter3.SetActive(VisibleChapter3);
        Chapter4.SetActive(VisibleChapter4);
        Chapter5.SetActive(VisibleChapter5);

        ChapterLock1.SetActive(VisibleChapterLock1);
        ChapterLock2.SetActive(VisibleChapterLock2);
        ChapterLock3.SetActive(VisibleChapterLock3);
        ChapterLock4.SetActive(VisibleChapterLock4);
        ChapterLock5.SetActive(VisibleChapterLock5);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
