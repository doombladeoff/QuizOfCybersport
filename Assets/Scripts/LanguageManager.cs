using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private bool RU_language;
    [SerializeField] private bool ENG_language;
    public static bool RU_language_selected = false;
    public static bool ENG_language_selected = true;
    [SerializeField] private GameObject Selected_RU;
    [SerializeField] private GameObject Selected_ENG;
    [SerializeField] private TextMeshProUGUI Choose_Discipline;
    // 
    [SerializeField] private TextMeshProUGUI Result;
    [SerializeField] private TextMeshProUGUI NextBtn;
    //
    private int isDefault;

    private void Awake() {

        isDefault = PlayerPrefs.GetInt("DefaultLanguage");

        if (isDefault ==  0){
            Debug.Log("Calling def lang");
            SelectENGLanguage();
        }
        //PlayerPrefs.DeleteAll();
        RU_language_selected = PlayerPrefs.GetInt("RULanguage") == 1 ? true : false;
        ENG_language_selected = PlayerPrefs.GetInt("ENGLanguage") == 1 ? true : false;

        if (RU_language_selected == true) {
            RU_language = true;
            Selected_RU.SetActive(true);
            Debug.Log("RU selected");
        } else {
            RU_language = false;
            Selected_RU.SetActive(false);
        }
        if (ENG_language_selected == true) {
            ENG_language = true;
            Selected_ENG.SetActive(true);
            Debug.Log("ENG selected");
        } else {
            ENG_language = false;
            Selected_ENG.SetActive(false);
        }

    }

    void Update() {
        if (RU_language_selected == true) {
            RU_language = true;
            Choose_Discipline.SetText("Выбирете дисцыплину");
        } else {
            RU_language = false;
        }
        if (ENG_language_selected == true) {
            ENG_language = true;
            Choose_Discipline.SetText("Choose Discipline");
        } else {
            ENG_language = false;
        }
    }

    public void SelectRULanguage() {
        Debug.Log("RU selected");
        ENG_language_selected = false;
        RU_language_selected = true;
        Selected_ENG.SetActive(false);
        Selected_RU.SetActive(true);
        PlayerPrefs.SetInt("RULanguage", RU_language_selected ? 1 : 0);
        PlayerPrefs.SetInt("ENGLanguage", ENG_language_selected ? 1 : 0);
    }
    public void SelectENGLanguage() {
        Debug.Log("ENG selected");
        RU_language_selected = false;
        ENG_language_selected = true;
        Selected_ENG.SetActive(true);
        Selected_RU.SetActive(false);
        isDefault = 1;
        PlayerPrefs.SetInt("DefaultLanguage", isDefault);
        PlayerPrefs.SetInt("ENGLanguage", ENG_language_selected ? 1 : 0);
        PlayerPrefs.SetInt("RULanguage", RU_language_selected ? 1 : 0);
    }
}
