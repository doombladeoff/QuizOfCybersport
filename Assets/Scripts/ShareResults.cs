using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class ShareResults : MonoBehaviour
{
    public GameObject CanvasShareObj;
    public GameObject CanvasResult;
    [SerializeField] private GameObject img_background;
    [SerializeField] private TextMeshProUGUI CorrectAnswerText;
    [SerializeField] private TextMeshProUGUI PlayerSkillScoreText;

    private bool isProcessing = false;
    private bool isFocus = false;
    public string mensaje;
    private string ANDROID_RATE_LINK;
    
    void Start() {
    if (LanguageManager.RU_language_selected == true){
        ANDROID_RATE_LINK = "https://play.google.com/store/apps/details?id=com.SeFF.QuizOfCyberSport";
        mensaje = "Сможешь побить мой рекорд?" + " " + ANDROID_RATE_LINK;
    } else {
        ANDROID_RATE_LINK = "https://play.google.com/store/apps/details?id=com.SeFF.QuizOfCyberSport&hl=en";
        mensaje = "Can you beat my score?" + " "  + ANDROID_RATE_LINK;
        }
    }
    public void ShareBtnPress()
    {
        if (!isProcessing)
        {
            Color background = new Color( Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            img_background.GetComponent<Image>().color = background;
            #region 
            /*if(LanguageManager.RU_language_selected == true){
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2"))
                {
                    CorrectAnswerText.text = Dota2Q.CorrectAnswer + " / 10";
                    if (Dota2Q.CorrectAnswer <= 3)
                    {
                        PlayerSkillScoreText.text = "Dota2<br>Оценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (Dota2Q.CorrectAnswer >= 4 && Dota2Q.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Dota2<br>Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 8)
                    {
                        PlayerSkillScoreText.text = "Dota2<br>Оценка вашего скилла: Вы опытный игрок";
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
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch"))
                {
                    CorrectAnswerText.text = OverwatchQ.CorrectAnswer + " / 10";
                    if (OverwatchQ.CorrectAnswer <= 3)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (OverwatchQ.CorrectAnswer >= 4 && OverwatchQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (OverwatchQ.CorrectAnswer >= 7 && OverwatchQ.CorrectAnswer <= 8)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                    }
                    if (OverwatchQ.CorrectAnswer >= 9)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTanks"))
                {
                    CorrectAnswerText.text = WOTQ.CorrectAnswer + " / 10";
                    if (WOTQ.CorrectAnswer <= 3)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (WOTQ.CorrectAnswer >= 4 && WOTQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (WOTQ.CorrectAnswer >= 7 && WOTQ.CorrectAnswer <= 8)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы опытный игрок";
                    }
                    if (WOTQ.CorrectAnswer >= 9)
                    {
                        PlayerSkillScoreText.text = "Оценка вашего скилла: Вы профи в этой игре!";
                    }
                }
            }
            */
            #endregion
           // CanvasResult.SetActive(false);
            CanvasShareObj.SetActive(true);
            StartCoroutine(ShareScreenshot());
        }
    }

    IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        yield return new WaitForEndOfFrame();

        //Application.CaptureScreenshot("screenshot.png", 2);
        UnityEngine.ScreenCapture.CaptureScreenshot("screenshot.png", 2);
        string destination = Path.Combine(Application.persistentDataPath, "screenshot.png");

        yield return new WaitForSecondsRealtime(0.3f);

        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                mensaje);
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);
        }

        yield return new WaitUntil(() => isFocus);
        CanvasShareObj.SetActive(false);
       // CanvasResult.SetActive(true);
        isProcessing = false;
    }

    private void OnApplicationFocus(bool focus)
    {
        isFocus = focus;
    }
}
