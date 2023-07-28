using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class QuizFeedbackData
{
    public FeedbackQuizQuestion[] questions;
}


public class QuizFeedbackManager : QuizManager
{
    QuizFeedbackData quizData;
    protected override void CorrectAnswer()
    {
        RemoveButtonListeners();
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        score++;
        numAnswer = 1;
        question.text = "Correct! " + quizData.questions[currentQuestion].feedback;
    }

    protected override void IncorrectAnswer(int selectedButtonIndex)
    {
        RemoveButtonListeners();
        buttons[selectedButtonIndex].image.color = Color.red;
        int correctIndex = quizData.questions[currentQuestion].correctAnswer;
        buttons[correctIndex].image.color = Color.green;
        numAnswer = 1;
        question.text = "Incorrect! " + quizData.questions[currentQuestion].feedback;
    }

    protected override void LoadQuestionsFromJSON()
    {
        TextAsset jsonAsset = Resources.Load<TextAsset>(filePath);
        Debug.Log(jsonAsset.text);
        if (jsonAsset != null)
        {
            quizData = JsonUtility.FromJson<QuizFeedbackData>(jsonAsset.text);

        }
        else
        {
            Debug.LogError("Quiz data file not found!");
        }
    }

    //Why do the below functions have to be overriden, despite having no difference in code???

    protected override void InitialiseQuestion()
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

    protected override void InitialiseScore()
    {
        int numQs = quizData.questions.Length;
        scorefield.text = "Score: " + score + "/" + numQs;
    }

    protected override void NextQuestion()
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

    protected override void SetComplete()
    {
        GameManager manager = GameManager.Instance;
        switch (type)
        {
            case QuizType.BattleTactics:
                manager.BattleQuiz = true;
                manager.BattleQuizScore = ((float)score / quizData.questions.Length) * 100;
                break;
            case QuizType.Weaponary:
                manager.WeaponQuiz = true;
                manager.WeaponsQuizScore = ((float)score / quizData.questions.Length) * 100;
                break;
        }
    }
}
