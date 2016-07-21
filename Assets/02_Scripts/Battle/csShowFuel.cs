using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csShowFuel : MonoBehaviour {

    public GameObject[] fullImages;
    public GameObject[] halfImages;
    public float fuelValue;
    public float maxFuel;

	// Use this for initialization
	void Start () {

        fuelValue = maxFuel;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(fuelValue);
        if(fuelValue > maxFuel * 0.924f)
        {
            foreach (GameObject fullImage in fullImages)
            {
                fullImage.SetActive(true);
            }
            foreach (GameObject halfImage in halfImages)
            {
                halfImage.SetActive(false);
            }
        }
        // 1
        if(fuelValue <= maxFuel - ((maxFuel / 26)* 1) && fuelValue > maxFuel - ((maxFuel / 26) * 2))
        {
            full(0);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 2) && fuelValue > maxFuel - ((maxFuel / 26) * 3))
        {
            half(0);
        }
        // 2
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 3) && fuelValue > maxFuel - ((maxFuel / 26) * 4))
        {
            full(1);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 4) && fuelValue > maxFuel - ((maxFuel / 26) * 5))
        {
            half(1);
        }
        // 3
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 6) && fuelValue > maxFuel - ((maxFuel / 26) * 7))
        {
            full(2);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 7) && fuelValue > maxFuel - ((maxFuel / 26) * 8))
        {
            half(2);
        }
        // 4
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 8) && fuelValue > maxFuel - ((maxFuel / 26) * 9))
        {
            full(3);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 9) && fuelValue > maxFuel - ((maxFuel / 26) * 10))
        {
            half(3);
        }
        // 5
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 10) && fuelValue > maxFuel - ((maxFuel / 26) * 11))
        {
            full(4);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 11) && fuelValue > maxFuel - ((maxFuel / 26) * 12))
        {
            half(4);
        }
        // 6
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 12) && fuelValue > maxFuel - ((maxFuel / 26) * 13))
        {
            full(5);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 13) && fuelValue > maxFuel - ((maxFuel / 26) * 14))
        {
            half(5);
        }
        // 7
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 14) && fuelValue > maxFuel - ((maxFuel / 26) * 15))
        {
            full(6);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 15) && fuelValue > maxFuel - ((maxFuel / 26) * 16))
        {
            half(6);
        }
        // 8
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 16) && fuelValue > maxFuel - ((maxFuel / 26) * 17))
        {
            full(7);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 17) && fuelValue > maxFuel - ((maxFuel / 26) * 18))
        {
            half(7);
        }
        // 9
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 18) && fuelValue > maxFuel - ((maxFuel / 26) * 19))
        {
            full(8);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 19) && fuelValue > maxFuel - ((maxFuel / 26) * 20))
        {
            half(8);
        }
        // 10
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 20) && fuelValue > maxFuel - ((maxFuel / 26) * 21))
        {
            full(9);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 21) && fuelValue > maxFuel - ((maxFuel / 26) * 22))
        {
            half(9);
        }
        // 11
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 22) && fuelValue > maxFuel - ((maxFuel / 26) * 23))
        {
            full(10);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 23) && fuelValue > maxFuel - ((maxFuel / 26) * 24))
        {
            half(10);
        }
        // 12
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 24) && fuelValue > maxFuel - ((maxFuel / 26) * 25))
        {
            full(11);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 25) && fuelValue > maxFuel - ((maxFuel / 26) * 26))
        {
            half(11);
        }
        // 13
        else if (fuelValue <= maxFuel - ((maxFuel / 26) * 26) && fuelValue > 0)
        {
            full(12);
        }
        else if (fuelValue <= 0)
        {
            half(12);
        }
    }

    void full(int value)
    {
        for (int i = 0; i < fullImages.Length; i++)
        {
            if (i == value)
            {
                fullImages[i].SetActive(false);
                halfImages[i].SetActive(true);
            }
            else if(i < value)
            {
                fullImages[i].SetActive(false);
                halfImages[i].SetActive(false);
            }
            else
            {
                fullImages[i].SetActive(true);
                halfImages[i].SetActive(false);
            }
        }
    }

    void half(int value)
    {
        for (int i = 0; i < fullImages.Length; i++)
        {
            if (i <= value)
            {
                fullImages[i].SetActive(false);
                halfImages[i].SetActive(false);
            }
            else
            {
                fullImages[i].SetActive(true);
                halfImages[i].SetActive(false);
            }
        }
    }
}