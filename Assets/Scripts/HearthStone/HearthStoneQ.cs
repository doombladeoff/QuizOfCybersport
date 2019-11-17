using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HearthStoneQ : MonoBehaviour
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
        OpenQuestion = PlayerPrefs.GetInt("HSOpenQuestion") == 1 ? true : false;
        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("HSQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] =  "Вопрос # 1- Максимальное количество карт в руке?";
            question[1] =  "Вопрос # 2- Сколько дополнений выходит каждый год?";
            question[2] =  "Вопрос # 3- Кто выиграл '2017 Hearthstone World Championship'?";
            question[3] =  "Вопрос # 4- Максимальное количество золота за дейлик?";
            question[4] =  "Вопрос # 5- Экспедиция в ...?";
            question[5] =  "Вопрос # 6- Какое максимальное количество Атаки и Здоровья у существ?";
            question[6] =  "Вопрос # 7- Какая максимальная редкость карт?";
            question[7] =  "Вопрос # 8- Как называется заклинание, которое наносит 6 ед. урона?";
            question[8] =  "Вопрос # 9- Как называется заклинание, которая наносит 4 ед. урона и сбрасывает карту?";
            question[9] =  "Вопрос # 10- Максимальный уровень героя:";
            question[10] = "Вопрос # 11- Сколько существует квестов в игре?";
            question[11] = "Вопрос # 12- Какой главный босс в дополнении 'Рыцари Ледяного Трона'?";
            question[12] = "Вопрос # 13- Самый высокий ранг в игре?";
            question[13] = "Вопрос # 14- Сколько легендарных карт может быть в одной колоде?";
            question[14] = "Вопрос # 15- Можно-ли с помощью серкета 'Око за око' сделать ничью?";
            question[15] = "Вопрос # 16- Боевой клич какого дракона делает здоровье героя 15?";
            question[16] = "Вопрос # 17- Сколько длится ход?";
            question[17] = "Вопрос # 18- Вечеринка в ... ";
            question[18] = "Вопрос # 19- Какая карта восстанавливает полностью здоровье вашему герою?";
            question[19] = "Вопрос # 20- Какой герой имеет силу героя '+ 2 к броне'?";

            // Ответы на вопрос 0
            answer[0] = "11";
            answer[1] = "9";
            answer[2] = "10"; // <----- TRUE
                              // Ответы на вопрос 1
            answer[3] = "4";
            answer[4] = "3"; // <----- TRUE
            answer[5] = "2";
            // Ответы на вопрос 2
            answer[6] = "SilverName";
            answer[7] = "Tom60229";// <----- TRUE
            answer[8] = "Fr0zen";
            // Ответы на вопрос 3
            answer[9] = "100 золота";// <----- TRUE
            answer[10] = "150 золота";
            answer[11] = "300 золота";
            // Ответы на вопрос 4
            answer[12] = "Каражан";
            answer[13] = "Прибамбаск";
            answer[14] = "Ун'Горо";// <----- TRUE
                                   // Ответы на вопрос 5
            answer[15] = "Неограничено";// <----- TRUE
            answer[16] = "12-12";
            answer[17] = "10-10";
            // Ответы на вопрос 6
            answer[18] = "Редкая";
            answer[19] = "Легендарная";// <----- TRUE
            answer[20] = "Эпическая";
            // Ответы на вопрос 7
            answer[21] = "Ярость дракона";
            answer[22] = "Огненный шар";// <----- TRUE
            answer[23] = "Вихрь";
            // Ответы на вопрос 8
            answer[24] = "Темные видения";
            answer[25] = "Казнь";
            answer[26] = "Ожог души";// <----- TRUE
                                     // Ответы на вопрос 9
            answer[27] = "60 уровень";// <----- TRUE
            answer[28] = "50 уровень";
            answer[29] = "30 уровень";
            // Ответы на вопрос 10
            answer[30] = "11";
            answer[31] = "9";// <----- TRUE
            answer[32] = "10";
            // Ответы на вопрос 11
            answer[33] = "Тирион Фордринг";
            answer[34] = "Лирой Дженкинс";
            answer[35] = "Король Лич";// <----- TRUE
                                      // Ответы на вопрос 12
            answer[36] = "Легенда";// <----- TRUE
            answer[37] = "1 ранг";
            answer[38] = "Золотой ранг";
            // Ответы на вопрос 13
            answer[39] = "35";// <----- TRUE
            answer[40] = "30";
            answer[41] = "10";
            // Ответы на вопрос 14
            answer[42] = "Нет";
            answer[43] = "Да";// <----- TRUE
            answer[44] = "Не знаю";
            // Ответы на вопрос 15
            answer[45] = "Нефариан";
            answer[46] = "Синдрагоса";
            answer[47] = "Алекстраза";// <----- TRUE
                                      // Ответы на вопрос 16
            answer[48] = "90 секунд";// <----- TRUE
            answer[49] = "120 секунд";
            answer[50] = "60 секунд";
            // Ответы на вопрос 17
            answer[51] = "Таверне";
            answer[52] = "Каражане";// <----- TRUE
            answer[53] = "Наксрамасе";
            // Ответы на вопрос 18
            answer[54] = "Рено Джексон";// <----- TRUE
            answer[55] = "Элиза Звездочет";
            answer[56] = "Алекстраза";
            // Ответы на вопрос 19
            answer[57] = "Воин";// <----- TRUE
            answer[58] = "Разбоиник";
            answer[59] = "Друид";
            #endregion
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] =  "Question # 1- Maximum number of cards in hand?";
            question[1] =  "Question # 2- How many supplements come out every year?";
            question[2] =  "Question # 3- Who won the 2017 Hearthstone World Championship ? ";
            question[3] =  "Question # 4- The maximum amount of gold per dieil ? ";
            question[4] =  "Question # 5- Expedition to ...?";
            question[5] =  "Question # 6- What is the maximum amount of Attack and Health for creatures ? ";
            question[6] =  "Question # 7- What is the maximum rarity of maps ? ";
            question[7] =  "Question # 8- What is the spell, which causes 6 units.damage ? ";
            question[8] =  "Question # 9- What is the spell, which inflicts 4 units.damage and discards a card ? ";
            question[9] =  "Question # 10- Maximum hero level:";
            question[10] = "Question # 11- How many quests are there in the game ? ";
            question[11] = "Question # 12- What is the main boss in the add - on 'Knights of the Ice Throne' ? ";
            question[12] = "Question # 13- The highest rank in the game ? ";
            question[13] = "Question # 14- How many legendary cards can be in the same deck ? ";
            question[14] = "Question # 15- Is it possible to make a draw with the help of an Eye for an Eye?";
            question[15] = "Question # 16- What dragon's battle cry makes the health of hero 15?";
            question[16] = "Question # 17- How long is the turn?";
            question[17] = "Question # 18- Party at ...";
            question[18] = "Question # 19- Which card fully restores your hero's health?";
            question[19] = "Question # 20- Which hero has the power of the hero + 2 armor?";

            // Ответы на вопрос 0
            answer[0] = "11";
            answer[1] = "9";
            answer[2] = "10"; // <----- TRUE
                              // Ответы на вопрос 1
            answer[3] = "4";
            answer[4] = "3"; // <----- TRUE
            answer[5] = "2";
            // Ответы на вопрос 2
            answer[6] = "SilverName";
            answer[7] = "Tom60229";// <----- TRUE
            answer[8] = "Fr0zen";
            // Ответы на вопрос 3
            answer[9] = "100 gold";// <----- TRUE
            answer[10] = "150 gold";
            answer[11] = "300 gold";
            // Ответы на вопрос 4
            answer[12] = "Karazhan";
            answer[13] = "Gadgetzan";
            answer[14] = "Un'Goro";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "Unlimited";// <----- TRUE
            answer[16] = "12-12";
            answer[17] = "10-10";
            // Ответы на вопрос 6
            answer[18] = "Rare";
            answer[19] = "Legendary";// <----- TRUE
            answer[20] = "Epic";
            // Ответы на вопрос 7
            answer[21] = "Dragon rage";
            answer[22] = "Fire ball";// <----- TRUE
            answer[23] = "Vortex";
            // Ответы на вопрос 8
            answer[24] = "Dark visions";
            answer[25] = "Execution";
            answer[26] = "Soul burn";// <----- TRUE
                                     // Ответы на вопрос 9
            answer[27] = "60 level";// <----- TRUE
            answer[28] = "50 level";
            answer[29] = "30 level";
            // Ответы на вопрос 10
            answer[30] = "11";
            answer[31] = "9";// <----- TRUE
            answer[32] = "10";
            // Ответы на вопрос 11
            answer[33] = "Tyrion Fordring";
            answer[34] = "Leroy Jenkins";
            answer[35] = "Lich King";// <----- TRUE
                                      // Ответы на вопрос 12
            answer[36] = "Legend";// <----- TRUE
            answer[37] = "1 rank";
            answer[38] = "Gold rank";
            // Ответы на вопрос 13
            answer[39] = "35";// <----- TRUE
            answer[40] = "30";
            answer[41] = "10";
            // Ответы на вопрос 14
            answer[42] = "No";
            answer[43] = "Yes";// <----- TRUE
            answer[44] = "I don't know";
            // Ответы на вопрос 15
            answer[45] = "Nefarian";
            answer[46] = "Sindragosa";
            answer[47] = "Alexstrasza";// <----- TRUE
                                      // Ответы на вопрос 16
            answer[48] = "90 sec";// <----- TRUE
            answer[49] = "120 sec";
            answer[50] = "60 sec";
            // Ответы на вопрос 17
            answer[51] = "Tavern";
            answer[52] = "Karazhane";// <----- TRUE
            answer[53] = "Naxxramas";
            // Ответы на вопрос 18
            answer[54] = "Renault Jackson";// <----- TRUE
            answer[55] = "Eliza Stargazer";
            answer[56] = "Alexstrasza";
            // Ответы на вопрос 19
            answer[57] = "Warrior";// <----- TRUE
            answer[58] = "Rogue";
            answer[59] = "Druid";
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
       // GenarateRandomQuestion();
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
