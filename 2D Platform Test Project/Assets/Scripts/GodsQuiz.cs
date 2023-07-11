using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class GodsQuiz : MonoBehaviour
{
    public List<GodAnswer> answers;
    public List<God> incorrectAnswers;

    private Button god1;
    private Button god2;
    private Button god3;
    private Button continueButton;
    private Image background1;
    private Image background2;
    private Image background3;

    TMP_Text description;
    TMP_Text hint;
    TMP_Text feedback;

    List<Button> godButtons;

    int numQuestions;
    int currentQuestion = 0;
    int score = 0;

    int correctButton;
    private void Awake()
    {
        numQuestions = answers.Count;
        InitialiseBackgrounds();
        InitialiseButtons();    
        InitialiseText();
    }

    private void Update()
    {
        PopulateCanvas();

    }
    void InitialiseButtons()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            switch (button.name)
            {
                case "Button1":
                    god1 = button;
                    break;
                case "Button2":
                    god2 = button;
                    break;
                case "Button3":
                    god3 = button;
                    break;
                case "ContinueButton":
                    continueButton = button;
                    break;
            }
        }
        godButtons = new List<Button>();
        godButtons.Add(god1);
        godButtons.Add(god2);
        godButtons.Add(god3);


    }

    void InitialiseBackgrounds()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            switch (image.name)
            {
                case "Background1":
                    background1 = image;
                    break;
                case "Background2":
                    background2 = image;
                    break;
                case "Background3":
                    background3 = image;
                    break;
            }
        }
    }

    void InitialiseText()
    {
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Description":
                    description = textComponent;
                    break;
                case "Hint":
                    hint = textComponent;
                    break;
                case "Feedback":
                    feedback = textComponent;
                    break;
            }
        }
    }

    void CreateCorrectButton()
    {
        // RandomNumber function??
        correctButton = 1;
        

    }

    void PopulateCanvas()
    {
        // RandomNumber function??
        for (int i =0; i < 3; i++)
        {
            if(i == correctButton)
            {
                godButtons[i].GetComponent<Image>().sprite = answers[currentQuestion].Image;
                string descrip = answers[currentQuestion].Name;
                descrip += ": ";
                descrip += answers[currentQuestion].Description;
                description.text = descrip;
                hint.text = answers[currentQuestion].Hint;
            }
            else
            {
                godButtons[i].GetComponent<Image>().sprite = incorrectAnswers[i].Image;
            }
        }

    }

    // Each question is has a correct asnswer answers[index]
    // Random button populated with correct answer details
    // Other two buttons assisned incorrect answers
    // If incorrect answer, that buttons background turns red and Feedback pops up, explaing details about that god
    // If correct answer given, that buttons background turns green and Well done message populates feedback
    // Score is assigned, 2 points for no wrong answers, 1 point for 1 wrong answer, 0 for 2 wrong answers
    // Go to next question
}
