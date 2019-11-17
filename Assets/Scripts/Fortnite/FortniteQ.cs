using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FortniteQ : MonoBehaviour
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
        OpenQuestion = PlayerPrefs.GetInt("FortniteOpenQuestion") == 1 ? true : false;
        
        if (OpenQuestion == true)
        {
            QUIZ_COUNT = PlayerPrefs.GetInt("FortniteQuestion");
            randm = -1;
            Debug.Log("----------" + QUIZ_COUNT + "-------------");
        }
        if (LanguageManager.RU_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Вопрос # 1- Как зовут менеджера команды Virtus.Pro?";
            question[1] = "Вопрос # 2- Какое событие произошло в 7 сезоне фортнайт?";
            question[2] = "Вопрос # 3- Какого качества бывает АК-47?";
            question[3] = "Вопрос # 4- Какое событие произошло 21 сентября 2019 года?";
            question[4] = "Вопрос # 5- Что будет если сломать сундук или ящик с патронами?";
            question[5] = "Вопрос # 6- Где проходил World Cup?";
            question[6] = "Вопрос # 7- Сколько патронов вмещает 'Тактический дробовик'?";
            question[7] = "Вопрос # 8- В каких локациях был голографический бургер?";
            question[8] = "Вопрос # 9- C какой переодичностью появлялось поздравление с 2019 годом?";
            question[9] = "Вопрос # 10- В каком обновлении убрали задержку редактирования?";
            question[10] = "Вопрос # 11- Сколько было упавших автобусов за все время?";
            question[11] = "Вопрос # 12- Cколько можно было носить миников(хил) раньше?";
            question[12] = "Вопрос # 13- Когда появились гольфмашины в игре?";
            question[13] = "Вопрос # 14- Сколько наносил урона лук?";
            question[14] = "Вопрос # 15- Сколько уровней было во 2-ом сезоне?";
            question[15] = "Вопрос # 16- Какой призовой фонд был на Summer Skirmich?";
            question[16] = "Вопрос # 17- Сколько наносит помповый дробовик в голову в полотной дистанции?";
            question[17] = "Вопрос # 18- Сколько хп у деревянной стены?";
            question[18] = "Вопрос # 19- Если надеть 'Куст' он будет пропкускать урон?";
            question[19] = "Вопрос # 20- Что делает 'Тако' на локации 'Засаленная закусочная'?";

            // Ответы на вопрос 0
            answer[0] = "Иван Скоколов";
            answer[1] = "Мария Ермолина";
            answer[2] = "Александр Колос"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Владыка льда уничтожил 'Брошенные башни'";
            answer[4] = "Владыка льда покрыл всю карту снегом"; // <----- TRUE
            answer[5] = "Владыка льда выпустил монстра наружу из льда";
            // Ответы на вопрос 2
            answer[6] = "Только золотого";
            answer[7] = "Серого,синего,зеленого";// <----- TRUE
            answer[8] = "Фиолетового,серого золтого";
            // Ответы на вопрос 3
            answer[9] = "Бэтмен ивент";// <----- TRUE
            answer[10] = "Джон Уик ивент";
            answer[11] = "Ивент Монстр vs Робот";
            // Ответы на вопрос 4
            answer[12] = "Он пропадет";
            answer[13] = "Ничего не произойдет";
            answer[14] = "Он выдаст предметы";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "Нью-Йорк";// <----- TRUE
            answer[16] = "Франкфурт";
            answer[17] = "Москва";
            // Ответы на вопрос 6
            answer[18] = "2";
            answer[19] = "8";// <----- TRUE
            answer[20] = "10";
            // Ответы на вопрос 7
            answer[21] = "В Новых башнях";
            answer[22] = "В новых башнях и Торговой точке";// <----- TRUE
            answer[23] = "Его не было вообще";
            // Ответы на вопрос 8
            answer[24] = "10 минут";
            answer[25] = "30 минут";
            answer[26] = "1 час";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "7.10";// <----- TRUE
            answer[28] = "5.40";
            answer[29] = "9.20";
            // Ответы на вопрос 10
            answer[30] = "0";
            answer[31] = "2";// <----- TRUE
            answer[32] = "1";
            // Ответы на вопрос 11
            answer[33] = "15";
            answer[34] = "2";
            answer[35] = "10";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "В 5 сезоне";// <----- TRUE
            answer[37] = "В 4 сезоне ";
            answer[38] = "В 1 сезон";
            // Ответы на вопрос 13
            answer[39] = "115";// <----- TRUE
            answer[40] = "113";
            answer[41] = "30";
            // Ответы на вопрос 14
            answer[42] = "40";
            answer[43] = "70";// <----- TRUE
            answer[44] = "100";
            // Ответы на вопрос 15
            answer[45] = "10k$";
            answer[46] = "100k$";
            answer[47] = "8млн$";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "200";// <----- TRUE
            answer[49] = "250";
            answer[50] = "145";
            // Ответы на вопрос 17
            answer[51] = "100";
            answer[52] = "150";// <----- TRUE
            answer[53] = "200";
            // Ответы на вопрос 18
            answer[54] = "Да";// <----- TRUE
            answer[55] = "Не знаю";
            answer[56] = "Нет";
            // Ответы на вопрос 19
            answer[57] = "Ускорние спринта(бега)+";// <----- TRUE
            answer[58] = "Можно высоко прыгать";
            answer[59] = "Нельзя строить";
            #endregion
        }
        if (LanguageManager.ENG_language_selected == true)
        {
            #region Question
            // Вопросы
            question[0] = "Question # 1- What is the name of the Virtus.Pro Team Manager?";
            question[1] = "Question # 2- What event happened in season 7 of fortnight?";
            question[2] = "Question # 3- What quality is the AK-47?";
            question[3] = "Question # 4- What event happened on September 21, 2019?";
            question[4] = "Question # 5- What happens if you break a chest or a box of cartridges?";
            question[5] = "Question # 6- Where did the World Cup go?";
            question[6] = "Question # 7- How many rounds does the Tactical Shotgun hold?";
            question[7] = "Question # 8- What locations was the holographic burger in?";
            question[8] = "Question # 9- With what periodicity did you receive a congratulation on the year 2019?";
            question[9] = "Question # 10- In which update did you remove the editing delay?";
            question[10] = "Question # 11- How many buses were there in all time?";
            question[11] = "Question # 12- How many minics (heal) could be worn before?";
            question[12] = "Question # 13- When did golf machines appear in the game?";
            question[13] = "Question # 14- How much damage did the bow do?";
            question[14] = "Question # 15- How many levels were there in season 2?";
            question[15] = "Question # 16- What was the prize pool at Summer Skirmich?";
            question[16] = "Question # 17- How much does a pump-shot shotgun inflict on a head in a web of distance?";
            question[17] = "Question # 18- How many hp have a wooden wall?";
            question[18] = "Question # 19- If you put on a 'bush' he will miss the damage?";
            question[19] = "Question # 20- What does 'Taco' do in the 'Salted Diner' location?";

            // Ответы на вопрос 0
            answer[0] = "Ivan Skokolov";
            answer[1] = "Maria Ermolina";
            answer[2] = "Alexander Kolos"; // <----- TRUE
            // Ответы на вопрос 1
            answer[3] = "Lord of the ice destroyed the 'Abandoned Towers'";
            answer[4] = "The lord of ice covered the entire map with snow"; // <----- TRUE
            answer[5] = "The lord of ice released the monster out of the ice";
            // Ответы на вопрос 2
            answer[6] = "Only golden";
            answer[7] = "Gray, blue, green";// <----- TRUE
            answer[8] = "Purple, gray gold";
            // Ответы на вопрос 3
            answer[9] = "Batman event";// <----- TRUE
            answer[10] = "John Wick Event";
            answer[11] = "Event Monster vs Robot";
            // Ответы на вопрос 4
            answer[12] = "He will be gone";
            answer[13] = "Nothing will happen";
            answer[14] = "He will issue items";// <----- TRUE
            // Ответы на вопрос 5
            answer[15] = "New York";// <----- TRUE
            answer[16] = "Frankfurt";
            answer[17] = "Moscow";
            // Ответы на вопрос 6
            answer[18] = "2";
            answer[19] = "8";// <----- TRUE
            answer[20] = "10";
            // Ответы на вопрос 7
            answer[21] = "In the New Towers";
            answer[22] = "In the new towers and point of sale";// <----- TRUE
            answer[23] = "He was not at all";
            // Ответы на вопрос 8
            answer[24] = "10 minutes";
            answer[25] = "30 minutes";
            answer[26] = "1 hour";// <----- TRUE
            // Ответы на вопрос 9
            answer[27] = "7.10";// <----- TRUE
            answer[28] = "5.40";
            answer[29] = "9.20";
            // Ответы на вопрос 10
            answer[30] = "0";
            answer[31] = "2";// <----- TRUE
            answer[32] = "1";
            // Ответы на вопрос 11
            answer[33] = "15";
            answer[34] = "2";
            answer[35] = "10";// <----- TRUE
            // Ответы на вопрос 12
            answer[36] = "In season 5";// <----- TRUE
            answer[37] = "In season 4";
            answer[38] = "In season 1";
            // Ответы на вопрос 13
            answer[39] = "115";// <----- TRUE
            answer[40] = "113";
            answer[41] = "30";
            // Ответы на вопрос 14
            answer[42] = "40";
            answer[43] = "70";// <----- TRUE
            answer[44] = "100";
            // Ответы на вопрос 15
            answer[45] = "10k$";
            answer[46] = "100k$";
            answer[47] = "8Mio$";// <----- TRUE
            // Ответы на вопрос 16
            answer[48] = "200";// <----- TRUE
            answer[49] = "250";
            answer[50] = "145";
            // Ответы на вопрос 17
            answer[51] = "100";
            answer[52] = "150";// <----- TRUE
            answer[53] = "200";
            // Ответы на вопрос 18
            answer[54] = "Yes";// <----- TRUE
            answer[55] = "I do not know";
            answer[56] = "No";
            // Ответы на вопрос 19
            answer[57] = "Accelerated race";// <----- TRUE
            answer[58] = "Can jump high";
            answer[59] = "You can not build";
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
            button1.enableAutoSizing = true; 
            button2.enableAutoSizing = true; 
            button3.enableAutoSizing = true; 

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
            button1.enableAutoSizing = false; 
            button2.enableAutoSizing = false; 
            button3.enableAutoSizing = false; 

            button1.fontSize = 46;
            button2.fontSize = 46;
            button3.fontSize = 46;

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
