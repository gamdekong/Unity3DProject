using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class csShowFuel : MonoBehaviour {

    public GameObject[] fullImages;
    public GameObject[] halfImages;
    public GameObject thunder;
    public float fuelValue;
    public float maxFuel;

	// Use this for initialization
	void Start () {

        fuelValue = maxFuel;

    }

    // Update is called once per frame
    void Update()
    {

        if(fuelValue > maxFuel * 0.924f)
        {
            foreach (GameObject fullImage in fullImages)
            {
                thunder.SetActive(true);
                fullImage.SetActive(true);
            }
            foreach (GameObject halfImage in halfImages)
            {
                halfImage.SetActive(false);
            }
        }
        // 1
        if(fuelValue <= maxFuel - ((maxFuel / 20)* 1) && fuelValue > maxFuel - ((maxFuel / 20) * 2))
        {
            full(0);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 2) && fuelValue > maxFuel - ((maxFuel / 20) * 3))
        {
            half(0);
        }
        // 2
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 3) && fuelValue > maxFuel - ((maxFuel / 20) * 4))
        {
            full(1);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 4) && fuelValue > maxFuel - ((maxFuel / 20) * 5))
        {
            half(1);
        }
        // 3
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 6) && fuelValue > maxFuel - ((maxFuel / 20) * 7))
        {
            full(2);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 7) && fuelValue > maxFuel - ((maxFuel / 20) * 8))
        {
            half(2);
        }
        // 4
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 8) && fuelValue > maxFuel - ((maxFuel / 20) * 9))
        {
            full(3);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 9) && fuelValue > maxFuel - ((maxFuel / 20) * 10))
        {
            half(3);
        }
        // 5
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 10) && fuelValue > maxFuel - ((maxFuel / 20) * 11))
        {
            full(4);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 11) && fuelValue > maxFuel - ((maxFuel / 20) * 12))
        {
            half(4);
        }
        // 6
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 12) && fuelValue > maxFuel - ((maxFuel / 20) * 13))
        {
            full(5);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 13) && fuelValue > maxFuel - ((maxFuel / 20) * 14))
        {
            half(5);
        }
        // 7
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 14) && fuelValue > maxFuel - ((maxFuel / 20) * 15))
        {
            full(6);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 15) && fuelValue > maxFuel - ((maxFuel / 20) * 16))
        {
            half(6);
        }
        // 8
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 16) && fuelValue > maxFuel - ((maxFuel / 20) * 17))
        {
            full(7);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 17) && fuelValue > maxFuel - ((maxFuel / 20) * 18))
        {
            half(7);
        }
        // 9
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 18) && fuelValue > maxFuel - ((maxFuel / 20) * 19))
        {
            full(8);
        }
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 19) && fuelValue > maxFuel - ((maxFuel / 20) * 20))
        {
            half(8);
        }
        // 10
        else if (fuelValue <= maxFuel - ((maxFuel / 20) * 20) && fuelValue > 0)
        {
            full(9);
        }
        else if (fuelValue <= 0)
        {
            thunder.SetActive(false);
            half(9);
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