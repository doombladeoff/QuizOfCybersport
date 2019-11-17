using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;

public class GoogleAdsManager : MonoBehaviour
{
    private BannerView bannerView;
    private static string outputMessage = string.Empty;

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }
    public void Awake()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-5132738569660673~5694552995";
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);
        MobileAds.Initialize(appId);
        Debug.Log(appId);

    }
    public void Start()
    {
            RequestBanner();
    }
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            //.AddTestDevice("DFE9EC63A2580DAF3BA4FF724881C8DD")
            .AddExtra("max_ad_content_rating", "T")
            .TagForChildDirectedTreatment(true)
            .Build();
    }
    public void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
                string adUnitId = "ca-app-pub-5132738569660673/8965737684";
#else
                string adUnitId = "unexpected_platform";
#endif

        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;


        // Load an interstitial ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }
    public void destroybanner()
    {
        Debug.Log("Destroy");
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
    }
    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeftApplication event received");
    }

    #endregion
}
