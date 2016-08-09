using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UIManager : MonoBehaviour {

    public GameObject dbManager;
    public GameObject spawnManager;

    public GameObject player;
    public GameObject playerModel;
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
    public GameObject txtReward;

    public int destructionCount = 0;

    bool clear = false;
    bool isReward;

    void Start()
    {
        dbManager = GameObject.Find("DBManager");
        spawnManager = GameObject.Find("SpawnManager");
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
    }

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
        iTweenPath.RemovePath();
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingSceneToMain");
    }

    public void exitNo()
    {
        Time.timeScale = 1;

        btnExit.SetActive(true);
        btnFire.SetActive(true);
        //btnReset.SetActive(true);

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
        Reward();
        iTweenPath.RemovePath();
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingSceneToMain");
    }

    public void SeeAd()
    {
        if (Advertisement.IsReady())
        {
            isReward = false;
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show(null, options);
        }
    }

    public void SeeAd_Reward()
    {
        if (Advertisement.IsReady())
        {
            isReward = true;
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show(null, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (!isReward)
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
                    playerModel.GetComponent<csPlayerCollider>().hit = false;
                }
                else
                {
                    for(int i =0; i<2;i++)
                        Reward();

                    BackToMain();
                }
                Time.timeScale = 1;
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                break;
        }
    }

    IEnumerator WaitForClear()
    {
        clear = true;
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
        Reward();
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

    void Reward()
    {
        if(clear)
        {
            int plasma = DBManager.Instance.GetPlayerPlazma();
            int R_plasma = spawnManager.GetComponent<SpawnManager>().rewardPlasma;
            int[] resId = spawnManager.GetComponent<SpawnManager>().rewardItemID;
            int exp = spawnManager.GetComponent<SpawnManager>().rewardEXP;
            int chap = spawnManager.GetComponent<SpawnManager>().Chapter;
            int num = spawnManager.GetComponent<SpawnManager>().stageNum;
            int[,] resRange = spawnManager.GetComponent<SpawnManager>().rewardItemRange;

            if (num < 30 && num == DBManager.Instance.GetPlayerStage())
            {
                DBManager.Instance.IncreaseStage();
            }

            // 플라즈마 증가
            R_plasma += player.GetComponent<csPlayerStatus>().plasma;

            // 결과 텍스트
            string str = "경험치 : " + exp + " 획득 \n" + "플라즈마 : " + R_plasma + " 획득 \n";
            txtReward.GetComponent<Text>().text = str;

            plasma = plasma + R_plasma;
            DBManager.Instance.SetPlayerPlazma(plasma);
            // 자원 증가
            for(int i=0; i<3; i++)
            {
                if (resId[i] == 0)
                    break;
                else
                {
                    int range;
                    range = Random.Range(resRange[i,0], resRange[i,1]);
                    DBManager.Instance.setResource(resId[i], range);
                }
            }

            // 경험치 증가

            DBManager.Instance.LevelUp(exp);
        }

        else
        {
            int plasma = dbManager.GetComponent<DBManager>().GetPlayerPlazma();

            // 플라즈마 증가
            plasma = plasma + player.GetComponent<csPlayerStatus>().plasma;
            dbManager.GetComponent<DBManager>().SetPlayerPlazma(plasma);
        }
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
