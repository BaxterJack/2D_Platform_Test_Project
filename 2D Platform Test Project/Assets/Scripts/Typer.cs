using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Typer 
{
    private char[] punctuationMarks = { '.', ',', ';', '!', '?' };
    char[] ignoreChars = { '.', ',', ';', '!', '?', ' ' };
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private List<string> messageWords;

    string wordOutput = "";

    int errorsMade = 0;

    StringBuilder tabletMessage = new StringBuilder();
    public void Update()
    {
        CheckInput();
    }

    public String WordOutput
    {
        get { return wordOutput; }
    }

    private void ResetErrors()
    {
        errorsMade = 0;
    }

    public void SplitTabletMessage(Tablet tablet)
    {
        ResetErrors();
        tabletMessage.Clear();
        tabletMessage.Append(tablet.message);
        string[] wordsArray = tablet.message.Split(new char[] { ' ' }.Concat(punctuationMarks).ToArray(), StringSplitOptions.RemoveEmptyEntries);
        messageWords = new List<string>(wordsArray);
        wordOutput = "";
        SetCurrentWord();
    }

    void SetCurrentWord()
    {
        currentWord = messageWords[0];
        SetRemainingWord(messageWords[0]);
    }

    void SetRemainingWord(string word)
    {
        remainingWord = word;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if (keysPressed.Length == 1)
            {
                char letterPressed = keysPressed[0];
                EnterLetter(letterPressed);
            }
            else
            {
                Debug.Log("More than one letter pressed.");
            }
        }
    }

    private void EnterLetter(char typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            EnterLetterToOutput(typedLetter);
            TabletManager.Instance.SetDefaultHint();
            TabletManager.Instance.ChangeCompletedLetterColour();
            RemoveLetter();
            if (IsWordComplete())
            {

                RemoveWord();
                if (IsSenteceComplete())
                {
                    TabletManager.Instance.TabletTranslated();
                    CalculatePoints();
                    //Points
                }
                else
                {
                    SetCurrentWord();
                }   
            }
        }
        else
        {

            errorsMade++;
            ErrorNoise();
            Hint(typedLetter);

        }
    }

    char[] noCursiveLetters = { 'j', 'y', 'w', 'z', 'v' };

    struct LetterPairs
    {
        public LetterPairs(char EnglishLetter, char RomanLetter)
        {
           englishLetter = EnglishLetter;
           romanLetter = RomanLetter;
        }
        public char englishLetter;
        public char romanLetter;
    }

    LetterPairs[] letterPairs = { new LetterPairs('j', 'g'), new LetterPairs('y', 'i'), new LetterPairs('w', 'm'), new LetterPairs('z', 's'), new LetterPairs('v', 'u') };

    void Hint(char typedLetter)
    {
        char nextLetter = char.ToLower(remainingWord[0]);
        string hint = "";
        if (noCursiveLetters.Contains(nextLetter))
        {
            foreach(LetterPairs pair in letterPairs)
            {
                if(pair.englishLetter == nextLetter)
                {
                    hint = "Remember that " + char.ToUpper(pair.englishLetter) + " is also used for the Roman Character " + char.ToUpper(pair.romanLetter) + ".";
                }
            }
            TabletManager.Instance.SetHint(hint);
        }
    }

    void CalculatePoints()
    {
        int score = 200;
        score -= errorsMade;
        UIManager.Instance.AddToScore(score);
    }

    void ErrorNoise()
    {
        AudioManager.Instance.PlaySound("Error");
    }

    private bool IsCorrectLetter(char letter) 
    {
        return char.ToLower(letter) == char.ToLower(remainingWord[0]);
    }
    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }
    void RemoveWord()
    {
        messageWords.RemoveAt(0);
    }
    void EnterLetterToOutput(char typedLetter)
    {
        char firstChar = tabletMessage[0];
        tabletMessage.Remove(0, 1);
        wordOutput += firstChar;
        while (tabletMessage.Length > 0 && ignoreChars.Contains(tabletMessage[0]))
        {
            firstChar = tabletMessage[0];
            tabletMessage.Remove(0, 1);
            wordOutput += firstChar;
        }
        //wordOutput += typedLetter; // original
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }

    private bool IsSenteceComplete()
    {
        return messageWords.Count == 0;
    }
}
