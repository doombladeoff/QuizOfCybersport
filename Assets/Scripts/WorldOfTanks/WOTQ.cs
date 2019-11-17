using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WOTQ : MonoBehaviour
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
        randm = -1;
        QUIZ_COUNT = 10;
        CorrectAnswer = 0;
        OpenQuestion = PlayerPrefs.GetInt("WOTOpenQuestion") == 1 ? true : false;
        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("WOTQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы 
            question[0] =  "Вопрос # 1- Основатель компании Wargaming.net?";
            question[1] =  "Вопрос # 2- В каком году появилась игра World of Tanks?";
            question[2] =  "Вопрос # 3- Пробитие фугаса какого танка равен калибру его пушки?";
            question[3] =  "Вопрос # 4- У какого танка в игре основной и премиумный тип снаряда кумулятивный?";
            question[4] =  "Вопрос # 5- Какой класс техники обозначается коричневым квадратом?";
            question[5] =  "Вопрос # 6- Какой танк X уровня является наградой за первый сезон Личных Боевых Задач?";
            question[6] =  "Вопрос # 7- Какой танк называют Луноходом?";
            question[7] =  "Вопрос # 8- Единственный танк в игре у которого было 14960 ХП?";
            question[8] =  "Вопрос # 9- У какого танка самое высокое пробитие в игре?";
            question[9] =  "Вопрос # 10- Максимальная скорость какого танка самая большая в игре по ТТХ?";
            question[10] = "Вопрос # 11- Какой танк называют черепахой?";
            question[11] = "Вопрос # 12- Победитель Битвы Блогеров в режиме Стальной охотник?";
            question[12] = "Вопрос # 13- У какого танка самый большой калибр в игре?";
            question[13] = "Вопрос # 14- Танк у которого четыре гусеницы?";
            question[14] = "Вопрос # 15- Какой танк прозвали трамваем?";
            question[15] = "Вопрос # 16- Какой из танков по игре являеться Немецким?";
            question[16] = "Вопрос # 17- Какой название раньше было у Т-10?";
            question[17] = "Вопрос # 18- Самый тяжелый танк игры?";
            question[18] = "Вопрос # 19- Какой танк является акционным?";
            question[19] = "Вопрос # 20- Сколько раз можно проабгрейдить свой танк в режиме Стальной охотник?";

            // Ответы на вопрос 0
            answer[0] = "Эндрю Тинни";
            answer[1] = "Евгений Кислый";
            answer[2] = "Виктор Кислый"; // <----- TRUE
            
            // Ответы на вопрос 1
            answer[3] = "9 августа 2011 года";
            answer[4] = "12 августа 2010 года"; // <----- TRUE
            answer[5] = "19 августа 2012 года";
            
            // Ответы на вопрос 2
            answer[6] = "AMX 13 105";
            answer[7] = "Panhard EBR 105";// <----- TRUE
            answer[8] = "T95/FV4201 Chieftain";
           
            // Ответы на вопрос 3
            answer[9] = "Ikv 103";// <----- TRUE
            answer[10] = "Об.430";
            answer[11] = "СУ-122-44";
           
            // Ответы на вопрос 4
            answer[12] = "ЛТ";
            answer[13] = "ПТ САУ";
            answer[14] = "САУ";// <----- TRUE
           
            // Ответы на вопрос 5
            answer[15] = "Об.260";// <----- TRUE
            answer[16] = "Об.279";
            answer[17] = "Об.907";
           
            // Ответы на вопрос 6
            answer[18] = "Об.279";
            answer[19] = "ИС-7";// <----- TRUE
            answer[20] = "Об.907";
            
            // Ответы на вопрос 7
            answer[21] = "Левиафан";
            answer[22] = "Белый Тигр";// <----- TRUE
            answer[23] = "Ratte";
           
            // Ответы на вопрос 8
            answer[24] = "Т110Е4";
            answer[25] = "Об.268";
            answer[26] = "Jagdpanzer E 100";// <----- TRUE
          
            // Ответы на вопрос 9
            answer[27] = "Panhard EBR 105";// <----- TRUE
            answer[28] = "Т100ЛТ";
            answer[29] = "Sheridan";
            
            // Ответы на вопрос 10
            answer[30] = "Т92";
            answer[31] = "Т95";// <----- TRUE
            answer[32] = "Т28";
           
            // Ответы на вопрос 11
            answer[33] = "KorbenDallas";
            answer[34] = "Strike";
            answer[35] = "LeBwa";// <----- TRUE
            
            // Ответы на вопрос 12
            answer[36] = "Т92";// <----- TRUE
            answer[37] = "G.W.E 100";
            answer[38] = "ConquerorGC";
           
           // Ответы на вопрос 13
            answer[39] = "Об.279";// <----- TRUE
            answer[40] = "Об.907";
            answer[41] = "Об.277";
           
            // Ответы на вопрос 14
            answer[42] = "TOG-II";
            answer[43] = "Т-28";// <----- TRUE
            answer[44] = "Т28";
           
            // Ответы на вопрос 15
            answer[45] = "Т-54 обл.";
            answer[46] = "Т-54";
            answer[47] = "Т55А";// <----- TRUE
           
            // Ответы на вопрос 16
            answer[48] = "ИС-8";// <----- TRUE
            answer[49] = "ИС-5";
            answer[50] = "Об.730";
            
            // Ответы на вопрос 17
            answer[51] = "E-100";
            answer[52] = "Maus";// <----- TRUE
            answer[53] = "Type 5 Heavy";
           
            // Ответы на вопрос 18
            answer[54] = "AMX 50 Foch 155";// <----- TRUE
            answer[55] = "AMX 50 Foch B";
            answer[56] = "AMX 50 B";
            
            // Ответы на вопрос 19
            answer[57] = "8";// <----- TRUE
            answer[58] = "11";
            answer[59] = "6";
#endregion
        }
        if (LanguageManager.ENG_language_selected == true) {
            #region Question
            // Вопросы
            question[0] =  "Question # 1- Founder Wargaming.net?";
            question[1] =  "Question # 2- What year did the World of Tanks game appear?";
            question[2] =  "Question # 3- The penetration of a landmine of which tank is equal to the caliber of its gun?";
            question[3] =  "Question # 4- Which tank has the main and premium type of cumulative projectile in the game?";
            question[4] =  "Question # 5- What class of technology is indicated by the brown square?";
            question[5] =  "Question # 6- Which level 10 tank is the reward for the first season of Personal Combat Tasks?";
            question[6] =  "Question # 7- Which tank is called moon rover?";
            question[7] =  "Question # 8- The only tank in the game that had 14,960 HP?";
            question[8] =  "Question # 9- Which tank has the highest penetration in the game?";
            question[9] =  "Question # 10- Which tank’s maximum speed is the highest in the game on performance characteristics?";
            question[10] = "Question # 11- Which tank is called the turtle?";
            question[11] = "Question # 12- Winner of the Battle of Bloggers in Steel Hunter mode?";
            question[12] = "Question # 13- Which tank has the largest caliber in the game?";
            question[13] = "Question # 14- A tank with four tracks?";
            question[14] = "Question # 15- Which tank was nicknamed the tram?";
            question[15] = "Question # 16- Which of the tanks in the game is German?";
            question[16] = "Question # 17- What was the name of the T-10?";
            question[17] = "Question # 18- The heaviest tank game?";
            question[18] = "Question # 19- Which tank is promotional?";
            question[19] = "Question # 20- How many times can you upgrade your tank in Steel Hunter mode?";

            // Ответы на вопрос 0 
            answer[0] = "Andrew Tinney";
            answer[1] = "Evgeny Kisly";
            answer[2] = "Victor  Kisly"; // <----- TRUE
            
            // Ответы на вопрос 1
            answer[3] = "August 9, 2011";
            answer[4] = "August 12, 2010"; // <----- TRUE
            answer[5] = "August 19, 2012";
            
            // Ответы на вопрос 2
            answer[6] = "AMX 13 105";
            answer[7] = "Panhard EBR 105";// <----- TRUE
            answer[8] = "T95/FV4201 Chieftain";
           
            // Ответы на вопрос 3
            answer[9] = "Ikv 103";// <----- TRUE
            answer[10] = "Obj. 430";
            answer[11] = "SU-122-44";
           
            // Ответы на вопрос 4
            answer[12] = "LT";
            answer[13] = "Tank Destroyer";
            answer[14] = "SPG";// <----- TRUE
           
            // Ответы на вопрос 5
            answer[15] = "Obj.260";// <----- TRUE
            answer[16] = "Obj.279";
            answer[17] = "Obj.907";
           
            // Ответы на вопрос 6
            answer[18] = "Obj.279";
            answer[19] = "IS-7";// <----- TRUE
            answer[20] = "Obj.907";
            
            // Ответы на вопрос 7
            answer[21] = "Leviathan";
            answer[22] = "White Tiger";// <----- TRUE
            answer[23] = "Ratte";
           
            // Ответы на вопрос 8
            answer[24] = "Т110Е4";
            answer[25] = "Obj.268";
            answer[26] = "Jagdpanzer E 100";// <----- TRUE
          
            // Ответы на вопрос 9
            answer[27] = "Panhard EBR 105";// <----- TRUE
            answer[28] = "T100LT";
            answer[29] = "Sheridan";
            
            // Ответы на вопрос 10
            answer[30] = "Т92";
            answer[31] = "Т95";// <----- TRUE
            answer[32] = "Т28";
           
            // Ответы на вопрос 11
            answer[33] = "KorbenDallas";
            answer[34] = "Strike";
            answer[35] = "LeBwa";// <----- TRUE
            
            // Ответы на вопрос 12
            answer[36] = "Т92";// <----- TRUE
            answer[37] = "G.W.E 100";
            answer[38] = "ConquerorGC";
           
           // Ответы на вопрос 13
            answer[39] = "Obj.279";// <----- TRUE
            answer[40] = "Obj.907";
            answer[41] = "Obj.277";
           
            // Ответы на вопрос 14
            answer[42] = "TOG-II";
            answer[43] = "Т-28";// <----- TRUE
            answer[44] = "Т28";
           
            // Ответы на вопрос 15
            answer[45] = "Т-54 LW.";
            answer[46] = "Т-54";
            answer[47] = "Т55А";// <----- TRUE
           
            // Ответы на вопрос 16
            answer[48] = "IS-8";// <----- TRUE
            answer[49] = "IS-5";
            answer[50] = "Obj.730";
            
            // Ответы на вопрос 17
            answer[51] = "E-100";
            answer[52] = "Maus";// <----- TRUE
            answer[53] = "Type 5 Heavy";
           
            // Ответы на вопрос 18
            answer[54] = "AMX 50 Foch 155";// <----- TRUE
            answer[55] = "AMX 50 Foch B";
            answer[56] = "AMX 50 B";
            
            // Ответы на вопрос 19
            answer[57] = "8";// <----- TRUE
            answer[58] = "11";
            answer[59] = "6";
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
        if (randm == 0) {
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
    void IncorrectAnswer() {
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
