using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject player;
    public GameObject playerCam;
    public GameObject playerCamPos;
    public GameObject fuelBar;

    public GameObject background;
    public GameObject txtFuelEmpty;
    public GameObject exitTitle;
    public GameObject clearTitle;
    public GameObject hitEffect;

    public GameObject btnFire;
    public GameObject btnExit;
    public GameObject btnReset;
    public GameObject btnContinue;
    public GameObject btnSeeAd;

    public GameObject txtSpeed;
    public GameObject txtDestruction;

    public int destructionCount = 0;

    void Update()
    {
        showSpeed();
        showCount();
    }

    void showSpeed()
    {
        float speed = player.GetComponent<csPlayerMovement>().GetSpeed();
        txtSpeed.GetComponent<Text>().text = "Speed : " + speed.ToString("0.#")+ "m/s";
    }

    void showCount()
    {
        txtDestruction.GetComponent<Text>().text = "Destruction : " + destructionCount;
    }

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
        iTweenPath.RemovePath();
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingSceneToMain");
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
        iTweenPath.RemovePath();
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingSceneToMain");
    }

    public void SeeAd()
    {
        btnExit.SetActive(true);
        btnFire.SetActive(true);
        txtDestruction.SetActive(true);
        txtSpeed.SetActive(true);
        background.SetActive(false);
        txtFuelEmpty.SetActive(false);
        btnContinue.SetActive(false);
        btnSeeAd.SetActive(false);

        player.GetComponent<csPlayerMovement>().SetSpeed(0.0f);
        player.transform.position = player.GetComponent<csPlayerMovement>().respawnPos;
        player.transform.rotation = player.GetComponent<csPlayerMovement>().respawnRot;

        if (player.transform.position.z > player.GetComponent<csPlayerMovement>().LastPos.z)
            player.transform.position = player.GetComponent<csPlayerMovement>().LastPos;

        playerCam.transform.parent = playerCamPos.transform;
        playerCamPos.transform.localPosition = new Vector3(0, 0, 0);
        playerCam.transform.localPosition = new Vector3(0, 2, -5.75f);
        playerCam.transform.localRotation = Quaternion.Euler(new Vector3(10, 0, 0));
        GameObject.Find("TargetingSystem").GetComponent<TargetingManager>().isDead = false;
        GameObject.Find("FireSystem").GetComponent<csFireManager>().isDead = false;

        player.GetComponent<csPlayerStatus>().SetFuel(player.GetComponent<csPlayerStatus>().playerFuel);
        player.GetComponent<csPlayerMovement>().fuelEmpty = false;
        player.GetComponent<csPlayerStatus>().playonce = false;
        player.GetComponent<csPlayerStatus>().untouchable = false;

        Time.timeScale = 1;
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
        txtDestruction.SetActive(false);
        txtSpeed.SetActive(false);

        clearTitle.SetActive(true);
        background.SetActive(true);
        txtFuelEmpty.SetActive(false);
        btnContinue.SetActive(false);
        btnSeeAd.SetActive(false);
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
        txtDestruction.SetActive(false);
        txtSpeed.SetActive(false);

        for (int i = 0; i<100; i++)
        {
            color.a += 0.1f * i * Time.deltaTime;
            txtFuelEmpty.GetComponent<Text>().color = color;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(1.0f);
        btnContinue.SetActive(true);
        btnSeeAd.SetActive(true);
    }

    IEnumerator Vibration()
    {
        for(int i =0; i < 3; i++)
        {
            Handheld.Vibrate();
            yield return new WaitForSeconds(0.6f);
        }
    }
}
