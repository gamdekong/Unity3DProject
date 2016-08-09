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

    public GameObject player;
    public GameObject targetingManager;
    public int stageNum;
    float spawndelay = 1.5f;
    float delay;

    public Material skyboxMat;
    public int Chapter = 1;
    public GameObject[] planets;
    public GameObject planetExpEffect;
    public AudioClip planetExpSound;
    public int Stage = 1;
    public int Diff = 1;

    int AsteroidHP;
    int PlanetHP;
    int Plasma;
    int RestoreValue;
    public int fuelDamage;
    public int rewardEXP;
    public int rewardPlasma;
    public int[] rewardItemID = new int[3];
    public int[ , ] rewardItemRange = new int[3 , 2];

    void Awake()
    {
        delay = spawndelay;
        player = GameObject.Find("Player");
        targetingManager = GameObject.Find("TargetingSystem");

        Chapter = StageData.Instance.GetChapter();
        Stage = StageData.Instance.GetStage();
        Diff = StageData.Instance.GetDiffculty();

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
                        stageNum = 1;
                        pathName = "Path1";
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(60, 1, 0, 0, 2400, 50, 400, 115);
                                rewardItemRange[0, 0] = 1;
                                rewardItemRange[0, 1] = 3;
                                break;
                            case 2:
                                SetStatus(128, 6, 14, 1, 5135, 147, 1800, 115);
                                rewardItemRange[0, 0] = 2;
                                rewardItemRange[0, 1] = 5;
                                break;
                            case 3:
                                SetStatus(396, 11, 21, 2, 15828, 390, 3300, 115, 114);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 1;
                                break;
                        }
                        break;
                    case 2:
                        pathName = "Path2";
                        stageNum = 2;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(67, 2, 0, 0, 2693, 60, 700, 125);
                                rewardItemRange[0, 0] = 1;
                                rewardItemRange[0, 1] = 3;
                                break;
                            case 2:
                                SetStatus(221, 7, 15, 2, 8822, 173, 2100, 125);
                                rewardItemRange[0, 0] = 2;
                                rewardItemRange[0, 1] = 5;
                                break;
                            case 3:
                                SetStatus(435, 12, 23, 2, 17386, 452, 3600, 125, 124);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 1;
                                break;
                        }
                        break;
                    case 3:
                        pathName = "Path3";
                        stageNum = 3;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(75, 3, 0, 0, 2996, 72, 1000, 135);
                                rewardItemRange[0, 0] = 1;
                                rewardItemRange[0, 1] = 3;
                                break;
                            case 2:
                                SetStatus(253, 8, 17, 2, 10123, 204, 2400, 135);
                                rewardItemRange[0, 0] = 2;
                                rewardItemRange[0, 1] = 5;
                                break;
                            case 3:
                                SetStatus(475, 13, 26, 2, 19000, 524, 3900, 135, 134);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 1;
                                break;
                        }
                        break;
                    case 4:
                        pathName = "Path4";
                        stageNum = 4;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(83, 4, 0, 0, 3311, 86, 1300, 145);
                                rewardItemRange[0, 0] = 1;
                                rewardItemRange[0, 1] = 3;
                                break;
                            case 2:
                                SetStatus(287, 9, 18, 2, 11473, 241, 2700, 145);
                                rewardItemRange[0, 0] = 2;
                                rewardItemRange[0, 1] = 5;
                                break;
                            case 3:
                                SetStatus(517, 14, 28, 2, 20673, 608, 4200, 145, 145);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 1;
                                break;
                        }
                        break;
                    case 5:
                        pathName = "Path5";
                        stageNum = 5;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(97, 5, 0, 0, 3897, 104, 1500, 0);
                                break;
                            case 2:
                                SetStatus(322, 10, 19, 2, 12873, 285, 3000, 0);
                                break;
                            case 3:
                                SetStatus(560, 15, 30, 2, 22404, 705, 4500, 0);
                                break;
                        }
                        break;
                    case 6:
                        pathName = "Path6";
                        stageNum = 6;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(0, 0, 0, 1, 5631, 124, 2000, 0);
                                break;
                            case 2:
                                SetStatus(0, 0, 0, 2, 17905, 336, 3500, 0);
                                break;
                            case 3:
                                SetStatus(0, 0, 0, 2, 43267, 818, 5000, 0);
                                break;
                        }
                        break;
                }
                break;
            case 2:
                switch (Stage)
                {
                    case 1:
                        pathName = "Path1";
                        stageNum = 7;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(1038, 18, 31, 2, 37363, 933, 4800, 115, 114);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 2:
                                SetStatus(1555, 23, 30, 4, 55974, 2030, 6300, 115, 114, 113);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 3:
                                SetStatus(2186, 29, 29, 5, 78686, 4188, 7800, 114, 113);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        break;
                    case 2:
                        pathName = "Path2";
                        stageNum = 8;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(1117, 19, 31, 3, 40208, 1063, 5100, 125, 124);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 2:
                                SetStatus(1652, 24, 30, 4, 59456, 2294, 6600, 125, 124, 123);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 3:
                                SetStatus(2303,30,31,5,82920,4691,8100,124,123);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        break;
                    case 3:
                        pathName = "Path3";
                        stageNum = 9;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(1199, 20, 32, 3, 43152, 1212, 5400, 135, 134);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 2:
                                SetStatus(1752, 26, 31, 4, 63054, 2592, 6900, 135, 134, 133);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 3:
                                SetStatus(2550, 31, 34,6,91815,5254,8400,134,133);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        break;
                    case 4:
                        pathName = "Path4";
                        stageNum = 10;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(1283, 21, 32, 3, 46198, 1382, 5700, 145, 144);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 2:
                                SetStatus(1855, 27, 31, 4, 66773, 2929, 7200, 145, 144, 143);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 3:
                                SetStatus(2678,32,36,6,96419,5884,8700,144,143);
                                rewardItemRange[0, 0] = 4;
                                rewardItemRange[0, 1] = 7;
                                rewardItemRange[1, 0] = 1;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        break;
                    case 5:
                        pathName = "Path5";
                        stageNum = 11;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(1371, 22, 33, 3, 49348, 1576, 6000, 0);
                                break;
                            case 2:
                                SetStatus(1962, 28, 31, 4, 70616, 3309, 7500, 0);
                                break;
                            case 3:
                                SetStatus(2810, 33, 38, 6, 101171, 6590, 9000, 0);
                                break;
                        }
                        
                        break;
                    case 6:
                        pathName = "Path6";
                        stageNum = 12;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(0, 0, 0, 4, 65757, 1796, 6500, 0);
                                break;
                            case 2:
                                SetStatus(0, 0, 0, 4, 93232, 3740, 8000, 0);
                                break;
                            case 3:
                                SetStatus(0,0,0,7,132593,7381,9500,0);
                                break;
                        }
                        break;
                }
                break;
            case 3:
                switch (Stage)
                {
                    case 1:
                        pathName = "Path1";
                        stageNum = 13;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(3969,44,34,7,111133,8193,9300,114,113,112);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 2:
                                SetStatus(5179,51,29,7,145002,15186,10800,114,113,112);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 1;
                                rewardItemRange[2, 1] = 3;
                                break;
                            case 3:
                                SetStatus(6630,59,25,8,185648,26708,12300,113,112,111);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                        }
                        
                        break;
                    case 2:
                        pathName = "Path2";
                        stageNum = 14;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(4155,46,34,7,116352,9094,9600,124,123,122);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 2:
                                SetStatus(5403,53,29,7,151276,16705,11100,124,123,122);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 1;
                                rewardItemRange[2, 1] = 3;
                                break;
                            case 3:
                                SetStatus(6899,60,26,9,193161,29165,12600,123,122,121);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                        }
                        break;
                    case 3:
                        pathName = "Path3";
                        stageNum = 15;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(4348,47,35,7,121735,10095,9900,134,133,132);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 2:
                                SetStatus(5634,54,29,7,157744,18376,11400,134,133,132);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 1;
                                rewardItemRange[2, 1] = 3;
                                break;
                            case 3:
                                SetStatus(7175,61,28,9,200900,31848,12900,133,132,131);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                        }
                        break;
                    case 4:
                        
                        pathName = "Path4";
                        stageNum = 16;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(4546,49,35,7,127287,11205,10200,144,143,142);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                            case 2:
                                SetStatus(5872,56,29,7,164409,20213,11700,144,143,142);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 1;
                                rewardItemRange[2, 1] = 3;
                                break;
                            case 3:
                                SetStatus(7460,63,30,10,208872,34778,13200,143,142,141);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 2;
                                rewardItemRange[1, 1] = 5;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 1;
                                break;
                        }
                        
                        break;
                    case 5:
                        
                        pathName = "Path5";
                        stageNum = 17;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(4750,50,35,7,133012,12438,10500,0);
                                break;
                            case 2:
                                SetStatus(6117,57,29,7,171278,22234,12000,0);
                                break;
                            case 3:
                                SetStatus(9697,64,32,11,271520,37978,13500,0);
                                break;
                        }
                        
                        break;
                    case 6:
                        
                        pathName = "Path6";
                        stageNum = 18;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(0,0,0,7,173645,13806,11000,0);
                                break;
                            case 2:
                                SetStatus(0,0,0,8,222945,24458,12500,0);
                                break;
                            case 3:
                                SetStatus(0,0,0,11,353043,41472,14000,0);
                                break;
                        }
                        break;
                }
                break;
            case 4:
                switch (Stage)
                {
                    case 1:
                        
                        pathName = "Path1";
                        stageNum = 19;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(12237,77,24,12,293677,44997,13800,113,112,111);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 2;
                                break;
                            case 2:
                                SetStatus(15355,85,14,14,368525,73005,15300,112,111);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 3:
                                SetStatus(19066,93,11,457586,114674,16800,112,111);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 2:
                        
                        pathName = "Path2";
                        stageNum = 20;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(12719,78,25,12,305256,48822,14100,123,122,121);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 2;
                                break;
                            case 2:
                                SetStatus(15930,87,16,16,382321,78773,15600,122,121);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 3:
                                SetStatus(19749,95,11,23,473973,123160,17100,122,121);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 3:
                        
                        pathName = "Path3";
                        stageNum = 21;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(13216,80,26,13,317181,52972,14400,133,132,131);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 2;
                                break;
                            case 2:
                                SetStatus(16522,88,17,17,396522,84996,15900,132,131);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 3:
                                SetStatus(20451,97,12,23,490834,132274,17400,132,131);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 4:
                        
                        pathName = "Path4";
                        stageNum = 22;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(13728,82,26,13,329461,57474,14700,143,142,141);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 4;
                                rewardItemRange[1, 1] = 7;
                                rewardItemRange[2, 0] = 0;
                                rewardItemRange[2, 1] = 2;
                                break;
                            case 2:
                                SetStatus(17131,90,19,19,411138,91710,16200,142,141);
                                rewardItemRange[0, 0] = 6;
                                rewardItemRange[0, 1] = 9;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                            case 3:
                                SetStatus(21174,98,12,23,508179,142062,17700,142,141);
                                rewardItemRange[0, 0] = 8;
                                rewardItemRange[0, 1] = 10;
                                rewardItemRange[1, 0] = 0;
                                rewardItemRange[1, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 5:
                        
                        pathName = "Path5";
                        stageNum = 23;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(14254,83,27,14,342105,62359,15000,0);
                                break;
                            case 2:
                                SetStatus(17757,92,20,20,426179,98955,16500,0);
                                break;
                            case 3:
                                SetStatus(21918,100,12,24,526022,152575,18000,0);
                                break;
                        }
                        
                        break;
                    case 6:
                        
                        pathName = "Path6";
                        stageNum = 24;
                        switch (Diff)
                        {
                            case 1:
                                SetStatus(0,0,0,14,443904,67600,15500,0);
                                break;
                            case 2:
                                SetStatus(0,0,0,21,552073,106773,17000,0);
                                break;
                            case 3:
                                SetStatus(0,0,0,24,680469,163865,18500,0);
                                break;
                        }
                        
                        break;
                }
                break;
            case 5:
                switch (Stage)
                {
                    case 1:
                        
                        pathName = "Path1";
                        stageNum = 25;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(28163,122,0,24,563252,175172,18300,111);
                                rewardItemRange[0, 0] = 0;
                                rewardItemRange[0, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 2:
                        
                        pathName = "Path2";
                        stageNum = 26;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(28362,124,0,24,567247,187259,18600,121);
                                rewardItemRange[0, 0] = 0;
                                rewardItemRange[0, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 3:
                        
                        pathName = "Path3";
                        stageNum = 27;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(29133,126,0,24,582666,200180,18900,131);
                                rewardItemRange[0, 0] = 0;
                                rewardItemRange[0, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 4:
                        
                        pathName = "Path4";
                        stageNum = 28;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(29337,128,0,25,586741,213992,19200,141);
                                rewardItemRange[0, 0] = 0;
                                rewardItemRange[0, 1] = 3;
                                break;
                        }
                        
                        break;
                    case 5:
                        
                        pathName = "Path5";
                        stageNum = 29;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(30132,130,0,25,602632,228757,19500,0);
                                break;
                        }
                        
                        break;
                    case 6:
                        
                        pathName = "Path6";
                        stageNum = 30;
                        switch (Diff)
                        {
                            case 1:
                            case 2:
                            case 3:
                                SetStatus(0,0,0,25,758485,244542,20000,0);
                                break;
                        }
                        
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
                    Random.Range(destoryableAsteroid / 2, destoryableAsteroid * 2),
                    destoryableAsteroids);
            }

            if (noneDestroyableAsteroid > 0)
            {
                SpawnAsteroids(
                    ND_asteroid_minDis,
                    ND_asteroid_maxDis,
                    ND_asteroid_sepDis,
                    Random.Range(noneDestroyableAsteroid / 2, noneDestroyableAsteroid * 2),
                    noneDestoryableAsteroids);
            }
        }

        // Chapter
        Color color;
        switch (Chapter)
        {
            case 1:
                color = new Vector4(0.24f, 0.72f, 0.88f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 2:
                color = new Vector4(0.43f, 0.86f, 0.31f, 1);
                skyboxMat.SetColor("_Tint", color);
                break;
            case 3:
                color = new Vector4(0.72f, 0.72f, 0.72f, 1);
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

        Vector3 planetPos = new Vector3(0, 0, 5000);
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
                planetPos.z = 1500;
                planetObj = Instantiate(planets[5], planetPos, planetRotation) as GameObject;
                break;
            default:
                planetObj = Instantiate(planets[0], planetPos, planetRotation) as GameObject;
                break;
        }
        planetObj.GetComponent<csPlanetStatus>().health = PlanetHP;
        planetObj.GetComponent<csPlanetStatus>().expSFX = planetExpSound;
        planetObj.GetComponent<csPlanetStatus>().planetExpEffect = planetExpEffect;

        RenderSettings.skybox = skyboxMat;
    }

    void Update()
    {
        if(delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            SpawnAsteroids();
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
                    GameObject asteroid = Instantiate(asteroids[asteroidNum], asteroidPos, Quaternion.Euler(Vector3.zero)) as GameObject;
                    if (asteroid.tag == "Asteroid")
                    {
                        asteroid.transform.rotation = asteroidAngle;
                    }
                    else
                    {
                        asteroidNum++;
                        string str = "Asteroid_" + asteroidNum;
                        GameObject child = asteroid.transform.FindChild(str).gameObject;
                        child.transform.rotation = asteroidAngle;
                        if (child.layer == 8)
                        {
                            child.GetComponent<csAsteroidStatus>().health = AsteroidHP;
                            child.GetComponent<csAsteroidStatus>().plasma = Plasma;
                            child.GetComponent<csAsteroidStatus>().restore = RestoreValue;
                        }
                    }
                }
            }
        }
    }

    void SpawnAsteroids()
    {
        pathNodes = iTweenPath.GetPath(pathName);
        int pathLegth = pathNodes.Length;
        Vector3 respawnPos;

        if(player == null || targetingManager.GetComponent<TargetingManager>().isDead)
        {
            return;
        }
        else
        {
            if(player.transform.position.z < pathNodes[pathLegth - 1].z)
            {
                respawnPos = player.transform.position;
                respawnPos.z += 500;
                respawnPos.x += Random.Range(-150, 150);
                respawnPos.y += Random.Range(-150, 150);

                int asteroidNum = Random.Range(0, destoryableAsteroids.Length - 1);
                Quaternion asteroidAngle = Quaternion.Euler(new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45)));

                GameObject asteroid = Instantiate(destoryableAsteroids[asteroidNum], respawnPos, Quaternion.Euler(Vector3.zero)) as GameObject;
                asteroid.GetComponent<csAsteroidMove>().attackPlayer = true;
                asteroidNum++;
                string str = "Asteroid_" + asteroidNum;
                GameObject child = asteroid.transform.FindChild(str).gameObject;
                child.transform.rotation = asteroidAngle;
                if (child.layer == 8)
                {
                    child.GetComponent<csAsteroidStatus>().health = AsteroidHP;
                    child.GetComponent<csAsteroidStatus>().plasma = Plasma;
                    child.GetComponent<csAsteroidStatus>().restore = 0;
                }

                delay = spawndelay;
            }
            else
            {
                if(player.transform.position.z < (pathNodes[pathLegth - 1].z + 1050))
                {

                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        respawnPos = player.transform.position;
                        respawnPos.z += 500;
                        respawnPos.x += Random.Range(-300, 300);
                        respawnPos.y += Random.Range(-300, 300);

                        int asteroidNum = Random.Range(0, destoryableAsteroids.Length - 1);
                        Quaternion asteroidAngle = Quaternion.Euler(new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), Random.Range(-45, 45)));

                        GameObject asteroid = Instantiate(destoryableAsteroids[asteroidNum], respawnPos, Quaternion.Euler(Vector3.zero)) as GameObject;
                        asteroid.GetComponent<csAsteroidMove>().attackPlayer = true;
                        asteroid.GetComponent<csAsteroidMove>().speed = asteroid.GetComponent<csAsteroidMove>().speed * Random.Range(2.0f,4.0f);
                        asteroidNum++;
                        string str = "Asteroid_" + asteroidNum;
                        GameObject child = asteroid.transform.FindChild(str).gameObject;
                        child.transform.rotation = asteroidAngle;
                        if (child.layer == 8)
                        {
                            child.GetComponent<csAsteroidStatus>().health = AsteroidHP;
                            child.GetComponent<csAsteroidStatus>().plasma = Plasma;
                            child.GetComponent<csAsteroidStatus>().restore = 0;
                        }
                    }
                    delay = spawndelay / 2;
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