using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public Text question;

    public Text answerButton1;
    public Text answerButton2;
    public Text answerButton3;
    public Text answerButton4;
    public TextMeshProUGUI scoreValue;
    public Text title;

    public GameObject quizScreen;
    public GameObject scoreScreen;

    // list of questions
    string[] questionsEN = {"What does EV mean?",
                             "What does ICE mean?", 
                             "Which is the measuring unit of battery consumption?", 
                             "What happens to battery consumption when accelerating?",
                             "What happens to battery consumption in cold conditions?",
                             "Is it possible to drive an electric car in rain or snow?",
                             "Is it possible to charge an electric car in rain or snow?",
                             "What is the biggest challenge in EV?", //Charging the batteries
                             "What problem do EVs solve?", //eliminating exhaust emissions
                             "What problem do EVs solve?", // they are very quiet
                             "What is the biggest anxiety of EV drivers?" // the range anxiety
                        };

    // the index of the correct answer in the answer list (index is the questions order number)
    int[] correctAnswerIndex = {0, 1, 0, 2, 3, 1, 2, 3, 1, 0, 2};

    string[][] answerListsEN = new string[][]
    {
        new string[] {"Electric Vehicle", "Everithing", "Evolution", "Evalutaion"},
        new string[] {"Frozen Water", "Internal Combustion Engine", "Ice Age", "Internally Conducted Electricity"},
        new string[] {"kWh", "mAh", "W", "V"},
        new string[] {"It depends on many factors", "It remains the same", "It increases", "It decreases"},
        new string[] {"It decreases", "It remains the same", "It depends on many factors", "It increases"},
        new string[] {"No", "Yes", "It depends on various factors", "Don't know"},
        new string[] {"It depends on various factors", "No", "Yes", "Don't know"},
        new string[] {"Handling powerful engines", "Not producing emissions", "Low-maintenance", "Charging the batteries"},
        new string[] {"They are cheaper to buy", "Eliminating exhaust emissions", "None", "Don't know"},
        new string[] {"They are very quiet", "They are not so heavy", "They are easier to drive", "Don't know"},
        new string[] {"Fear of battery failing", "Fear of battery explosion", "The range anxiety", "Don't know"}
    };

    string[] questionsHR = {"Što predstavlja EV?",
                             "Što predstavlja ICE?", 
                             "Koja je mjerna jedinica potrošnje baterije?", 
                             "Što se događa sa potrošnjom baterije prilikom ubrzavanja?",
                             "Što se događa sa potrošnjom baterije u hladnim uvjetima?",
                             "Je li moguće voziti električni automobil po kiši ili snijegu?",
                             "Je li moguće puniti električni automobil po kiši ili snijegu?",
                             "Koja je najveća prepreka kod EV?", //Charging the batteries
                             "Koji problem EV rješava?", //eliminating exhaust emissions
                             "Koji problem EV rješava?", // they are very quiet
                             "Koji je najveći strah kod vozača EV?" // the range anxiety
                        };
    string[][] answerListsHR = new string[][]
    {
        new string[] {"Električno Vozilo", "Evolviranje", "Evolucija", "Evaluacija"},
        new string[] {"Frozen Water", "Internal Combustion Engine", "Ice Age", "Internally Conducted Electricity"},
        new string[] {"kWh", "mAh", "W", "V"},
        new string[] {"Ovisi o više faktora", "Ostaje ista", "Povećava se", "Smanjuje se"},
        new string[] {"Smanjuje se", "Ostaje ista", "Ovisi o više faktora", "Povećava se"},
        new string[] {"Ne", "Da", "Ovisi o raznim parametrima", "Ne znam"},
        new string[] {"Ovisi o raznim parametrima", "Ne", "Da", "Ne znam"},
        new string[] {"Upravljanje snažnim motorima", "Ne ispuštaju plinove", "Rijetka potreba za održavanjem", "Punjenje baterija"},
        new string[] {"Jeftiniji su", "Ne ispuštaju plinove", "Ništa", "Ne znam"},
        new string[] {"Jako su tihi", "Imaju manju masu", "Lakše ih je voziti", "Ne znam"},
        new string[] {"Strah od kvara baterije", "Strah od eksplozije baterije", "Zabrinutost zbog dometa", "Ne znam"}
    };

    string[][] answerLists;
    string[] questions;

    // the order number of the current question (starts with 0)
    int questionNumber = 0;

    // players correct answers
    int correct = 0;

    // total number of questions in one quiz
    const int MAX_QUESTIONS = 5;

    int[] indices;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("Language") != "HR") {
            questions = questionsEN;
            answerLists = answerListsEN;
        } else {
            questions = questionsHR;
            answerLists = answerListsHR;
        }

        indices = getUniqueRandomArray(0, answerLists.Length, MAX_QUESTIONS);

        int currentIndex = indices[questionNumber];

        // setup question
        question.text = questions[currentIndex];

        // setup buttons
        answerButton1.text = answerLists[currentIndex][0];
        answerButton2.text = answerLists[currentIndex][1];
        answerButton3.text = answerLists[currentIndex][2];
        answerButton4.text = answerLists[currentIndex][3];
    }

    public void CheckAnswer(Button button) {
        string usersAnswer = button.GetComponentInChildren<Text>().text;

        int currentIndex = indices[questionNumber];

        if(answerLists[currentIndex][correctAnswerIndex[currentIndex]] == usersAnswer) {
            // the answer is correct
            correct++;
            Debug.Log("Correct!");
        } else {
            // the answer is wrong
            Debug.Log("Incorrect!");
        }

        // go to next question
        questionNumber++;
        NextQuestion();

    }

    void NextQuestion() {

        if(questionNumber < MAX_QUESTIONS) {

            int currentIndex = indices[questionNumber];

            // setup question
            question.text = questions[currentIndex];

            // setup buttons
            answerButton1.text = answerLists[currentIndex][0];
            answerButton2.text = answerLists[currentIndex][1];
            answerButton3.text = answerLists[currentIndex][2];
            answerButton4.text = answerLists[currentIndex][3];

        } else {

            quizScreen.SetActive(false);
            scoreScreen.SetActive(true);

            if(correct == MAX_QUESTIONS) {
                // Text title = scoreScreen.transform.Find("GameOverTitle").gameObject.GetComponent<Text>();
                if(PlayerPrefs.GetString("Language") != "HR")
                    title.text = "You won!";
                else
                    title.text = "Pobijedili ste!";

                GameObject trophyLeft = scoreScreen.transform.Find("TrophyLeft").gameObject;
                GameObject trophyRight = scoreScreen.transform.Find("TrophyRight").gameObject;

                trophyLeft.SetActive(true);
                trophyRight.SetActive(true);
            } else {
                if(PlayerPrefs.GetString("Language") != "HR")
                    title.text = "You lost!";
                else
                    title.text = "Izgubili ste!";
            }

            string ss = correct + "/" + MAX_QUESTIONS;
            Debug.Log("Score: " + ss);
            Debug.Log("End of quiz!");
            scoreValue.text = ss;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // The method opens the main menu rather than quitting the application.
    public void quit()
    {
        string menu = "Menu";
        SceneManager.LoadScene(menu);
    }

    public static int[] getUniqueRandomArray(int min, int max, int count) {
    int[] result = new int[count];
    List<int> numbersInOrder = new List<int>();
    for (var x = min; x < max; x++) {
        numbersInOrder.Add(x);
    }
    for (var x = 0; x < count; x++) {
        var randomIndex = UnityEngine.Random.Range(0, numbersInOrder.Count);
        result[x] = numbersInOrder[randomIndex];
        numbersInOrder.RemoveAt(randomIndex);
    }

    return result;
}
}
