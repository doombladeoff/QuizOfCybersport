using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RateManager : MonoBehaviour
{
    [Tooltip("AppID, example: com.SeFF.QuizOfCyberSport")]

    [SerializeField] private string ANDROID_RATE_LINK = "market://details?id=com.SeFF.QuizOfCyberSport";
    [SerializeField] private GameObject RatePanel;
    [SerializeField] private GameObject DisciplinePanel;
    public static int PassedTheTest;
    private bool ShowRatePanel;
    [Header("Текст на панели")]
    [SerializeField] private TextMeshProUGUI Header_text;
    [SerializeField] private TextMeshProUGUI Rate_text;
    [SerializeField] private TextMeshProUGUI RateBTN1_text;
    [SerializeField] private TextMeshProUGUI RateBTN2_text;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        ShowRatePanel = PlayerPrefs.GetInt("RateApp") == 1 ? true : false;

    }

    private void Start()
    {
        Debug.Log("-------------------------");
        Debug.Log(PassedTheTest);
        Debug.Log("-------------------------");
    }
    private void Update()
    {
        if (LanguageManager.RU_language_selected == true) {
            Header_text.SetText("Оцените наше приложение");
            Rate_text.SetText("Если вам нравится наше приложение, оцените его в Google Play.");
            RateBTN1_text.SetText("Оценить");
            RateBTN2_text.SetText("Нет, спасибо");
        }
        if (LanguageManager.ENG_language_selected == true) {
            Header_text.SetText("Rate our App");
            Rate_text.SetText("If you love our app, please take a moment to rate it in the Google Play");
            RateBTN1_text.SetText("Rate");
            RateBTN2_text.SetText("No, thanks");
        }

        if (PassedTheTest == 2 || PassedTheTest == 4 || PassedTheTest == 6) {
            if (ShowRatePanel == false) {
                DisciplinePanel.SetActive(false);
                RatePanel.SetActive(true);
            }
            if (ShowRatePanel == true) {
                RatePanel.SetActive(false);
                DisciplinePanel.SetActive(true);
            }
        }
    }

    public void OpenURL() {
#if UNITY_ANDROID
        Application.OpenURL(ANDROID_RATE_LINK);
        Debug.Log("URL Opened");
        RatePanel.SetActive(false);
        DisciplinePanel.SetActive(true);
#endif
    }
    public void NeverOpen() {
        ShowRatePanel = true;
        RatePanel.SetActive(false);
        DisciplinePanel.SetActive(true);
        PlayerPrefs.SetInt("RateApp", ShowRatePanel ? 1 : 0);
    }
}
