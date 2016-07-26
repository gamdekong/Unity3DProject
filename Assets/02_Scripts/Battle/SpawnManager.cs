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

    void Awake()
    {
        StageData = GameObject.Find("StageData");

        Chapter = StageData.GetComponent<StageData>().GetChapter();
        Stage = StageData.GetComponent<StageData>().GetStage();
    }

    // Use this for initialization
    void Start()
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
                break;
            case 2:
                planetObj = Instantiate(planets[1], planetPos, planetRotation) as GameObject;
                break;
            case 3:
                planetObj = Instantiate(planets[2], planetPos, planetRotation) as GameObject;
                break;
            case 4:
                planetObj = Instantiate(planets[3], planetPos, planetRotation) as GameObject;
                break;
            case 5:
                planetObj = Instantiate(planets[4], planetPos, planetRotation) as GameObject;
                break;
            case 6:
                planetObj = Instantiate(planets[5], planetPos, planetRotation) as GameObject;
                break;
            default:
                planetObj = Instantiate(planets[0], planetPos, planetRotation) as GameObject;
                break;
        }
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
                    Instantiate(asteroids[asteroidNum], asteroidPos, asteroidAngle);
                }
            }
        }
    }
}