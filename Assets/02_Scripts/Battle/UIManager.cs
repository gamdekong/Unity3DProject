using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject player;

    public GameObject background;
    public GameObject txtFuelEmpty;
    public GameObject exitTitle;
    public GameObject clearTitle;
    public GameObject hitEffect;

    public GameObject btnFire;
    public GameObject btnExit;
    public GameObject btnReset;
    public GameObject btnContinue;

    public void pushExit()
    {
        btnExit.SetActive(false);
        btnFire.SetActive(false);
        btnReset.SetActive(false);
        hitEffect.SetActive(false);

        exitTitle.SetActive(true);
        background.SetActive(true);

        Time.timeScale = 0;
    }

    public void StageClear()
    {
        StartCoroutine(WaitForClear());
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
        btnReset.SetActive(true);

        exitTitle.SetActive(false);
        background.SetActive(false);
    }

    public void BackToMain()
    {

    }

    public void Reset()
    {
        iTweenPath.RemovePath();
        SceneManager.LoadScene("BattleScene");
        Time.timeScale = 1;
    }

    public void RestartStage()
    {
        iTweenPath.RemovePath();
        SceneManager.LoadScene("BattleScene");
        Time.timeScale = 1;
    }

    public void Continue()
    {
        Reset();
    }

    IEnumerator WaitForClear()
    {
        player.GetComponent<iTweenEvent>().Stop();
        player.GetComponent<csPlayerStatus>().untouchable = true;
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Missile");
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject missile in missiles)
        {
            Destroy(missile);
        }
        foreach (GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }

        yield return new WaitForSeconds(5.0f);

        Time.timeScale = 0;

        btnExit.SetActive(false);
        btnFire.SetActive(false);
        btnReset.SetActive(false);
        hitEffect.SetActive(false);

        clearTitle.SetActive(true);
        background.SetActive(true);

    }

    IEnumerator WaitForContinue()
    {
        Color color = Color.white;
        color.a = 0;
        txtFuelEmpty.GetComponent<Text>().color = color;
        txtFuelEmpty.SetActive(true);
        background.SetActive(true);

        btnExit.SetActive(false);
        btnFire.SetActive(false);
        btnReset.SetActive(false);
        hitEffect.SetActive(false);

        for (int i = 0; i<100; i++)
        {
            color.a += 0.1f * i * Time.deltaTime;
            txtFuelEmpty.GetComponent<Text>().color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.0f);
        btnContinue.SetActive(true);
    }
}
