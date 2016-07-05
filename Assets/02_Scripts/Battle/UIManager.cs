using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject background;
    public GameObject btnFire;
    public GameObject exitTitle;
    public GameObject btnExit;

	public void pushExit()
    {
        Time.timeScale = 0;

        btnExit.SetActive(false);
        btnFire.SetActive(false);
        exitTitle.SetActive(true);
        background.SetActive(true);
    }

    public void exitYes()
    {
        Application.Quit();
    }

    public void exitNo()
    {
        Time.timeScale = 1;

        btnExit.SetActive(true);
        btnFire.SetActive(true);
        exitTitle.SetActive(false);
        background.SetActive(false);
    }
}
