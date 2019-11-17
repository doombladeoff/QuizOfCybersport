using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverwatchQ : MonoBehaviour
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
        OpenQuestion = PlayerPrefs.GetInt("OverwatchOpenQuestion") == 1 ? true : false;

        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("OverwatchQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Вопрос # 1- Сколько всего классов в игре?";
            question[1] = "Вопрос # 2- Какой класс усиливает своих союзников, исцеляет и укрывает их щитами?";
            question[2] = "Вопрос # 3- Какому герою принадлежит напарник Боб?";
            question[3] = "Вопрос # 4- К какому классу принадлежит герой Ангел?";
            question[4] = "Вопрос # 5- Как зовут брата героя Хандзо?";
            question[5] = "Вопрос # 6- У какого героя сигара во рту?";
            question[6] = "Вопрос # 7- Кому принадлежит снайперская винтовка 'Поцелуй вдовы'?";
            question[7] = "Вопрос # 8- Кто из героев может устанавливать телепорт ?";
            question[8] = "Вопрос # 9- Какому герою принадлжеит способность Перегрев?";
            question[9] = "Вопрос # 10- Какой герой может мгновенно вокруг себя создать барьер льда?";
            question[10] = "Вопрос # 11- Какому герою принадлежит способность Катализатор?";
            question[11] = "Вопрос # 12- Сколько существует режимов в игре?";
            question[12] = "Вопрос # 13- Сколько всего карт в игре?";
            question[13] = "Вопрос # 14- У кого из геров костюм оборудован реактивными двигателями?";
            question[14] = "Вопрос # 15- Кто из героев может перейти в режим маскировки?";
            question[15] = "Вопрос # 16- К какому классу принадлежит герой Трейсер?";
            question[16] = "Вопрос # 17- К какому классу принадлежит герой Райнхардт?";
            question[17] = "Вопрос # 18- Сколько героев в игре?";
            question[18] = "Вопрос # 19- Сколько видов репутации существует в игре?";
            question[19] = "Вопрос # 20- Кому принадлежит фраза 'Прогресс невозможен без жертв'?";

            // Ответы на вопрос 0
            answer[0] = "2";
            answer[1] = "1";
            answer[2] = "3"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Танк";
            answer[4] = "Поддержка"; // <----- TRUE
            answer[5] = "Урон";
            // Ответы на вопрос 2
            answer[6] = "Сомбра";
            answer[7] = "Эш";// <----- TRUE
            answer[8] = "Таран";
            // Ответы на вопрос 3
            answer[9] = "Поддержка";// <----- TRUE
            answer[10] = "Урон";
            answer[11] = "Танк";
            // Ответы на вопрос 4
            answer[12] = "Маккри";
            answer[13] = "Райнхардт";
            answer[14] = "Гендзи";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "Маккри";// <----- TRUE
            answer[16] = "Эш";
            answer[17] = "Лусио";
            // Ответы на вопрос 6
            answer[18] = "Бастиону";
            answer[19] = "Роковой вдове";// <----- TRUE
            answer[20] = "Батисте";
            // Ответы на вопрос 7
            answer[21] = "Уинстон";
            answer[22] = "Симметра";// <----- TRUE
            answer[23] = "Солдат-76";
            // Ответы на вопрос 8
            answer[24] = "D.VA";
            answer[25] = "Ана";
            answer[26] = "Торбьорн";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "Мэй";// <----- TRUE
            answer[28] = "Кулак смерти";
            answer[29] = "Жнец";
            // Ответы на вопрос 10
            answer[30] = "Мойра";
            answer[31] = "Ориса";// <----- TRUE
            answer[32] = "Трейсер";
            // Ответы на вопрос 11
            answer[33] = "9";
            answer[34] = "5";
            answer[35] = "6";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "28";// <----- TRUE
            answer[37] = "19";
            answer[38] = "5";
            // Ответы на вопрос 13
            answer[39] = "Фарра";// <----- TRUE
            answer[40] = "Хандзо";
            answer[41] = "Турбосвин";
            // Ответы на вопрос 14
            answer[42] = "Жнец";
            answer[43] = "Сомбра";// <----- TRUE
            answer[44] = "Сигма";
            // Ответы на вопрос 15
            answer[45] = "Танк";
            answer[46] = "Подержка";
            answer[47] = "Урон";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "Танк";// <----- TRUE
            answer[49] = "Поддержка";
            answer[50] = "Урон";
            // Ответы на вопрос 17
            answer[51] = "30";
            answer[52] = "31";// <----- TRUE
            answer[53] = "32";
            // Ответы на вопрос 18
            answer[54] = "3";// <----- TRUE
            answer[55] = "4";
            answer[56] = "5";
            // Ответы на вопрос 19
            answer[57] = "Кулаку смерти";// <----- TRUE
            answer[58] = "Сигме";
            answer[59] = "Уинстону";
            #endregion
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Question # 1- How many classes are there in the game? ";
            question[1] = "Question # 2- Which class strengthens its allies, heals and covers them with shields?";
            question[2] = "Question # 3- Which hero does teammate Bob belong to?";
            question[3] = "Question # 4- What class does the hero Angel belong to?";
            question[4] = "Question # 5- What is the name of the brother of the hero Hanzo?";
            question[5] = "Question # 6- Which hero has a cigar in his mouth?";
            question[6] = "Question # 7- Who owns the Widow's Kiss' sniper rifle?";
            question[7] = "Question # 8- Which of the heroes can establish a teleport?";
            question[8] = "Question # 9- Which hero does the Overheat ability belong to?";
            question[9] = "Question # 10- Which hero can instantly create an ice barrier around himself?";
            question[10] = "Question # 11- To which hero does the Catalyst ability belong?";
            question[11] = "Question # 12- How many modes are there in the game?";
            question[12] = "Question # 13- How many cards are in the game?";
            question[13] = "Question # 14- Which of the heroes has jet engines?";
            question[14] = "Question # 15- Which of the heroes can go into disguise mode?";
            question[15] = "Question # 16- What class does the hero Tracer belong to?";
            question[16] = "Question # 17- What class does the hero Reinhardt belong to?";
            question[17] = "Question # 18- How many heroes are there in the game?";
            question[18] = "Question # 19- How many types of reputation exist in the game?";
            question[19] = "Question # 20- Who owns the phrase 'Progress is impossible without victims'?";

            // Ответы на вопрос 0
            answer[0] = "2";
            answer[1] = "1";
            answer[2] = "3"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Tank";
            answer[4] = "Support"; // <----- TRUE
            answer[5] = "Damage";
            // Ответы на вопрос 2
            answer[6] = "Sombra";
            answer[7] = "Ash";// <----- TRUE
            answer[8] = "Ram";
            // Ответы на вопрос 3
            answer[9] = "Support";// <----- TRUE
            answer[10] = "Damage";
            answer[11] = "Tank";
            // Ответы на вопрос 4
            answer[12] = "Mccree";
            answer[13] = "Reinhardt";
            answer[14] = "Genji";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "Mccree";// <----- TRUE
            answer[16] = "Ash";
            answer[17] = "Lucio";
            // Ответы на вопрос 6
            answer[18] = "Bastion";
            answer[19] = "Fatal Widow";// <----- TRUE
            answer[20] = "Batiste";
            // Ответы на вопрос 7
            answer[21] = "Winston";
            answer[22] = "Symmetra";// <----- TRUE
            answer[23] = "Soldier-76";
            // Ответы на вопрос 8
            answer[24] = "D.VA";
            answer[25] = "Ana";
            answer[26] = "Thorbjorn";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "May";// <----- TRUE
            answer[28] = "Fist of death";
            answer[29] = "Reaper";
            // Ответы на вопрос 10
            answer[30] = "Moira";
            answer[31] = "Orisa";// <----- TRUE
            answer[32] = "Tracer";
            // Ответы на вопрос 11
            answer[33] = "9";
            answer[34] = "5";
            answer[35] = "6";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "28";// <----- TRUE
            answer[37] = "19";
            answer[38] = "5";
            // Ответы на вопрос 13
            answer[39] = "Farrah";// <----- TRUE
            answer[40] = "Hanzo";
            answer[41] = "Roadhog";
            // Ответы на вопрос 14
            answer[42] = "Reaper";
            answer[43] = "Sombra";// <----- TRUE
            answer[44] = "Sigma";
            // Ответы на вопрос 15
            answer[45] = "Tank";
            answer[46] = "Support";
            answer[47] = "Damage";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "Tank";// <----- TRUE
            answer[49] = "Support";
            answer[50] = "Damage";
            // Ответы на вопрос 17
            answer[51] = "30";
            answer[52] = "31";// <----- TRUE
            answer[53] = "32";
            // Ответы на вопрос 18
            answer[54] = "3";// <----- TRUE
            answer[55] = "4";
            answer[56] = "5";
            // Ответы на вопрос 19
            answer[57] = "Fist of death";// <----- TRUE
            answer[58] = "Sigma";
            answer[59] = "Winston";
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
        Debug.Log("Current question № " + randm);
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
