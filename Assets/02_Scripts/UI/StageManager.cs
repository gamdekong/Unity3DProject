using UnityEngine;
using System.Collections;

public class StageManager : MonoBehaviour
{
    public int Chapter = 0;
    public int Stage = 0;
    public int Diffculty = 0;

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
    }

    public void Stage2()
    {
        Stage = 2;
    }

    public void Stage3()
    {
        Stage = 3;
    }

    public void Stage4()
    {
        Stage = 4;
    }

    public void Stage5()
    {
        Stage = 5;
    }

    public void Stage6()
    {
        Stage = 6;
    }

    public void Easy()
    {
        Diffculty = 1;
        StageData.Instance.SetData(Chapter, Stage, Diffculty);
    }

    public void Normal()
    {
        Diffculty = 12;
        StageData.Instance.SetData(Chapter, Stage, Diffculty);
    }

    public void Hard()
    {
        Diffculty = 3;
        StageData.Instance.SetData(Chapter, Stage, Diffculty);
    }

    public void Back()
    {
        Chapter = 0;
        Stage = 0;
        Diffculty = 0;
    }
}
