using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private int sceneIndex;
    [SerializeField] private int seconds;

    [Header("Privacy Policy")]
    [SerializeField] private GameObject PrivacyPanel; 
    [SerializeField] private string Link; 
    bool AcceptedPolicy = false;

    [SerializeField] private TextMeshProUGUI PrivacyPolicyHeaderText, PrivacyPolicyText, PrivacyPolicyLinkText, PrivacyPolicyButtonText;
    [SerializeField] private TextMeshProUGUI LoadingText;
    private void Awake()
    {
        if(Application.systemLanguage == SystemLanguage.Russian){
            PrivacyPolicyHeaderText.text = "Политика конфиденциальности";
            PrivacyPolicyText.text = "Мы заботимся о конфиденциальности.<br>Наши рекламодатели хранят ваши данные для показа объявлений, связанных с вашими интересами.<br>Если вы хотите узнать больше о нашей политике конфиденциальности, вы можете увидеть её";
            PrivacyPolicyLinkText.text = "по этой ссылке";
            PrivacyPolicyButtonText.text = "Согласен";
            LoadingText.text = "Загрузка...";
        } else {
            PrivacyPolicyHeaderText.text = "Privacy Policy";
            PrivacyPolicyText.text = "We care about privacy.\nOur advertisers store your data to show ads related to your interests.\nIf you want more details about our privacy policy you can see it";
            PrivacyPolicyLinkText.text = "in this link";
            PrivacyPolicyButtonText.text = "Accept"; 
            LoadingText.text = "Loading...";
        }
        AcceptedPolicy = PlayerPrefs.GetInt("AcceptedPolicy") == 1 ? true : false;
        if(AcceptedPolicy == true){
            PrivacyPanel.SetActive(false);
            LoadMenu();
        } else {
            PrivacyPanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (slider.value == 1f) {
            SceneManager.LoadSceneAsync(sceneIndex);
        }
    }

    IEnumerator AnimateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            slider.value = Mathf.Lerp(0f, 1f, lerpValue);

            yield return null;
        }
    }
    public void LoadMenu() {
        StartCoroutine(AnimateSliderOverTime(seconds));
    }
    public void AcceptButtonPrivacy(){
        AcceptedPolicy = true;
        PlayerPrefs.SetInt("AcceptedPolicy", AcceptedPolicy ? 1 : 0);
        PrivacyPanel.SetActive(false);
        Debug.Log(AcceptedPolicy);
        LoadMenu();
    }
    public void OpenLinkPrivacy(){
        Application.OpenURL(Link);
    }
}
