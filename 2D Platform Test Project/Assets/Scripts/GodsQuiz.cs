using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class GodsQuiz : MonoBehaviour
{
    public List<GodAnswer> answers;
    public List<God> incorrectAnswers;

    private Button continueButton;

    TMP_Text description;
    TMP_Text hint;
    TMP_Text feedback;

    int numQuestions;
    int currentQuestion = 0;
    int score = 0;

    int correctButton;
    int wrongGuesses = 0;

    public Choices[] choices = new Choices[3];

    private System.Random random;
    private void Awake()
    {
        numQuestions = answers.Count;

        random = new System.Random();
        choices = new Choices[3];
        choices[0] = new Choices();
        choices[1] = new Choices();
        choices[2] = new Choices();

        InitialiseBackgrounds();
        InitialiseButtons();
        InitialiseText();
        PopulateCanvas();

    }
    private void Update()
    {
        
    }

    void PopulateCanvas()
    {
        wrongGuesses = 0;
        CreateCorrectButton();
        FindWrongAnswers();
        ShowContinueButton(false);
        for (int i =0; i < 3; i++)
        {
            choices[i].Background.color = Color.black;
            choices[i].Button.onClick.RemoveAllListeners();
            if (i == correctButton)
            {
                choices[i].Button.GetComponent<Image>().sprite = answers[currentQuestion].Image;
                string descrip = answers[currentQuestion].Name;
                descrip += ": ";
                descrip += answers[currentQuestion].Description;
                description.text = descrip;
                hint.text = "Hint: ";
                hint.text += answers[currentQuestion].Hint;
                HideHint();
                choices[i].Button.onClick.AddListener(CorrectAnswer);
            }
            else
            {
                int index = choices[i].Index;
                choices[i].Button.GetComponent<Image>().sprite = incorrectAnswers[index].Image;
                choices[i].Button.onClick.AddListener(IncorrectAnswer);
            }
        }
    }

    void PopulateFeedback(int index, bool isCorrect)
    {
        StringBuilder stringBuilder = new StringBuilder();
        if (isCorrect)
        {
            stringBuilder.Append("Well Done! That is correct");
            feedback.text = stringBuilder.ToString();

        }
        else
        {
            stringBuilder.Append("That is incorrect. This is ");
            stringBuilder.Append(incorrectAnswers[index].Name);
            stringBuilder.Append(": ");
            stringBuilder.Append(incorrectAnswers[index].Description);
            feedback.text = stringBuilder.ToString();
        }
    }

    void CorrectAnswer()
    {
        int index = ClickedButtonIndex();
        choices[index].Background.color = Color.green;
        PopulateFeedback(index, true);
        AssignPoints();
        ShowContinueButton(true);
    }

    void ShowContinueButton(bool condition)
    {
        continueButton.gameObject.SetActive(condition);
        
    }
    public void NextQuestion()
    {
        currentQuestion++;
        if(currentQuestion < numQuestions)
        {
            PopulateCanvas();
        }
        else
        {
            //EndQuiz();
        }

    }


    void ShowHint()
    {
        hint.enabled = true;
    }

    void HideHint()
    {
        hint.enabled = false;
    }
    void CreateCorrectButton()
    {
        correctButton = random.Next(0, 3);
    }

    void FindWrongAnswers()
    {
        int wrong1 = random.Next(0, 6);
        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            if (i == correctButton)
            {
                choices[i].Index = currentQuestion;
                choices[i].IsCorrectAnswer = true;
            }
            else
            {
                choices[i].Index = wrong1;
                choices[i].IsCorrectAnswer = false;
                if (count == 0)
                {
                    int wrong2 = random.Next(0, 7);
                    while (wrong1 == wrong2)
                    {
                        wrong2 = random.Next(0, 7);
                    }
                    wrong1 = wrong2;
                }
                count++;
            }
        }
    }
    void AssignPoints()
    {
        if(wrongGuesses == 0)
        {
            score += 2;
        }
        else if (wrongGuesses == 1)
        {
            score += 1;
        }

    }
    void IncorrectAnswer()
    {
        int index = ClickedButtonIndex();
        choices[index].Background.color = Color.red;
        wrongGuesses++;
        PopulateFeedback(index, false);
        ShowHint();
    }


    int ClickedButtonIndex()
    {
        int index = 0;
        Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        if (clickedButton != null)
        {
            if (clickedButton == choices[0].Button)
            {
                index = 0;
            }
            else if (clickedButton == choices[1].Button)
            {
                index = 1;
            }
            else if (clickedButton == choices[2].Button)
            {
                index = 2;
            }
        }
        else
        {
            Debug.Log("Clicked Button is Null");
        }
        return index;
    }

    void InitialiseButtons()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            switch (button.name)
            {
                case "Button1":
                    choices[0].Button = button;
                    break;
                case "Button2":
                    choices[1].Button = button;
                    break;
                case "Button3":
                    choices[2].Button = button;
                    break;
                case "ContinueButton":
                    continueButton = button;
                    break;
            }
        }
    }

    void InitialiseBackgrounds()
    {
        foreach (Image image in GetComponentsInChildren<Image>())
        {
            switch (image.name)
            {
                case "Background1":
                    choices[0].Background = image;
                    break;
                case "Background2":
                    choices[1].Background = image;
                    break;
                case "Background3":
                    choices[2].Background = image;
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
}
