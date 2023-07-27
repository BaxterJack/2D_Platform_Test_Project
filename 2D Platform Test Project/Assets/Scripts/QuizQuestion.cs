using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuizQuestion 
{
    [SerializeField]
    public string question;
    [SerializeField]
    public string[] answers;
    [SerializeField]
    public int correctAnswer;
}
