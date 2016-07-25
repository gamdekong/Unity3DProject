using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageManager : Singleton<StageManager>
{
    public static int Chapter = 0;
    public static int Stage = 0;
	
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
        Chapter = 4;
        Stage = 1;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Stage2()
    {
        Chapter = 4;
        Stage = 2;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Stage3()
    {
        Chapter = 4;
        Stage = 3;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Stage4()
    {
        Chapter = 4;
        Stage = 4;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Stage5()
    {
        Chapter = 4;
        Stage = 5;
        SceneManager.LoadScene("LoadingScene");
    }

    public void Stage6()
    {
        Chapter = 4;
        Stage = 6;
        SceneManager.LoadScene("LoadingScene");
    }

    public int GetChapter()
    {
        return Chapter;
    }

    public int GetStage()
    {
        return Stage;
    }

    public void Back()
    {
        Chapter = 0;
        Stage = 0;
    }
}
