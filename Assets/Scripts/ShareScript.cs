using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class ShareScript : MonoBehaviour
{
    // public
    // private
    public GameObject CanvasShareObj;
    public GameObject CanvasResult;
    [SerializeField] private GameObject img_background;
    [SerializeField] private TextMeshProUGUI CorrectAnswerText;
    [SerializeField] private TextMeshProUGUI PlayerSkillScoreText;
    private bool isProcessing = false;
    public string mensaje;
    private string ANDROID_RATE_LINK = "market://details?id=com.SeFF.QuizOfCyberSport";



void Start()
{
    if (LanguageManager.RU_language_selected == true){
        mensaje = "Сможешь побить мой рекорд?" + " " + ANDROID_RATE_LINK;
    } else{
        mensaje = "Can you beat my score?" + " "  + ANDROID_RATE_LINK;
    }
    Debug.Log(mensaje);
}

    //function called from a button
    public void ButtonShare()
    {
        if (!isProcessing)
        {
            Color background = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            img_background.GetComponent<Image>().color = background;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2"))
            {
                CorrectAnswerText.text = Dota2Q.CorrectAnswer + " / 10";
                if (Dota2Q.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                }
                if (Dota2Q.CorrectAnswer >= 4 && Dota2Q.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                }
                if (Dota2Q.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO"))
            {
                CorrectAnswerText.text = CSGOQ.CorrectAnswer + " / 10";
                if (CSGOQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                }
                if (CSGOQ.CorrectAnswer >= 4 && CSGOQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (CSGOQ.CorrectAnswer >= 7 && CSGOQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                }
                if (CSGOQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone"))
            {
                CorrectAnswerText.text = HearthStoneQ.CorrectAnswer + " / 10";
                if (HearthStoneQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                }
                if (HearthStoneQ.CorrectAnswer >= 4 && HearthStoneQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (HearthStoneQ.CorrectAnswer >= 7 && HearthStoneQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                }
                if (HearthStoneQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG"))
            {
                CorrectAnswerText.text = PUBGQ.CorrectAnswer + " / 10";
                if (PUBGQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                }
                if (PUBGQ.CorrectAnswer >= 4 && PUBGQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (PUBGQ.CorrectAnswer >= 7 && PUBGQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                }
                if (PUBGQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                }
            }
            CanvasShareObj.SetActive(true);
            StartCoroutine(ShareScreenshot());
        }
    }
    public IEnumerator ShareScreenshot()
    {
        isProcessing = true;
        // wait for graphics to render
        yield return new WaitForEndOfFrame();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        // create the texture
        Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
        // put buffer into texture
        screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height), 0, 0);
        // apply
        screenTexture.Apply();
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- PHOTO
        byte[] dataToSave = screenTexture.EncodeToPNG();
        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        File.WriteAllBytes(destination, dataToSave);
        if (!Application.isEditor)
        {
            // block to open the file and share it ------------START
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);

            intentObject.Call<AndroidJavaObject>("setType", "text/plain");
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), "" + mensaje);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), "Can you beat my score?");

            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);
        }
        isProcessing = false;
    }
}