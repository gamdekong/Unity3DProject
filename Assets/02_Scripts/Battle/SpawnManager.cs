using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    public int maximumAsteroids = 10;
    public float minimumDistance = 20.0f;
    public float maximumDistance = 60.0f;
    public float separationDistance = 6.0f;
    public string pathName;

    Vector3[] pathNodes;
    public GameObject[] asteroids;

	// Use this for initialization
	void Start () {
        SpawnAsteroids();
	}
	
	void SpawnAsteroids()
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
            int j = maximumAsteroids;
            maxZpos = nodePos.z - maximumDistance;
            minZpos = nodePos.z - minimumDistance;
            maxYpos = nodePos.y + (maximumDistance / 2);
            minYpos = nodePos.y - (maximumDistance / 2);
            maxXpos = nodePos.x + (maximumDistance / 2);
            minXpos = nodePos.x - (maximumDistance / 2);

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
                        if (dis < separationDistance)
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