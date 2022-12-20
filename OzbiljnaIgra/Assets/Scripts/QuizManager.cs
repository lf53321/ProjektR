using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI question;

    public TextMeshProUGUI answerButton1;
    public TextMeshProUGUI answerButton2;
    public TextMeshProUGUI answerButton3;
    public TextMeshProUGUI answerButton4;
    public TextMeshProUGUI scoreValue;

    public GameObject quizScreen;
    public GameObject scoreScreen;

    // list of questions
    string[] questions = {"What does EV mean?", "What does ICE mean?"};

    // key: questions order number, value: list of answers
    Dictionary<int, string[]> answers = new Dictionary<int, string[]>();

    // the index of the correct answer in the answer list (index is the questions order number)
    int[] correctAnswerIndex = {0, 1};

    // answers for the first question
    string[] answerList1 = {"Electric Vehicle", "Everithing", "Evolution", "Evalutaion"};

    // answers for the second question
    string[] answerList2 = {"Frozen Water", "Internal Combustion Engine", "Ice Age", "Internally Conducted Electricity"};

    // the order number of the current question (starts with 0)
    int questionNumber = 0;

    // players correct answers
    int correct = 0;

    // total number of questions in one quiz
    const int MAX_QUESTIONS = 2;

    // Start is called before the first frame update
    void Start()
    {
        answers[0] = answerList1;
        answers[1] = answerList2;

        // setup question
        question.text = questions[questionNumber];

        // setup buttons
        answerButton1.text = answerList1[0];
        answerButton2.text = answerList1[1];
        answerButton3.text = answerList1[2];
        answerButton4.text = answerList1[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnswer(Button button) {
        string usersAnswer = button.GetComponentInChildren<TextMeshProUGUI>().text;

        if(answers[questionNumber][correctAnswerIndex[questionNumber]] == usersAnswer) {
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

            // setup question
            question.text = questions[questionNumber];

            // setup buttons
            answerButton1.text = answerList2[0];
            answerButton2.text = answerList2[1];
            answerButton3.text = answerList2[2];
            answerButton4.text = answerList2[3];

        } else {

            quizScreen.SetActive(false);
            scoreScreen.SetActive(true);

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
}
