using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    int timer = 5;
    bool stTimer = false;
    bool showText = false;
    //Pages
    [SerializeField] private GameObject PageOne, PageTwo, ComingSoon;
    [SerializeField] private Text SoonText;
    // Pages Button
    [SerializeField] private GameObject NextPage, PrevsPage;
 
    [SerializeField] private Sprite[] PageIcons;
    int Pages;

    // Load Scene Function 
    public void LoadMenu() { SceneManager.LoadScene("MainScene");}
    public void LoadDota2() { SceneManager.LoadScene("Dota2"); }
    public void LoadCSGO() { SceneManager.LoadScene("CSGO");}
    public void LoadHearthStone() { SceneManager.LoadScene("HearthStone");}
    public void LoadPUBG() { SceneManager.LoadScene("PUBG");}
    public void LoadOverwatch() { SceneManager.LoadScene("Overwatch");}
    public void LoadWoT() { SceneManager.LoadScene("WorldOfTanks");}
    public void LoadFortnite() { SceneManager.LoadScene("Fortnite");}
    public void LoadRainbowSixSeige() { SceneManager.LoadScene("Rainbow Six Seige");}
    // Page Function
    public void NxtPage() { PageOne.SetActive(false); PageTwo.SetActive(true); Pages = 1; }
    public void PrevPage() { PageTwo.SetActive(false); PageOne.SetActive(true); Pages = 0; }
    // Coming Soon Function
    public void Soon() { ComingSoon.SetActive(true); stTimer = true; showText = true; }

    private void Start()
    {
        QualitySettings.SetQualityLevel(6);
        Debug.Log("Graphics quality: " + QualitySettings.GetQualityLevel());

        NextPage = GameObject.FindGameObjectWithTag("NextPage");
        PrevsPage = GameObject.FindGameObjectWithTag("PreviousPage");

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")){
                Application.Quit();
            }
            LoadMenu(); 
        }
        if (stTimer == true)
        {
            Invoke("TimerStart", 1);
        }

        if (Pages == 0 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene"))
        {
            PrevsPage.GetComponent<Image>().sprite = PageIcons[2];
            NextPage.GetComponent<Image>().sprite = PageIcons[1];
        }
        else if (Pages == 1 && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene")) {
            PrevsPage.GetComponent<Image>().sprite = PageIcons[0];
            NextPage.GetComponent<Image>().sprite = PageIcons[3];
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainScene") && showText == true){
            if(LanguageManager.RU_language_selected == true){
                SoonText.text = "Скоро";
            } else {
                SoonText.text = "Coming soon";
            }
        }

    }
    void TimerStart() {
        if (timer > 0)
        {
            timer -= 1;
            Debug.Log(timer);
        }
        else {
            ComingSoon.SetActive(false);
            stTimer = false;
            showText = false;
            timer = 5;
        }
    }
}
