using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RSSQ : MonoBehaviour
{
    //ПАНЕЛЬ С РЕЗУЛЬТАТОМ
    [Header("Паенль результатов")]
    [SerializeField] private GameObject ResultPanel;

    //ПАНЕЛЬ ВОПРОСОВ
    [Header("Паенль вопросов")]
    [SerializeField] private GameObject QuestionPanel;

    // КОЛИЧЕСТВО ВОПРОСОВ
    public static int QUIZ_COUNT = 10;

    // КНОПКИ С ОТВЕТАМИ 
    [Header("Текст ответов на кнопке")]
    [SerializeField] private TextMeshProUGUI answerBtn1;
    [SerializeField] private TextMeshProUGUI answerBtn2;
    [SerializeField] private TextMeshProUGUI answerBtn3;

    [Header("Кнопки")]
    [SerializeField] private TextMeshProUGUI button1;
    [SerializeField] private TextMeshProUGUI button2;
    [SerializeField] private TextMeshProUGUI button3;
    [SerializeField] private Button button_1;
    [SerializeField] private Button button_2;
    [SerializeField] private Button button_3;

    // ТЕКСТ ВОПРОСА
    [SerializeField] private TextMeshProUGUI question_text;
    // ВОПРОСЫ-ОТВЕТЫ
    public static int randm = -1;
    public bool[] lockedQuestion = new bool[20];
    private static readonly string[] question = new string[20];
    private static readonly string[] answer = new string[60];

    //КОЛИЧЕСТВО ПРАВИЛЬНЫХ ОТВЕТОВ
    public static int CorrectAnswer = 0;

    //ВЫЗОВ МЕТОДА 1 РАЗ
    private bool isWork = true;
    public static bool OpenQuestion = false;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        randm = -1;
        QUIZ_COUNT = 10;
        CorrectAnswer = 0;
        OpenQuestion = PlayerPrefs.GetInt("RSSQOpenQuestion") == 1 ? true : false;
        
        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("RSSQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Вопрос # 1 - Какая операция стала первым дополнением / расширением после выхода игры?";
            question[1] = "Вопрос # 2 - На церемонии награждения критиков 2014 года игра была номинирована в четырех категориях. Какой из них выиграл?";
            question[2] = "Вопрос # 3. Как называется многопользовательский режим, в котором защитники защищают комнату с контейнером биологической опасности?";
            question[3] = "Вопрос # 4- Как называется команда Террористической Организации Шестого, которая собирается победить?";
            question[4] = "Вопрос # 5. Как называется университет, в котором белые маски начинают химическую атаку?";
            question[5] = "Вопрос # 6 - На старте Сколько карт было в игре Rainbow Six Siege от Tom Clancy?";
            question[6] = "Вопрос # 7 - Самый последний пакет дополнений к игре (март 2019 г.) включал набор карт в какой стране Океании?";
            question[7] = "Вопрос # 8 - Анжела Бассетт озвучила какой женский персонаж?В";
            question[8] = "Вопрос # 9 - На старте игры, где она дебютировала в британской программе Software Chart?";
            question[9] = "Вопрос # 10. Какой из этих контртеррористических подразделений нельзя использовать?";
            question[10] = "Вопрос # 11. Какой российский оператор НЕ родился в России?";
            question[11] = "Вопрос # 12. Какой стране служит Эла?";
            question[12] = "Вопрос # 13 - Какой оператор родился в Израиле?";
            question[13] = "Вопрос # 14 - Какой оператор был взят из тюрьмы для участия в Team Rainbow?";
            question[14] = "Вопрос # 15 - Как называется Санки при рождении?";
            question[15] = "Вопрос # 16 - Какой оператор электрифицирует усиленные стены, чтобы остановить пробивающие раунды и / или пробивающие заряды?";
            question[16] = "Вопрос # 17 - Какой оператор профессионально обучен использованию мотоцикла?";
            question[17] = "Вопрос # 18 - Какая карта была основана на реальной спецоперации?";
            question[18] = "Вопрос # 19 - Какой оператор прозвище «Господь» или «Бог»?";
            question[19] = "Вопрос # 20 - Какой оператор был нерфирован, усилен, чем повторно, но никто на самом деле не заметил?";

// Ответы на вопрос 0
            answer[0] = "Операция Линия Пыли";
            answer[1] = "Операция Химера";
            answer[2] = "Операция Черный Лед"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Best of Show";
            answer[4] = "Лучшая игра для ПК"; // <----- TRUE
            answer[5] = "Лучшая многопользовательская онлайн игра";
            // Ответы на вопрос 2
            answer[6] = "Опасность";
            answer[7] = "Безопасная зона";// <----- TRUE
            answer[8] = "Контейнер";
            // Ответы на вопрос 3
            answer[9] = "Белые Маски";// <----- TRUE
            answer[10] = "Красные Маски";
            answer[11] = "Зеленые маски";
            // Ответы на вопрос 4
            answer[12] = "Университет Пайн Хилл";
            answer[13] = "Университет Саванны";
            answer[14] = "Университет Бартлетт";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "11";// <----- TRUE
            answer[16] = "10";
            answer[17] = "9";
            // Ответы на вопрос 6
            answer[18] = "Новая Зеландия";
            answer[19] = "Австралия";// <----- TRUE
            answer[20] = "Vanuatu";
            // Ответы на вопрос 7
            answer[21] = "Twitch";
            answer[22] = "Six";// <----- TRUE
            answer[23] = "Ash";
            // Ответы на вопрос 8
            answer[24] = "Восьмой";
            answer[25] = "четвертый";
            answer[26] = "шестой";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "Итальянский AT-PI";// <----- TRUE
            answer[28] = "Британский SAS";
            answer[29] = "Русский Спецназ";
            // Ответы на вопрос 10
            answer[30] = "Kapkan";
            answer[31] = "Fuze";// <----- TRUE
            answer[32] = "Tachanka";
            // Ответы на вопрос 11
            answer[33] = "Россия";
            answer[34] = "Австрия";
            answer[35] = "Польша";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "Эш";// <----- TRUE
            answer[37] = "Кавейра";
            answer[38] = "Слэдж";
            // Ответы на вопрос 13
            answer[39] = "Лев";// <----- TRUE
            answer[40] = "Капкан";
            answer[41] = "Борода";
            // Ответы на вопрос 14
            answer[42] = "Жиль Туре";
            answer[43] = "Симус Кауден";// <----- TRUE
            answer[44] = "Джеймс Портер";
            // Ответы на вопрос 15
            answer[45] = "Jager";
            answer[46] = "Замок";
            answer[47] = "Bandit";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "Моззи";// <----- TRUE
            answer[49] = "Замок";
            answer[50] = "эхо";
            // Ответы на вопрос 17
            answer[51] = "Орегон";
            answer[52] = "Кафе Достоевский";// <----- TRUE
            answer[53] = "Дом";
            // Ответы на вопрос 18
            answer[54] = "Tachanka";// <----- TRUE
            answer[55] = "Dokkaebi";
            answer[56] = "Maverick";
            // Ответы на вопрос 19
            answer[57] = "Capitao";// <----- TRUE
            answer[58] = "Dokkaebi";
            answer[59] = "Bandit";
            #endregion
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Question # 1- Which Operation Became The First DLC/Expansion After The Game's Release?";
            question[1] = "Question # 2- At The 2014 Critics Awards, The Game Was Nominated In These Four Categories. Which One Did It Win?";
            question[2] = "Question # 3- What Is The Name Of The Multiplayer Mode, Where Defenders Protect A Room With A Biohazard Container?";
            question[3] = "Question # 4- What Is The Name Of The Terrorist Organisation Six's Team Is Aiming To Take Down?";
            question[4] = "Question # 5- What Is The Name Of The University The White Masks Launch A Chemical Attack On?";
            question[5] = "Question # 6- At Launch, How Many Maps Did Tom Clancy's Rainbow Six Siege Feature?";
            question[6] = "Question # 7- The Game's Most Recent Expansion Pack (March, 2019) Included A Map Set In Which Oceanian Country?";
            question[7] = "Question # 8- Angela Bassett Voiced Which Female Character?";
            question[8] = "Question # 9- At The Game's Launch, Where Did It Debut In The UK Software Chart?";
            question[9] = "Question # 10- Which Of These Counter-Terrorism Units Cannot Be Played As?";
            question[10] = "Question # 11- What Russian operator was NOT born in Russia?";
            question[11] = "Question # 12- What country does Ela serve?";
            question[12] = "Question # 13- What operator was born in Israel?";
            question[13] = "Question # 14- What operator was taken from prison to be initiated into Team Rainbow?";
            question[14] = "Question # 15- What is the birth name of Sledge?";
            question[15] = "Question # 16- What operator electrifies reinforced walls to stop breaching rounds and/or breach charges?";
            question[16] = "Question # 17- What operator is professionally trained to use a motorcycle?";
            question[17] = "Question # 18- What map was based off a real-life special ops mission?";
            question[18] = "Question # 19- What operators nickname is 'The LORD' or 'God'?";
            question[19] = "Question # 20- What operator was nerfed, buffed, than re-nerfed but no one really noticed?";

            // Ответы на вопрос 0
            answer[0] = "Operation Dust Line";
            answer[1] = "Operation Chimera";
            answer[2] = "Operation Black Ice"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Best of Show";
            answer[4] = "Best PC Game"; // <----- TRUE
            answer[5] = "Best Online Multiplayer Game";
            // Ответы на вопрос 2
            answer[6] = "Hazard";
            answer[7] = "Secure Area";// <----- TRUE
            answer[8] = "Container";
            // Ответы на вопрос 3
            answer[9] = "The White Masks";// <----- TRUE
            answer[10] = "The Red Masks";
            answer[11] = "The Green Masks";
            // Ответы на вопрос 4
            answer[12] = "Pine Hill University";
            answer[13] = "Savanna University";
            answer[14] = "Bartlett University";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "11";// <----- TRUE
            answer[16] = "10";
            answer[17] = "9";
            // Ответы на вопрос 6
            answer[18] = "New Zealand";
            answer[19] = "Australia";// <----- TRUE
            answer[20] = "Vanuatu";
            // Ответы на вопрос 7
            answer[21] = "Twitch";
            answer[22] = "Six";// <----- TRUE
            answer[23] = "Ash";
            // Ответы на вопрос 8
            answer[24] = "Eighth";
            answer[25] = "Fourth";
            answer[26] = "Sixth";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "Italian AT-PI";// <----- TRUE
            answer[28] = "British SAS";
            answer[29] = "Russian Spetsnaz";
            // Ответы на вопрос 10
            answer[30] = "Kapkan";
            answer[31] = "Fuze";// <----- TRUE
            answer[32] = "Tachanka";
            // Ответы на вопрос 11
            answer[33] = "Russia";
            answer[34] = "Austria";
            answer[35] = "Poland";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "Ash";// <----- TRUE
            answer[37] = "Caveira";
            answer[38] = "Sledge";
            // Ответы на вопрос 13
            answer[39] = "Lion";// <----- TRUE
            answer[40] = "Kapkan";
            answer[41] = "Blackbeard";
            // Ответы на вопрос 14
            answer[42] = "Gilles Toure";
            answer[43] = "Seamus Cowden";// <----- TRUE
            answer[44] = "James Porter";
            // Ответы на вопрос 15
            answer[45] = "Jager";
            answer[46] = "Castle";
            answer[47] = "Bandit";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "Mozzie";// <----- TRUE
            answer[49] = "Castle";
            answer[50] = "Echo";
            // Ответы на вопрос 17
            answer[51] = "Oregon";
            answer[52] = "Kafe Dostoyevsky";// <----- TRUE
            answer[53] = "House";
            // Ответы на вопрос 18
            answer[54] = "Tachanka";// <----- TRUE
            answer[55] = "Dokkaebi";
            answer[56] = "Maverick";
            // Ответы на вопрос 19
            answer[57] = "Capitao";// <----- TRUE
            answer[58] = "Dokkaebi";
            answer[59] = "Bandit";
            #endregion
        }
        button_1.onClick.AddListener(IncorrectAnswer);
        button_2.onClick.AddListener(IncorrectAnswer);
        button_3.onClick.AddListener(TaskOnClick);
        GenarateRandomQuestion();
    }
    void Update()
    {
        if (QUIZ_COUNT <= 0)
        {
            //RateManager.PassedTheTest += 1;
            QuestionPanel.SetActive(false);
            ResultPanel.SetActive(true);
            if (isWork == true)
            {
                CallMethodOnce();
            }
        }
    }

    void CallMethodOnce()
    {
        RateManager.PassedTheTest += 1;
        Debug.Log("Passed the Test: " + RateManager.PassedTheTest);
        isWork = false;
    }

    public void GenarateRandomQuestion()
    {
        randm += 1;
        Debug.Log("Current question # " + randm);
        ShowNextQuestion();
        button_1.interactable = true;
        button_2.interactable = true;
        button_3.interactable = true;
        button_1.GetComponent<Image>().color = Color.white;
        button_2.GetComponent<Image>().color = Color.white;
        button_3.GetComponent<Image>().color = Color.white;
    }
    public void NextQuestion()
    {
        //GenarateRandomQuestion();
        QUIZ_COUNT -= 1;
        Debug.Log(QUIZ_COUNT);
        button_1.interactable = false;
        button_2.interactable = false;
        button_3.interactable = false;
        Invoke("GenarateRandomQuestion", 1f);
    }
    public void ShowNextQuestion()
    {
        //ВОПРОС 0
        if (randm == 0 && lockedQuestion[0] == false)
        {
            question_text.text = question[0];
            answerBtn1.text = answer[0];
            answerBtn2.text = answer[1];
            answerBtn3.text = answer[2];
            lockedQuestion[0] = true;

        }
        //ВОПРОС 1
        if (randm == 1 && lockedQuestion[1] == false)
        {
            question_text.text = question[1];
            answerBtn1.text = answer[3];
            answerBtn2.text = answer[4];
            answerBtn3.text = answer[5];
            lockedQuestion[1] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            button_1.onClick.AddListener(IncorrectAnswer);
            button_2.onClick.AddListener(TaskOnClick);
            button_3.onClick.AddListener(IncorrectAnswer);
            //button_3.onClick.RemoveListener(TaskOnClick);

        }
        //ВОПРОС 2
        else if (randm == 2 && lockedQuestion[2] == false)
        {
            question_text.text = question[2];
            answerBtn1.text = answer[6];
            answerBtn2.text = answer[7];
            answerBtn3.text = answer[8];
            lockedQuestion[2] = true;
        }
        //ВОПРОС 3
        else if (randm == 3 && lockedQuestion[3] == false)
        {
            question_text.text = question[3];
            answerBtn1.text = answer[9];
            answerBtn2.text = answer[10];
            answerBtn3.text = answer[11];
            lockedQuestion[3] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_2.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 4
        else if (randm == 4 && lockedQuestion[4] == false)
        {
            question_text.text = question[4];
            answerBtn1.text = answer[12];
            answerBtn2.text = answer[13];
            answerBtn3.text = answer[14];
            lockedQuestion[4] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            // button_1.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(TaskOnClick);
        }
        //ВОПРОС 5
        else if (randm == 5 && lockedQuestion[5] == false)
        {
            question_text.text = question[5];
            answerBtn1.text = answer[15];
            answerBtn2.text = answer[16];
            answerBtn3.text = answer[17];
            lockedQuestion[5] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            // button_3.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 6
        else if (randm == 6 && lockedQuestion[6] == false)
        {
            question_text.text = question[6];
            answerBtn1.text = answer[18];
            answerBtn2.text = answer[19];
            answerBtn3.text = answer[20];
            lockedQuestion[6] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_1.onClick.RemoveListener(TaskOnClick);
            button_2.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 7
        else if (randm == 7 && lockedQuestion[7] == false)
        {
            question_text.text = question[7];
            answerBtn1.text = answer[21];
            answerBtn2.text = answer[22];
            answerBtn3.text = answer[23];
            lockedQuestion[7] = true;
        }
        //ВОПРОС 8
        else if (randm == 8 && lockedQuestion[8] == false)
        {
            question_text.text = question[8];
            answerBtn1.text = answer[24];
            answerBtn2.text = answer[25];
            answerBtn3.text = answer[26];
            lockedQuestion[8] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_2.onClick.RemoveListener(TaskOnClick);
            button_3.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_2.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 9
        else if (randm == 9 && lockedQuestion[9] == false)
        {
            question_text.text = question[9];
            answerBtn1.text = answer[27];
            answerBtn2.text = answer[28];
            answerBtn3.text = answer[29];
            lockedQuestion[9] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_3.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 10
        else if (randm == 10 && lockedQuestion[10] == false)
        {
            question_text.text = question[10];
            answerBtn1.text = answer[30];
            answerBtn2.text = answer[31];
            answerBtn3.text = answer[32];
            lockedQuestion[10] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            // button_3.onClick.RemoveListener(TaskOnClick);
            button_2.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 11
        else if (randm == 11 && lockedQuestion[11] == false)
        {
            question_text.text = question[11];
            answerBtn1.text = answer[33];
            answerBtn2.text = answer[34];
            answerBtn3.text = answer[35];
            lockedQuestion[11] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_2.onClick.RemoveListener(TaskOnClick);
            button_3.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_2.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 12
        else if (randm == 12 && lockedQuestion[12] == false)
        {
            question_text.text = question[12];
            answerBtn1.text = answer[36];
            answerBtn2.text = answer[37];
            answerBtn3.text = answer[38];
            lockedQuestion[12] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            // button_3.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 13
        else if (randm == 13 && lockedQuestion[13] == false)
        {
            question_text.text = question[13];
            answerBtn1.text = answer[39];
            answerBtn2.text = answer[40];
            answerBtn3.text = answer[41];
            lockedQuestion[13] = true;
        }
        //ВОПРОС 14
        else if (randm == 14 && lockedQuestion[14] == false)
        {
            question_text.text = question[14];
            answerBtn1.text = answer[42];
            answerBtn2.text = answer[43];
            answerBtn3.text = answer[44];
            lockedQuestion[14] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_1.onClick.RemoveListener(TaskOnClick);
            button_2.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 15
        else if (randm == 15 && lockedQuestion[15] == false)
        {
            question_text.text = question[15];
            answerBtn1.text = answer[45];
            answerBtn2.text = answer[46];
            answerBtn3.text = answer[47];
            lockedQuestion[15] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_2.onClick.RemoveListener(TaskOnClick);
            button_3.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_2.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 16
        else if (randm == 16 && lockedQuestion[16] == false)
        {
            question_text.text = question[16];
            answerBtn1.text = answer[48];
            answerBtn2.text = answer[49];
            answerBtn3.text = answer[50];
            lockedQuestion[16] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            // button_3.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 17
        else if (randm == 17 && lockedQuestion[17] == false)
        {
            question_text.text = question[17];
            answerBtn1.text = answer[51];
            answerBtn2.text = answer[52];
            answerBtn3.text = answer[53];
            lockedQuestion[17] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_1.onClick.RemoveListener(TaskOnClick);
            button_2.onClick.AddListener(TaskOnClick);
            button_1.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 18
        else if (randm == 18 && lockedQuestion[18] == false)
        {
            question_text.text = question[18];
            answerBtn1.text = answer[54];
            answerBtn2.text = answer[55];
            answerBtn3.text = answer[56];
            lockedQuestion[18] = true;

            button_1.onClick.RemoveAllListeners();
            button_2.onClick.RemoveAllListeners();
            button_3.onClick.RemoveAllListeners();

            //button_2.onClick.RemoveListener(TaskOnClick);
            button_1.onClick.AddListener(TaskOnClick);
            button_2.onClick.AddListener(IncorrectAnswer);
            button_3.onClick.AddListener(IncorrectAnswer);
        }
        //ВОПРОС 19
        else if (randm == 19 && lockedQuestion[19] == false)
        {
            question_text.text = question[19];
            answerBtn1.text = answer[57];
            answerBtn2.text = answer[58];
            answerBtn3.text = answer[59];
            lockedQuestion[19] = true;
        }
    }
    void TaskOnClick()
    {
        if (randm == 0)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 1)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 2)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 3)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 4)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 5)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 6)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 7)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 8)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 9)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 10)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 11)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 12)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 13)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 14)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 15)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 16)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 17)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 18)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 19)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        //this.GetComponent<Image>().color = Color.red;
        CorrectAnswer += 1;
        Debug.Log("This is the correct answer");
        Debug.Log("Number of correct answers: " + CorrectAnswer);
    }
    void IncorrectAnswer()
    {
        if (randm == 0)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 1)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 2)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 3)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 4)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 5)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 6)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 7)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 8)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 9)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 10)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 11)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 12)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 13)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 14)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 15)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.green;
        }
        if (randm == 16)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 17)
        {
            button_1.GetComponent<Image>().color = Color.red;
            button_2.GetComponent<Image>().color = Color.green;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 18)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
        if (randm == 19)
        {
            button_1.GetComponent<Image>().color = Color.green;
            button_2.GetComponent<Image>().color = Color.red;
            button_3.GetComponent<Image>().color = Color.red;
        }
    }
}
