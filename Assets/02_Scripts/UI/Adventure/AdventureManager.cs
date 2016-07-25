using UnityEngine;
using System.Collections;

public class AdventureManager : MonoBehaviour
{


    public GameObject[] chapter1;
    public GameObject[] chapter2;
    public GameObject[] chapter3;
    public GameObject[] chapter4;
    public GameObject[] chapter5;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnEnable()
    {

        int stage = DBManager.Instance.GetPlayerStage();

        if (stage >= 30)
        {
            for (int i = 0; i < 7; i++)
            {
                chapter5[i].SetActive(false);
             
            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        
        else if (stage >= 29)
        {
            for (int i = 0; i < 6; i++)
            {
                chapter5[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 28)
        {
            for (int i = 0; i < 5; i++)
            {
                chapter5[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 27)
        {
            for (int i = 0; i < 4; i++)
            {
                chapter5[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 26)
        {
            for (int i = 0; i < 3; i++)
            {
                chapter5[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 25)
        {
            for (int i = 0; i < 2; i++)
            {
                chapter5[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 24)
        {
            
            for (int i = 0; i < 7; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 23)
        {

            for (int i = 0; i < 6; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 22)
        {

            for (int i = 0; i < 5; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 21)
        {

            for (int i = 0; i < 4; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 20)
        {

            for (int i = 0; i < 2; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 19)
        {

            for (int i = 0; i < 2; i++)
            {
                chapter4[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 18)
        {

            
            for (int i = 0; i < 7; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 17)
        {

            
            for (int i = 0; i < 6; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 16)
        {

           
            for (int i = 0; i < 5; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 15)
        {

          
            for (int i = 0; i < 4; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 14)
        {

           
            for (int i = 0; i < 3; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 13)
        {

        
            for (int i = 0; i < 2; i++)
            {
                chapter3[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 12)
        {


            for (int i = 0; i < 7; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 11)
        {


            for (int i = 0; i < 6; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 10)
        {


            for (int i = 0; i < 5; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 9)
        {


            for (int i = 0; i < 4; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 8)
        {


            for (int i = 0; i < 3; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 7)
        {


            for (int i = 0; i < 2; i++)
            {
                chapter2[i].SetActive(false);

            }
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 6)
        {


           
            for (int i = 0; i < 7; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 5)
        {



            for (int i = 0; i < 6; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 4)
        {



            for (int i = 0; i < 5; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 3)
        {



            for (int i = 0; i < 4; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 2)
        {



            for (int i = 0; i < 3; i++)
            {
                chapter1[i].SetActive(false);

            }
        }
        else if (stage >= 1)
        {



            for (int i = 0; i < 2; i++)
            {
                chapter1[i].SetActive(false);

            }
        }

    }
}
