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

	// Use this for initialization
	void Start () {
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