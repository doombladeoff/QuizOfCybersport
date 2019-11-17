using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CSGOQ : MonoBehaviour
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
        OpenQuestion = PlayerPrefs.GetInt("CSGOOpenQuestion") == 1 ? true : false;
        
        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("CSGOQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Вопрос # 1- Кто является капитаном команды Na'Vi CS:GO?";
            question[1] = "Вопрос # 2- Когда был собран первый состав CS:GO команды Gambit?";
            question[2] = "Вопрос # 3- Кто из этих людей не имеет никакого отношения к организации Gambit?";
            question[3] = "Вопрос # 4- Когда была создана организация Na'Vi?";
            question[4] = "Вопрос # 5- Кого прозвали королём 'пистолетки'?";
            question[5] = "Вопрос # 6- Какие самые дорогие наклейки в CS:GO?";
            question[6] = "Вопрос # 7- Какая максимальная редкость скинов?";
            question[7] = "Вопрос # 8- За убийство с какого оружия дают больше всего денег?";
            question[8] = "Вопрос # 9- Сколько гранат можно взять с собой?";
            question[9] = "Вопрос # 10- После какого уровня, можно получить Медаль за службу?";
            question[10] = "Вопрос # 11- Какая из гранат стоит больше всех?";
            question[11] = "Вопрос # 12- Какое время горения у молотова?";
            question[12] = "Вопрос # 13- Какое из оружий убивает 1 пулей в голову?";
            question[13] = "Вопрос # 14- Какой из перечисленных карт нет в игре?";
            question[14] = "Вопрос # 15- Можно-ли убить противника одной гранатой со 100 НР без брони?";
            question[15] = "Вопрос # 16- За какое время взрывается молотов?";
            question[16] = "Вопрос # 17- Какой урон при попадании в ногу с AWP?";
            question[17] = "Вопрос # 18- Чтобы убить противника с первого удара, нужно резать: ";
            question[18] = "Вопрос # 19- Какой нож был у КТ в альфа версии игры?";
            question[19] = "Вопрос # 20- Из-за какой карты Olofmeister'a прозвали Boostmeister?";

            // Ответы на вопрос 0
            answer[0] = "Olofmeister";
            answer[1] = "PashaBiceps";
            answer[2] = "Boombl4"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Май 2016";
            answer[4] = "Январь 2016"; // <----- TRUE
            answer[5] = "Октябрь 2015";
            // Ответы на вопрос 2
            answer[6] = "spaze";
            answer[7] = "CyberFocus";// <----- TRUE
            answer[8] = "Kane";
            // Ответы на вопрос 3
            answer[9] = "Декабрь 2009";// <----- TRUE
            answer[10] = "Декабрь 2010";
            answer[11] = "Январь 2011";
            // Ответы на вопрос 4
            answer[12] = "S1mple";
            answer[13] = "GuardiaN";
            answer[14] = "Edward";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "ESL Katowice 2014";// <----- TRUE
            answer[16] = "ELEAGUE 2017";
            answer[17] = "MLG Columbus 2016";
            // Ответы на вопрос 6
            answer[18] = "Красная";
            answer[19] = "Жёлтая";// <----- TRUE
            answer[20] = "Серая";
            // Ответы на вопрос 7
            answer[21] = "Убийство с шокера";
            answer[22] = "Убийство с ножа";// <----- TRUE
            answer[23] = "Убийство с AWP";
            // Ответы на вопрос 8
            answer[24] = "5";
            answer[25] = "3";
            answer[26] = "4";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "40 уровень";// <----- TRUE
            answer[28] = "30 уровень";
            answer[29] = "50 уровень";
            // Ответы на вопрос 10
            answer[30] = "Флешка";
            answer[31] = "Молотов";// <----- TRUE
            answer[32] = "Осколочная";
            // Ответы на вопрос 11
            answer[33] = "9 секунд";
            answer[34] = "5 секунд";
            answer[35] = "7 секунд";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "AK-47";// <----- TRUE
            answer[37] = "M4A4";
            answer[38] = "M4A1-S";
            // Ответы на вопрос 13
            answer[39] = "Tuscan";// <----- TRUE
            answer[40] = "Canals";
            answer[41] = "Italia";
            // Ответы на вопрос 14
            answer[42] = "Нет";
            answer[43] = "Да";// <----- TRUE
            answer[44] = "Только 50 HP";
            // Ответы на вопрос 15
            answer[45] = "1,5 секунды";
            answer[46] = "4 секунды";
            answer[47] = "2 секунды";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "85 HP";// <----- TRUE
            answer[49] = "75 HP";
            answer[50] = "20 HP";
            // Ответы на вопрос 17
            answer[51] = "В грудь";
            answer[52] = "В спину";// <----- TRUE
            answer[53] = "В голову";
            // Ответы на вопрос 18
            answer[54] = "Штык-нож";// <----- TRUE
            answer[55] = "Нож бабочка";
            answer[56] = "Керамбит";
            // Ответы на вопрос 19
            answer[57] = "Overpass";// <----- TRUE
            answer[58] = "Cbble";
            answer[59] = "Nuke";
            #endregion
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Question # 1- Who is the captain of the team Na'Vi CS: GO?";
            question[1] = "Question # 2- When was the first CS: GO lineup of the Gambit team assembled ? ";
            question[2] = "Question # 3- Which of these people has nothing to do with the organization of Gambit?";
            question[3] = "Question # 4- When was the Na'Vi organization created?";
            question[4] = "Question # 5- Who was nicknamed 'the pistols' king?";
            question[5] = "Question # 6- What are the most expensive stickers in CS: GO?";
            question[6] = "Question # 7- What is the maximum rarity of skins ? ";
            question[7] = "Question # 8- For killing with a weapon give the most money ? ";
            question[8] = "Question # 9- How many grenades can I take with me?";
            question[9] = "Question # 10- After what level can you get a Medal of Service?";
            question[10] = "Question # 11- Which grenade is the most expensive?";
            question[11] = "Question # 12- What is the burning time of Molotov?";
            question[12] = "Question # 13- Which weapon kills 1 bullet in the head?";
            question[13] = "Question # 14- Which of the listed cards is not in the game?";
            question[14] = "Question # 15- Is it possible to kill the enemy with one grenade with 100 HP without armor ? ";
            question[15] = "Question # 16- How long does the hammer blows?";
            question[16] = "Question # 17- What is the damage if you hit the AWP ? ";
            question[17] = "Question # 18- To kill the enemy with the first strike, you need to cut:";
            question[18] = "Question # 19- What kind of knife was KT in the alpha version of the game?";
            question[19] = "Question # 20- Which card did Olofmeister call Boostmeister?";

            // Ответы на вопрос 0
            answer[0] = "Olofmeister";
            answer[1] = "PashaBiceps";
            answer[2] = "Boombl4"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "May 2016";
            answer[4] = "January 2016"; // <----- TRUE
            answer[5] = "October 2015";
            // Ответы на вопрос 2
            answer[6] = "spaze";
            answer[7] = "CyberFocus";// <----- TRUE
            answer[8] = "Kane";
            // Ответы на вопрос 3
            answer[9] = "December 2009";// <----- TRUE
            answer[10] = "December 2010";
            answer[11] = "January 2011";
            // Ответы на вопрос 4
            answer[12] = "S1mple";
            answer[13] = "GuardiaN";
            answer[14] = "Edward";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "ESL Katowice 2014";// <----- TRUE
            answer[16] = "ELEAGUE 2017";
            answer[17] = "MLG Columbus 2016";
            // Ответы на вопрос 6
            answer[18] = "Red";
            answer[19] = "Yellow";// <----- TRUE
            answer[20] = "Gray";
            // Ответы на вопрос 7
            answer[21] = "Kill with a shocker";
            answer[22] = "Knife kill";// <----- TRUE
            answer[23] = "Killing with AWP";
            // Ответы на вопрос 8
            answer[24] = "5";
            answer[25] = "3";
            answer[26] = "4";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "40 level";// <----- TRUE
            answer[28] = "30 level";
            answer[29] = "50 level";
            // Ответы на вопрос 10
            answer[30] = "Flash bang";
            answer[31] = "Molotov";// <----- TRUE
            answer[32] = "HE grenade";
            // Ответы на вопрос 11
            answer[33] = "9 sec";
            answer[34] = "5 sec";
            answer[35] = "7 sec";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "AK-47";// <----- TRUE
            answer[37] = "M4A4";
            answer[38] = "M4A1-S";
            // Ответы на вопрос 13
            answer[39] = "Tuscan";// <----- TRUE
            answer[40] = "Canals";
            answer[41] = "Italia";
            // Ответы на вопрос 14
            answer[42] = "No";
            answer[43] = "Yes";// <----- TRUE
            answer[44] = "Only 50 HP";
            // Ответы на вопрос 15
            answer[45] = "1,5 sec";
            answer[46] = "4 sec";
            answer[47] = "2 sec";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "85 HP";// <----- TRUE
            answer[49] = "75 HP";
            answer[50] = "20 HP";
            // Ответы на вопрос 17
            answer[51] = "In the chest";
            answer[52] = "In the back";// <----- TRUE
            answer[53] = "To the head";
            // Ответы на вопрос 18
            answer[54] = "Bayonet knife";// <----- TRUE
            answer[55] = "Butterfly knife";
            answer[56] = "Karambit";
            // Ответы на вопрос 19
            answer[57] = "Overpass";// <----- TRUE
            answer[58] = "Cbble";
            answer[59] = "Nuke";
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
