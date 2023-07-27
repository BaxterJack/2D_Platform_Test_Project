using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuizData
{
    public QuizQuestion[] questions;
}
public class QuizManager : MonoBehaviour
{
    public QuizData quizData;

    int score;
    public Button[] buttons;
    TMP_Text question, scorefield;
    int currentQuestion;
    int numAnswer = 0;
    void Start()
    {
        buttons = new Button[4];
        currentQuestion = 0;
        score = 0;
        LoadQuestionsFromJSON();
        InitialseButtons();
        InitialiseText();
        InitialiseQuestion();
    }

    void InitialseButtons()
    {
        foreach(Button b in GetComponentsInChildren<Button>())
        {
            switch (b.name)
            {
                case "ButtonA":
                    buttons[0] = b;
                    break;
                case "ButtonB":
                    buttons[1] = b;
                    break;
                case "ButtonC":
                    buttons[2] = b;
                    break;
                case "ButtonD":
                    buttons[3] = b;
                    break;
            }
        }
    }

    void InitialiseText()
    {
        foreach(TMP_Text text in GetComponentsInChildren<TMP_Text>())
        {
            switch (text.name)
            {
                case "Question":
                    question = text;
                    break;
                case "Score":
                    scorefield = text;
                    break;
            }
        }
    }

    void InitialiseQuestion()
    {
        question.text = quizData.questions[currentQuestion].question;
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].GetComponentInChildren<TMP_Text>().text = quizData.questions[currentQuestion].answers[i];
            if (quizData.questions[currentQuestion].correctAnswer == i)
            {
                buttons[i].onClick.AddListener(CorrectAnswer);
            }
            else
            {
                buttons[i].onClick.AddListener(() => IncorrectAnswer(buttonIndex));
            }
        }
    }

    void CorrectAnswer()
    {
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        score++;
        numAnswer = 1;
    }

    void IncorrectAnswer(int selectedButtonIndex)
    {
        buttons[selectedButtonIndex].image.color = Color.red;
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        numAnswer = 1;
    }

    void NextQuestion()
    {

        numAnswer = 0;
        currentQuestion++;
        if(currentQuestion <  quizData.questions.Length)
        {
            foreach(Button button in buttons)
            {
                button.image.color = Color.white;
            }
            InitialiseQuestion();
        }
       
    }

    private void Update()
    {
        InitialiseScore();
        if(numAnswer == 1)
        {
            NextQuestion();
        }
    }

    void InitialiseScore()
    {
        scorefield.text = "Score: " + score;
    }

    private void LoadQuestionsFromJSON()
    {
        string filePath = "ArtefactQuiz";
        TextAsset jsonAsset = Resources.Load<TextAsset>(filePath);

        if (jsonAsset != null)
        {
            quizData = JsonUtility.FromJson<QuizData>(jsonAsset.text);
        }
        else
        {
            Debug.LogError("Quiz data file not found!");
        }
    }

}
