using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{

//Панель результатов
    [SerializeField] private TextMeshProUGUI CorrectAnswerText;
    [SerializeField] private TextMeshProUGUI PlayerSkillScoreText;
    [SerializeField] private TextMeshProUGUI Result_text;
    [SerializeField] private TextMeshProUGUI NextBtn;
    [SerializeField] private TextMeshProUGUI MoreQuestion;
//Панель результатов скрин
    [SerializeField] private TextMeshProUGUI _CorrectAnswerText;
    [SerializeField] private TextMeshProUGUI _PlayerSkillScoreText;
    [SerializeField] private TextMeshProUGUI _Result_text;
    [SerializeField] private TextMeshProUGUI _NextBtn;
    [SerializeField] private TextMeshProUGUI _MoreQuestion;

    void Update()
    {
        if (LanguageManager.RU_language_selected == true)
        {
            MoreQuestion.text = "Хотите больше вопросов ?";
            _MoreQuestion.text = "Хотите больше вопросов ?";
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/10";
                _CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/10";
                if (Dota2Q.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы новичок в этой игре";
                    _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (Dota2Q.CorrectAnswer >= 4 && Dota2Q.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы опытный игрок";
                    _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы опытный игрок";
                }
                if (Dota2Q.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы профи в этой игре!";
                    _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы опытный игрок";
                }
                #endregion
                #region 20 Вопросов
                if (Dota2Q.OpenQuestion == true)
                {
                    CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/20";
                    _CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/20";
                    if (Dota2Q.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы новичок в этой игре";
                        _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                        _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (Dota2Q.CorrectAnswer >= 10 && Dota2Q.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы опытный игрок";
                        _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (Dota2Q.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы профи в этой игре!";
                        _PlayerSkillScoreText.text = "Dota2\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = CSGOQ.CorrectAnswer + "/10";
                if (CSGOQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (CSGOQ.CorrectAnswer >= 4 && CSGOQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (CSGOQ.CorrectAnswer >= 7 && CSGOQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы опытный игрок";
                }
                if (CSGOQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (CSGOQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = CSGOQ.CorrectAnswer + "/20";
                    if (CSGOQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (CSGOQ.CorrectAnswer >= 7 && CSGOQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (CSGOQ.CorrectAnswer >= 10 && CSGOQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (CSGOQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "CSGO\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = HearthStoneQ.CorrectAnswer + "/10";
                if (HearthStoneQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (HearthStoneQ.CorrectAnswer >= 4 && HearthStoneQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (HearthStoneQ.CorrectAnswer >= 7 && HearthStoneQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы опытный игрок";
                }
                if (HearthStoneQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (HearthStoneQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = HearthStoneQ.CorrectAnswer + "/20";
                    if (HearthStoneQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 7 && HearthStoneQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 10 && HearthStoneQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = PUBGQ.CorrectAnswer + "/10";
                if (PUBGQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (PUBGQ.CorrectAnswer >= 4 && PUBGQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (PUBGQ.CorrectAnswer >= 7 && PUBGQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы опытный игрок";
                }
                if (PUBGQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (PUBGQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = PUBGQ.CorrectAnswer + "/20";
                    if (PUBGQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (PUBGQ.CorrectAnswer >= 7 && PUBGQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (PUBGQ.CorrectAnswer >= 10 && PUBGQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (PUBGQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "PUBG\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = OverwatchQ.CorrectAnswer + "/10";
                if (OverwatchQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (OverwatchQ.CorrectAnswer >= 4 && OverwatchQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (OverwatchQ.CorrectAnswer >= 7 && OverwatchQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы опытный игрок";
                }
                if (OverwatchQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (OverwatchQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = OverwatchQ.CorrectAnswer + "/20";
                    if (OverwatchQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (OverwatchQ.CorrectAnswer >= 7 && OverwatchQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (OverwatchQ.CorrectAnswer >= 10 && OverwatchQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (OverwatchQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTanks"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = WOTQ.CorrectAnswer + "/10";
                if (WOTQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (WOTQ.CorrectAnswer >= 4 && WOTQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (WOTQ.CorrectAnswer >= 7 && WOTQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы опытный игрок";
                }
                if (WOTQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (WOTQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = WOTQ.CorrectAnswer + "/20";
                    if (WOTQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (WOTQ.CorrectAnswer >= 7 && WOTQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (WOTQ.CorrectAnswer >= 10 && WOTQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (WOTQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fortnite"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = FortniteQ.CorrectAnswer + "/10";
                if (FortniteQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (FortniteQ.CorrectAnswer >= 4 && FortniteQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (FortniteQ.CorrectAnswer >= 7 && FortniteQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы опытный игрок";
                }
                if (FortniteQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (FortniteQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = FortniteQ.CorrectAnswer + "/20";
                    if (FortniteQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (FortniteQ.CorrectAnswer >= 7 && FortniteQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (FortniteQ.CorrectAnswer >= 10 && FortniteQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (FortniteQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rainbow Six Seige"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = RSSQ.CorrectAnswer + "/10";
                if (FortniteQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы новичок в этой игре";
                }
                if (RSSQ.CorrectAnswer >= 4 && RSSQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                }
                if (RSSQ.CorrectAnswer >= 7 && RSSQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы опытный игрок";
                }
                if (RSSQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы профи в этой игре!";
                }
                #endregion
                #region 20 Вопросов
                if (RSSQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = RSSQ.CorrectAnswer + "/20";
                    if (RSSQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы новичок в этой игре";
                    }
                    if (RSSQ.CorrectAnswer >= 7 && RSSQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы довольно хорошо знаете эту игру";
                    }
                    if (RSSQ.CorrectAnswer >= 10 && RSSQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы опытный игрок";
                    }
                    if (RSSQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nОценка вашего скилла: Вы профи в этой игре!";
                    }
                }
                #endregion
            }
            Result_text.SetText("Результат");
            NextBtn.SetText("Продолжить");
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            MoreQuestion.text = "Want more questions?";
            _MoreQuestion.text = "Want more questions?";
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Dota2"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/10";
                _CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/10";
                if (Dota2Q.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are new to this game.";
                    _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are new to this game.";
                }
                if (Dota2Q.CorrectAnswer >= 4 && Dota2Q.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Dota2\nYour skill rating: You know this game pretty well.";
                    _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You know this game pretty well.";
                }
                if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are an experienced player";
                    _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are an experienced player";
                }
                if (Dota2Q.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are a pro in this game!";
                    _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (Dota2Q.OpenQuestion == true)
                {
                    CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/20";
                    _CorrectAnswerText.text = Dota2Q.CorrectAnswer + "/20";
                    if (Dota2Q.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are new to this game.";
                        _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are new to this game.";
                    }
                    if (Dota2Q.CorrectAnswer >= 7 && Dota2Q.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Dota2\nYour skill rating: You know this game pretty well.";
                        _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You know this game pretty well.";
                    }
                    if (Dota2Q.CorrectAnswer >= 10 && Dota2Q.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are an experienced player";
                        _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are an experienced player";
                    }
                    if (Dota2Q.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are a pro in this game!";
                        _PlayerSkillScoreText.text = "Dota2\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("CSGO"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = CSGOQ.CorrectAnswer + "/10";
                if (CSGOQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are new to this game.";
                }
                if (CSGOQ.CorrectAnswer >= 4 && CSGOQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "CSGO\nYour skill rating: You know this game pretty well.";
                }
                if (CSGOQ.CorrectAnswer >= 7 && CSGOQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are an experienced player";
                }
                if (CSGOQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (CSGOQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = CSGOQ.CorrectAnswer + "/20";
                    if (CSGOQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are new to this game.";
                    }
                    if (CSGOQ.CorrectAnswer >= 7 && CSGOQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "CSGO\nYour skill rating: You know this game pretty well.";
                    }
                    if (CSGOQ.CorrectAnswer >= 10 && CSGOQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are an experienced player";
                    }
                    if (CSGOQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "CSGO\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("HearthStone"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = HearthStoneQ.CorrectAnswer + "/10";
                if (HearthStoneQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are new to this game.";
                }
                if (HearthStoneQ.CorrectAnswer >= 4 && HearthStoneQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You know this game pretty well.";
                }
                if (HearthStoneQ.CorrectAnswer >= 7 && HearthStoneQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are an experienced player";
                }
                if (HearthStoneQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (HearthStoneQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = HearthStoneQ.CorrectAnswer + "/20";
                    if (HearthStoneQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are new to this game.";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 7 && HearthStoneQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You know this game pretty well.";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 10 && HearthStoneQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are an experienced player";
                    }
                    if (HearthStoneQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "HearthStone\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("PUBG"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = PUBGQ.CorrectAnswer + "/10";
                if (PUBGQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are new to this game.";
                }
                if (PUBGQ.CorrectAnswer >= 4 && PUBGQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "PUBG\nYour skill rating: You know this game pretty well.";
                }
                if (PUBGQ.CorrectAnswer >= 7 && PUBGQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are an experienced player";
                }
                if (PUBGQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (PUBGQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = PUBGQ.CorrectAnswer + "/20";
                    if (PUBGQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are new to this game.";
                    }
                    if (PUBGQ.CorrectAnswer >= 7 && PUBGQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "PUBG\nYour skill rating: You know this game pretty well.";
                    }
                    if (PUBGQ.CorrectAnswer >= 10 && PUBGQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are an experienced player";
                    }
                    if (PUBGQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "PUBG\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Overwatch"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = OverwatchQ.CorrectAnswer + "/10";
                if (OverwatchQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are new to this game.";
                }
                if (OverwatchQ.CorrectAnswer >= 4 && OverwatchQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You know this game pretty well.";
                }
                if (OverwatchQ.CorrectAnswer >= 7 && OverwatchQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are an experienced player";
                }
                if (OverwatchQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (OverwatchQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = OverwatchQ.CorrectAnswer + "/20";
                    if (OverwatchQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are new to this game.";
                    }
                    if (OverwatchQ.CorrectAnswer >= 7 && OverwatchQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You know this game pretty well.";
                    }
                    if (OverwatchQ.CorrectAnswer >= 10 && OverwatchQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are an experienced player";
                    }
                    if (OverwatchQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Overwatch\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldOfTanks"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = WOTQ.CorrectAnswer + "/10";
                if (WOTQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are new to this game.";
                }
                if (WOTQ.CorrectAnswer >= 4 && WOTQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You know this game pretty well.";
                }
                if (WOTQ.CorrectAnswer >= 7 && WOTQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are an experienced player";
                }
                if (WOTQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (WOTQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = WOTQ.CorrectAnswer + "/20";
                    if (WOTQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are new to this game.";
                    }
                    if (WOTQ.CorrectAnswer >= 7 && WOTQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You know this game pretty well.";
                    }
                    if (WOTQ.CorrectAnswer >= 10 && WOTQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are an experienced player";
                    }
                    if (WOTQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "WorldOfTanks\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Fortnite"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = FortniteQ.CorrectAnswer + "/10";
                if (FortniteQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are new to this game.";
                }
                if (FortniteQ.CorrectAnswer >= 4 && FortniteQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You know this game pretty well.";
                }
                if (FortniteQ.CorrectAnswer >= 7 && FortniteQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are an experienced player";
                }
                if (FortniteQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (FortniteQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = FortniteQ.CorrectAnswer + "/20";
                    if (FortniteQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are new to this game.";
                    }
                    if (FortniteQ.CorrectAnswer >= 7 && FortniteQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You know this game pretty well.";
                    }
                    if (FortniteQ.CorrectAnswer >= 10 && FortniteQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are an experienced player";
                    }
                    if (FortniteQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Fortnite\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Rainbow Six Seige"))
            {
                #region 10 Вопросов
                CorrectAnswerText.text = RSSQ.CorrectAnswer + "/10";
                if (RSSQ.CorrectAnswer <= 3)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are new to this game.";
                }
                if (RSSQ.CorrectAnswer >= 4 && RSSQ.CorrectAnswer <= 6)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You know this game pretty well.";
                }
                if (RSSQ.CorrectAnswer >= 7 && RSSQ.CorrectAnswer <= 8)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are an experienced player";
                }
                if (RSSQ.CorrectAnswer >= 9)
                {
                    PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are a pro in this game!";
                }
                #endregion
                #region 20 Вопросов
                if (RSSQ.OpenQuestion == true)
                {
                    CorrectAnswerText.text = RSSQ.CorrectAnswer + "/20";
                    if (RSSQ.CorrectAnswer <= 6)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are new to this game.";
                    }
                    if (RSSQ.CorrectAnswer >= 7 && RSSQ.CorrectAnswer <= 9)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You know this game pretty well.";
                    }
                    if (RSSQ.CorrectAnswer >= 10 && RSSQ.CorrectAnswer <= 14)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are an experienced player";
                    }
                    if (RSSQ.CorrectAnswer >= 15)
                    {
                        PlayerSkillScoreText.text = "Rainbow Six Seige\nYour skill rating: You are a pro in this game!";
                    }
                }
                #endregion
            }
            Result_text.SetText("Result");
            NextBtn.SetText("Continue");
        }
    }
}
