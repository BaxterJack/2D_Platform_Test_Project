using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizQuestion 
{
    public string question;
    public string[] answers;
    public int correctAnswer;
}

[System.Serializable]
public class FeedbackQuizQuestion : QuizQuestion
{
    public string feedback;
}
