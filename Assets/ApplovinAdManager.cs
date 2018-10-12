using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplovinAdManager : MonoBehaviour {

    public static ApplovinAdManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        AppLovin.InitializeSdk();
        AppLovin.PreloadInterstitial();
    }

    public void ShowInterstitialAd()
    {
        if (AppLovin.HasPreloadedInterstitial())
        {
            AppLovin.ShowInterstitial();
        }
    }
}
