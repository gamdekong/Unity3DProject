using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public int destoryableAsteroid = 4;
    public float D_asteroid_minDis = 20.0f;
    public float D_asteroid_maxDis = 60.0f;
    public float D_asteroid_sepDis = 6.0f;

    public int noneDestroyableAsteroid = 6;
    public float ND_asteroid_minDis = 20.0f;
    public float ND_asteroid_maxDis = 60.0f;
    public float ND_asteroid_sepDis = 6.0f;
    public string pathName;

    Vector3[] pathNodes;
    public GameObject[] destoryableAsteroids;
    public GameObject[] noneDestoryableAsteroids;

    public GameObject StageData;

    public Material skyboxMat;
    public int Chapter = 1;
    public GameObject[] planets;
    public GameObject planetExpEffect;
    public AudioClip planetExpSound;
    public int Stage = 1;

    int AsteroidHP;
    int PlanetHP;
    int Plasma;
    int RestoreValue;
    public int fuelDamage;
    public int rewardEXP;
    public int rewardPlasma;
    public int[] rewardItemID = { 0, 0, 0 };

    void Awake()
    {
        StageData = GameObject.Find("StageData");

        Chapter = StageData.GetComponent<StageData>().GetChapter();
        Stage = StageData.GetComponent<StageData>().GetStage();
    }

    // Use this for initialization
    void Start()
    {
        // Status

        switch (Chapter)
        {
            case 1:
                switch (Stage)
                {
                    case 1:
                        SetStatus(60, 1, 0, 0, 2400, 50, 400, 115);
                        break;
                    case 2:
                        SetStatus(67, 2, 0, 0, 2693, 60, 700, 125);
                        break;
                    case 3:
                        SetStatus(75, 3, 0, 0, 2996, 72, 1000, 135);
                        break;
                    case 4:
                        SetStatus(83, 4, 0, 0, 3311, 86, 1300, 145);
                        break;
                    case 5:
                        SetStatus(97, 5, 0, 0, 3897, 104, 1500, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 1, 5631, 124, 2000, 0);
                        break;
                }
                break;
            case 2:
                switch (Stage)
                {
                    case 1:
                        SetStatus(128, 6, 14, 1, 5135, 147, 1800, 115);
                        break;
                    case 2:
                        SetStatus(221, 7, 15, 2, 8822, 173, 2100, 125);
                        break;
                    case 3:
                        SetStatus(253, 8, 17, 2, 10123, 204, 2400, 135);
                        break;
                    case 4:
                        SetStatus(287, 9, 18, 2, 11473, 241, 2700, 145);
                        break;
                    case 5:
                        SetStatus(322, 10, 19, 2, 12873, 285, 3000, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 2, 17905, 336, 3500, 0);
                        break;
                }
                break;
            case 3:
                switch (Stage)
                {
                    case 1:
                        SetStatus(396, 11, 21, 2, 15828, 390, 3300, 115, 114);
                        break;
                    case 2:
                        SetStatus(435, 12, 23, 2, 17386, 452, 3600, 125, 124);
                        break;
                    case 3:
                        SetStatus(475, 13, 26, 2, 19000, 524, 3900, 135, 134);
                        break;
                    case 4:
                        SetStatus(517, 14, 28, 2, 20673, 608, 4200, 145, 145);
                        break;
                    case 5:
                        SetStatus(560, 15, 30, 2, 22404, 705, 4500, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 2, 43267, 818, 5000, 0);
                        break;
                }
                break;
            case 4:
                switch (Stage)
                {
                    case 1:
                        SetStatus(1038, 18, 31, 2, 37363, 933, 4800, 115, 114);
                        break;
                    case 2:
                        SetStatus(1117, 19, 31, 3, 40208, 1063, 5100, 125, 124);
                        break;
                    case 3:
                        SetStatus(1199, 20, 32, 3, 43152, 1212, 5400, 135, 134);
                        break;
                    case 4:
                        SetStatus(1283, 21, 32, 3, 46198, 1382, 5700, 145, 144);
                        break;
                    case 5:
                        SetStatus(1371, 22, 33, 3, 49348, 1576, 6000, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 4, 65757, 1796, 6500, 0);
                        break;
                }
                break;
            case 5:
                switch (Stage)
                {
                    case 1:
                        SetStatus(1555, 23, 30, 4, 55974, 2030, 6300, 115, 114, 113);
                        break;
                    case 2:
                        SetStatus(1652, 24, 30, 4, 59456, 2294, 6600, 125, 124, 123);
                        break;
                    case 3:
                        SetStatus(1752, 26, 31, 4, 63054, 2592, 6900, 135, 134, 133);
                        break;
                    case 4:
                        SetStatus(1855, 27, 31, 4, 66773, 2929, 7200, 145, 144, 143);
                        break;
                    case 5:
                        SetStatus(1962, 28, 31, 4, 70616, 3309, 7500, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 4, 93232, 3740, 8000, 0);
                        break;
                }
                break;
            case 6:
                switch (Stage)
                {
                    case 1:
                        SetStatus(2186, 29, 29, 4, 78686, 4188, 7800, 114, 113);
                        break;
                    case 2:
                        SetStatus(2303, 30, 31, 4, 82920, 4691, 8100, 124, 123);
                        break;
                    case 3:
                        SetStatus(2550, 31, 34, 4, 91815, 5254, 7800, 134, 133);
                        break;
                    case 4:
                        SetStatus(2678, 32, 36, 4, 96419, 5884, 8700, 144, 143);
                        break;
                    case 5:
                        SetStatus(2810, 33, 38, 4, 101171, 6590, 9000, 0);
                        break;
                    case 6:
                        SetStatus(0, 0, 0, 4, 132593, 7381, 9500, 0);
                        break;
                }
                break;
        }

        if (Stage < 6)
        {
            if (destoryableAsteroid > 0)
            {
                SpawnAsteroids(
                    D_asteroid_minDis,
                    D_asteroid_maxDis,
                    D_asteroid_sepDis,
                    destoryableAsteroid,
                    destoryableAsteroids);
            }

            if (noneDestroyableAsteroid > 0)
            {
                SpawnAsteroids(
                    ND_asteroid_minDis,
                    ND_asteroid_maxDis,
                    ND_asteroid_sepDis,
                    noneDestroyableAsteroid,
                    noneDestoryableAsteroids);
            }
        }

        // Chapter
        Color color;
        switch (Chapter)
        {
            case 1:
                color = new Vector4(0.72f, 0.72f, 0.72f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 2:
                color = new Vector4(0.43f, 0.86f, 0.31f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 3:
                color = new Vector4(0.24f, 0.72f, 0.88f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 4:
                color = new Vector4(0.86f, 0.31f, 0.31f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 5:
                color = new Vector4(0.86f, 0.31f, 0.31f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
        }

        Vector3 planetPos = new Vector3(0, 0, 7800);
        Quaternion planetRotation = Quaternion.Euler(0, 0, 0);
        GameObject planetObj;
        // Stage
        switch (Stage)
        {
            case 1:
                planetObj = Instantiate(planets[0], planetPos, planetRotation) as GameObject;
                pathName = "Path1";
                break;
            case 2:
                planetObj = Instantiate(planets[1], planetPos, planetRotation) as GameObject;
                pathName = "Path2";
                break;
            case 3:
                planetObj = Instantiate(planets[2], planetPos, planetRotation) as GameObject;
                pathName = "Path3";
                break;
            case 4:
                planetObj = Instantiate(planets[3], planetPos, planetRotation) as GameObject;
                pathName = "Path4";
                break;
            case 5:
                planetObj = Instantiate(planets[4], planetPos, planetRotation) as GameObject;
                pathName = "Path5";
                break;
            case 6:
                planetPos.z = 1500;
                planetObj = Instantiate(planets[5], planetPos, planetRotation) as GameObject;
                pathName = "Path6";
                break;
            default:
                planetObj = Instantiate(planets[0], planetPos, planetRotation) as GameObject;
                pathName = "Path1";
                break;
        }
        planetObj.GetComponent<csPlanetStatus>().health = PlanetHP;
        planetObj.GetComponent<csPlanetStatus>().expSFX = planetExpSound;
        planetObj.GetComponent<csPlanetStatus>().planetExpEffect = planetExpEffect;

        RenderSettings.skybox = skyboxMat;
    }
	
	void SpawnAsteroids(float minDis, float maxDis, float sepDis, int maxCount, GameObject[] asteroids)
    {

        // Path 설정
        pathNodes = iTweenPath.GetPath(pathName);
        Vector3 nodePos, asteroidPos;
        Quaternion asteroidAngle;
        float maxZpos, maxYpos, maxXpos;
        float minZpos, minYpos, minXpos;
        float asteroidZpos, asteroidYpos, asteroidXpos;

        int pathLegth = pathNodes.Length;
        int asteroidNum;

        bool canMake;

        for (int i = 1; i < pathLegth; i++)
        {
            // 각 노드마다 위치 설정
            nodePos = pathNodes[i];
            int j = maxCount;
            maxZpos = nodePos.z - maxDis;
            minZpos = nodePos.z - minDis;
            maxYpos = nodePos.y + (maxDis / 2);
            minYpos = nodePos.y - (maxDis / 2);
            maxXpos = nodePos.x + (maxDis / 2);
            minXpos = nodePos.x - (maxDis / 2);

            while (j != 0)
            {
                canMake = true;
                asteroidNum = Random.Range(0, asteroids.Length - 1);
                asteroidZpos = Random.Range(minZpos, maxZpos);
                asteroidYpos = Random.Range(minYpos, maxYpos);
                asteroidXpos = Random.Range(minXpos, maxXpos);
                asteroidPos = new Vector3(asteroidXpos, asteroidYpos, asteroidZpos);
                asteroidAngle = Quaternion.Euler(new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45)));

                if (GameObject.FindGameObjectWithTag("Asteroid"))
                {
                    GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Asteroid");
                    foreach (GameObject obstacle in obstacles)
                    {
                        float dis = Vector3.Distance(asteroidPos, obstacle.transform.position);
                        if (dis < sepDis)
                        {
                            canMake = false;
                            break;
                        }
                    }
                }
                if(canMake)
                {
                    j--;
                    GameObject asteroid = Instantiate(asteroids[asteroidNum], asteroidPos, asteroidAngle) as GameObject;
                    if (asteroid.layer == 8)
                    {
                        asteroid.GetComponent<csAsteroidStatus>().health = AsteroidHP;
                        asteroid.GetComponent<csAsteroidStatus>().plasma = Plasma;
                        asteroid.GetComponent<csAsteroidStatus>().restore = RestoreValue;
                    }
                }
            }
        }
    }

    void SetStatus(int health, int plasma, int restoreVal, int dmg, int P_health, int exp, int R_plasma,
        int itemID)
    {
        AsteroidHP = health;
        Plasma = plasma;
        RestoreValue = restoreVal;
        fuelDamage = dmg;
        PlanetHP = P_health;
        rewardEXP = exp;
        rewardPlasma = R_plasma;

        rewardItemID[0] = itemID;
    }

    void SetStatus(int health, int plasma, int restoreVal, int dmg, int P_health, int exp, int R_plasma, 
         int itemID_1, int itemID_2)
    {
        AsteroidHP = health;
        Plasma = plasma;
        RestoreValue = restoreVal;
        fuelDamage = dmg;
        PlanetHP = P_health;
        rewardEXP = exp;
        rewardPlasma = R_plasma;

        rewardItemID[0] = itemID_1;
        rewardItemID[1] = itemID_2;
    }

    void SetStatus(int health, int plasma, int restoreVal, int dmg, int P_health, int exp, int R_plasma,
        int itemID_1, int itemID_2, int itemID_3)
    {
        AsteroidHP = health;
        Plasma = plasma;
        RestoreValue = restoreVal;
        fuelDamage = dmg;
        PlanetHP = P_health;
        rewardEXP = exp;
        rewardPlasma = R_plasma;

        rewardItemID[0] = itemID_1;
        rewardItemID[1] = itemID_2;
        rewardItemID[2] = itemID_3;
    }
}