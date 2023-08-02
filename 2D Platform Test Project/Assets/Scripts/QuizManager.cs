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
    private QuizData quizData;

    protected int score;
    protected Button[] buttons;
    protected Button nextQuestion;
    protected TMP_Text question, scorefield;
    protected int currentQuestion;
    protected int numAnswer = 0;
    protected string filePath = "ArtefactQuiz";
    protected QuizType type;
    public enum QuizType
    {
        Artefact,
        Weaponary,
        BattleTactics
    }
    public void Initialise(string FilePath, QuizType Type)
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

    protected void InitialseButtons()
    {
        foreach (Button b in GetComponentsInChildren<Button>())
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

    protected void ActivateNextQuestionButton(bool condition)
    {
        nextQuestion.gameObject.SetActive(condition);

    }

    protected void InitialiseText()
    {
        foreach (TMP_Text text in GetComponentsInChildren<TMP_Text>())
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

    protected virtual void InitialiseQuestion()
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

    protected void RemoveButtonListeners()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }

    protected virtual void CorrectAnswer()
    {
        RemoveButtonListeners();
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        score++;
        numAnswer = 1;
    }

    protected virtual void IncorrectAnswer(int selectedButtonIndex)
    {
        RemoveButtonListeners();
        buttons[selectedButtonIndex].image.color = Color.red;
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        numAnswer = 1;
    }

    protected virtual void NextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < quizData.questions.Length)
        {
            foreach (Button button in buttons)
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

    protected void Update()
    {
        InitialiseScore();
        if (numAnswer == 1)
        {
            ActivateNextQuestionButton(true);
        }
        else
        {
            ActivateNextQuestionButton(false);
        }
    }

    protected void EndQuiz()
    {
        nextQuestion.GetComponentInChildren<TMP_Text>().text = "End Quiz";
        nextQuestion.onClick.RemoveAllListeners();
        nextQuestion.onClick.AddListener(CloseCanvas);
        SetComplete();
    }



    protected virtual void SetComplete()
    {
        GameManager manager = GameManager.Instance;

        manager.ArtefactQuiz = true;
        float value = ((float)score / quizData.questions.Length) * 100;
        manager.ArtefactQuizScore = value;
        UIManager.Instance.AddToScore(score * 10);
    }

    protected void CloseCanvas()
    {
        GameManager.Instance.isQuizOpen = false;
        Destroy(gameObject);
    }

    protected virtual void InitialiseScore()
    {
        int numQs = quizData.questions.Length;
        scorefield.text = "Score: " + score + "/" + numQs;
    }

    protected virtual void LoadQuestionsFromJSON()
    {
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
