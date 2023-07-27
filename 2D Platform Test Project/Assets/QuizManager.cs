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
    Button nextQuestion;
    TMP_Text question, scorefield;
    int currentQuestion;
    int numAnswer = 0;
    string filePath = "ArtefactQuiz";
    QuizType type;
    public enum QuizType
    {
        Artefact,
        Weaponary,
        BattleTactics
    }
    public void Initiliase(string FilePath, QuizType Type)
    {
        type = Type;
        buttons = new Button[4];
        currentQuestion = 0;
        score = 0;
        filePath = FilePath;
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
                case "NextQuestion":
                    nextQuestion = b;
                    ActivateNextQuestionButton(false);
                    nextQuestion.onClick.AddListener(NextQuestion);
                    break;
            }
        }
    }

    void ActivateNextQuestionButton(bool condition)
    {
        nextQuestion.gameObject.SetActive(condition);
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

    void RemoveButtonListeners()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }

    void CorrectAnswer()
    {
        RemoveButtonListeners();
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        score++;
        numAnswer = 1;
    }

    void IncorrectAnswer(int selectedButtonIndex)
    {
        RemoveButtonListeners();
        buttons[selectedButtonIndex].image.color = Color.red;
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        numAnswer = 1;
    }

    void NextQuestion()
    {

        
        currentQuestion++;
        if(currentQuestion <  quizData.questions.Length)
        {
            foreach(Button button in buttons)
            {
                button.image.color = Color.white;
            }
            InitialiseQuestion();
        }
        else
        {
            EndQuiz();
            return;
        }
        numAnswer = 0;
    }

    private void Update()
    {
        InitialiseScore();
        if(numAnswer == 1)
        {
            ActivateNextQuestionButton(true);
        }
        else
        {
            ActivateNextQuestionButton(false);
        }
    }

    void EndQuiz()
    {
        nextQuestion.GetComponentInChildren<TMP_Text>().text = "End Quiz";
        nextQuestion.onClick.RemoveAllListeners();
        nextQuestion.onClick.AddListener(CloseCanvas);
        SetComplete();
    }

    void SetComplete()
    {
        switch (type)
        {
            case QuizType.Artefact:
                GameManager.Instance.ArtefactQuiz = true;
                break;
            case QuizType.BattleTactics:
                GameManager.Instance.ArtefactQuiz = true;
                break;
            case QuizType.Weaponary:
                GameManager.Instance.ArtefactQuiz = true;
                break;
        }
    }

    void CloseCanvas()
    {
        Destroy(gameObject);
    }

    void InitialiseScore()
    {
        scorefield.text = "Score: " + score;
    }

    private void LoadQuestionsFromJSON()
    {
        Debug.Log(filePath);
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
