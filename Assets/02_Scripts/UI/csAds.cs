using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class csAds : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowDefaultAd()
    {
#if UNITY_ADS
        if(Advertisement.IsReady())
        {
            Advertisement.Show();
        }
#endif


    }

    public void ShowRewardedAd()
    {
        if(Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions();
            options.resultCallback = HandleShowResult;
            Advertisement.Show(null, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                //아이템 증정

                GetComponent<csShowAdButton>().MakeCardAd();
                break;
            case ShowResult.Skipped:

                break;
            case ShowResult.Failed:

                break;
        }
    }
}
