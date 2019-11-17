using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds;
using System;

public class GoogleAdsCallVideo : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;
    private static string outputMessage = string.Empty;

    [SerializeField] private GameObject QuestionPanel;
    [SerializeField] private GameObject ResultPanel;
    [SerializeField] private GameObject QuestionTextAdd;
    [SerializeField] private GameObject OpenQuestionBtn;
    public static int colQuestion;
    bool CSGOOpenQuestionObj;
    bool Dota2OpenQuestionObj;
    bool HSOpenQuestionObj;
    bool PUBGOpenQuestionObj;
    bool OverwatchOpenQuestionObj;
    bool WoTOpenQuestionObj;
    bool FortniteOpenQuestionObj;
    bool RSSQOpenQuestionObj;

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

        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        this.rewardBasedVideo.OnAdLoaded += this.HandleRewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.HandleRewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.HandleRewardBasedVideoOpened;
        this.rewardBasedVideo.OnAdStarted += this.HandleRewardBasedVideoStarted;
        this.rewardBasedVideo.OnAdRewarded += this.HandleRewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.HandleRewardBasedVideoClosed;
        this.rewardBasedVideo.OnAdLeavingApplication += this.HandleRewardBasedVideoLeftApplication;

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO")){
            CSGOOpenQuestionObj = PlayerPrefs.GetInt("CSGOOpenQuestionObj") == 1 ? true : false;
            if (CSGOOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2"))
        {
            Dota2OpenQuestionObj = PlayerPrefs.GetInt("Dota2OpenQuestionObj") == 1 ? true : false;
            if (Dota2OpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone"))
        {
            HSOpenQuestionObj = PlayerPrefs.GetInt("HearthStoneOpenQuestionObj") == 1 ? true : false;
            if (HSOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG"))
        {
            PUBGOpenQuestionObj = PlayerPrefs.GetInt("PUBGOpenQuestionObj") == 1 ? true : false;
            if (PUBGOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch"))
        {
            OverwatchOpenQuestionObj = PlayerPrefs.GetInt("OverwatchOpenQuestionObj") == 1 ? true : false;
            if (OverwatchOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTank"))
        {
            WoTOpenQuestionObj = PlayerPrefs.GetInt("WOTOpenQuestion") == 1 ? true : false;
            if (WoTOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fortnite"))
        {
            FortniteOpenQuestionObj = PlayerPrefs.GetInt("FortniteOpenQuestion") == 1 ? true : false;
            if (FortniteOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rainbow Six Seige"))
        {
            FortniteOpenQuestionObj = PlayerPrefs.GetInt("RSSQOpenQuestion") == 1 ? true : false;
            if (FortniteOpenQuestionObj == true) {
                QuestionTextAdd.SetActive(false);
                OpenQuestionBtn.SetActive(false);
            }
            else {
                QuestionTextAdd.SetActive(true);
                OpenQuestionBtn.SetActive(true);
            }
        }
    }

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTanks")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fortnite")) { RequestRewardBasedVideo(); }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rainbow Six Seige")) { RequestRewardBasedVideo(); }

    }

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            //.AddTestDevice("DFE9EC63A2580DAF3BA4FF724881C8DD")
            .AddExtra("max_ad_content_rating", "T")
            .TagForChildDirectedTreatment(true)
            .Build();
    }
    private void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-5132738569660673/5695289088";
#else
        string adUnitId = "unexpected_platform";
#endif

        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }
    public void ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded()) {
            this.rewardBasedVideo.Show();
            Invoke("ShowQuestion",2);  
        } else {
            MonoBehaviour.print("Reward based video ad is not ready yet");
        }
    }
    #region RewardBasedVideo callback handlers
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }
    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }
    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }
    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }
    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
    }
    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    #endregion
private void ShowQuestion(){
     if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            CSGOQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("CSGOQuestion", colQuestion);
            Debug.Log(CSGOQ.QUIZ_COUNT);
            CSGOQ.OpenQuestion = true;
            PlayerPrefs.SetInt("CSGOOpenQuestion", CSGOQ.OpenQuestion ? 1 : 0);
            CSGOOpenQuestionObj = true;
            PlayerPrefs.SetInt("CSGOOpenQuestionObj", CSGOOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            Dota2Q.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("Dota2Question", colQuestion);
            Debug.Log(Dota2Q.QUIZ_COUNT);
            Dota2Q.OpenQuestion = true;
            PlayerPrefs.SetInt("Dota2OpenQuestion", Dota2Q.OpenQuestion ? 1 : 0);
            Dota2OpenQuestionObj = true;
            PlayerPrefs.SetInt("Dota2OpenQuestionObj", Dota2OpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            HearthStoneQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("HSQuestion", colQuestion);
            Debug.Log(HearthStoneQ.QUIZ_COUNT);
            HearthStoneQ.OpenQuestion = true;
            PlayerPrefs.SetInt("HSOpenQuestion", HearthStoneQ.OpenQuestion ? 1 : 0);
            HSOpenQuestionObj = true;
            PlayerPrefs.SetInt("HearthStoneOpenQuestionObj", HSOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            PUBGQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("PUBGQuestion", colQuestion);
            Debug.Log(PUBGQ.QUIZ_COUNT);
            PUBGQ.OpenQuestion = true;
            PlayerPrefs.SetInt("PUBGHOpenQuestion", PUBGQ.OpenQuestion ? 1 : 0);
            PUBGOpenQuestionObj = true;
            PlayerPrefs.SetInt("PUBGOpenQuestionObj", PUBGOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            OverwatchQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("OverwatchQuestion", colQuestion);
            Debug.Log(OverwatchQ.QUIZ_COUNT);
            OverwatchQ.OpenQuestion = true;
            PlayerPrefs.SetInt("OverwatchOpenQuestion", OverwatchQ.OpenQuestion ? 1 : 0);
            OverwatchOpenQuestionObj = true;
            PlayerPrefs.SetInt("OverwatchOpenQuestionObj", OverwatchOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTanks")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            WOTQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("WoTQuestion", colQuestion);
            Debug.Log(WOTQ.QUIZ_COUNT);
            WOTQ.OpenQuestion = true;
            PlayerPrefs.SetInt("WoTOpenQuestion", WOTQ.OpenQuestion ? 1 : 0);
            WoTOpenQuestionObj = true;
            PlayerPrefs.SetInt("WoTOpenQuestionObj", WoTOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fortnite")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            FortniteQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("FortniteQuestion", colQuestion);
            Debug.Log(FortniteQ.QUIZ_COUNT);
            FortniteQ.OpenQuestion = true;
            PlayerPrefs.SetInt("FortniteOpenQuestion", FortniteQ.OpenQuestion ? 1 : 0);
            FortniteOpenQuestionObj = true;
            PlayerPrefs.SetInt("FortniteOpenQuestionObj", FortniteOpenQuestionObj ? 1 : 0);
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rainbow Six Seige")) {
            ResultPanel.SetActive(false);
            QuestionPanel.SetActive(true);
            QuestionTextAdd.SetActive(false);
            OpenQuestionBtn.SetActive(false);
            RSSQ.QUIZ_COUNT += 10;
            colQuestion = 20;
            PlayerPrefs.SetInt("RSSQuestion", colQuestion);
            Debug.Log(RSSQ.QUIZ_COUNT);
            RSSQ.OpenQuestion = true;
            PlayerPrefs.SetInt("RSSQOpenQuestion", RSSQ.OpenQuestion ? 1 : 0);
            RSSQOpenQuestionObj = true;
            PlayerPrefs.SetInt("RSSQOpenQuestionObj", RSSQOpenQuestionObj ? 1 : 0);
        }
    }
}
