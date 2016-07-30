using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageData : Singleton<StageData> {

    private static int Chapter;
    private static int Stage;
    private static string PathName;
    private static int Diffculty;

    public void SetData(int chap, int stage, int diff)
    {
        Chapter = chap;
        Stage = stage;
        Diffculty = diff;

        switch(stage)
        {
            case 1:
                PathName = "Path1";
                break;
            case 2:
                PathName = "Path2";
                break;
            case 3:
                PathName = "Path3";
                break;
            case 4:
                PathName = "Path4";
                break;
            case 5:
                PathName = "Path5";
                break;
            case 6:
                PathName = "Path6";
                break;
        }

        SceneManager.LoadScene("LoadingScene");
    }

    public string GetPathName()
    {
        return PathName;
    }

    public int GetChapter()
    {
        return Chapter;
    }

    public int GetStage()
    {
        return Stage;
    }
}
