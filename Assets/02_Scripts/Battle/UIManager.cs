﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public GameObject player;

    public GameObject background;
    public GameObject exitTitle;
    public GameObject clearTitle;

    public GameObject btnFire;
    public GameObject btnExit;
    public GameObject btnReset;

    public void pushExit()
    {
        Time.timeScale = 0;

        btnExit.SetActive(false);
        btnFire.SetActive(false);
        btnReset.SetActive(false);

        exitTitle.SetActive(true);
        background.SetActive(true);
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

    IEnumerator WaitForClear()
    {
        player.GetComponent<iTweenEvent>().Stop();
        player.GetComponent<csPlayerStatus>().untouchable = true;
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Missile");
        foreach (GameObject missile in missiles)
        {
            GameObject.Destroy(missile);
        }

        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 0;

        btnExit.SetActive(false);
        btnFire.SetActive(false);
        btnReset.SetActive(false);

        clearTitle.SetActive(true);
        background.SetActive(true);

    }
}