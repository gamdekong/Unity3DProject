using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public int Chapter = 0;
    public int Stage = 0;

	// Update is called once per frame
	void Update () {
	
	}

    public void Chap1()
    {
        Chapter = 1;
    }

    public void Chap2()
    {
        Chapter = 2;
    }

    public void Chap3()
    {
        Chapter = 3;
    }

    public void Chap4()
    {
        Chapter = 4;
    }

    public void Chap5()
    {
        Chapter = 5;
    }

    public void Stage1()
    {
        Stage = 1;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Stage2()
    {
        Stage = 2;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Stage3()
    {
        Stage = 3;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Stage4()
    {
        Stage = 4;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Stage5()
    {
        Stage = 5;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Stage6()
    {
        Stage = 6;
        GameObject.Find("StageData").GetComponent<StageData>().SetData(Chapter, Stage);
    }

    public void Back()
    {
        Chapter = 0;
        Stage = 0;
    }
}
