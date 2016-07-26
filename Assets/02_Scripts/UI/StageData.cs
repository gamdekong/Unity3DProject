using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageData : Singleton<StageData> {

    private static int Chapter;
    private static int Stage;

    public void SetData(int chap, int stage)
    {
        Chapter = chap;
        Stage = stage;

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
}
