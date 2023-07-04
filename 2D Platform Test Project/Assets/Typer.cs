using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Typer /*: MonoBehaviour*/
{
    private char[] punctuationMarks = { '.', ',', ';', '!', '?' };
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private List<string> messageWords;

    //public TMP_Text wordOutput;
    string wordOutput = "";

    //public Typer()
    //{
    //    wordOutput = "";
    //}

    public void Update()
    {
        CheckInput();
    }

    public String WordOutput
    {
        get { return wordOutput; }
    }

    public void SplitTabletMessage(Tablet tablet)
    {
        string[] wordsArray = tablet.message.Split(new char[] { ' ' }.Concat(punctuationMarks).ToArray(), StringSplitOptions.RemoveEmptyEntries);
        messageWords = new List<string>(wordsArray);
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
        //wordOutput.text = remainingWord;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
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
            RemoveLetter();
            if (IsWordComplete())
            {
                RemoveWord();
                if (IsSenteceComplete())
                {
                    EndOutputText();
                    //Tablet has been translated
                }
                else
                {
                    AddSpaceToOutput();
                    SetCurrentWord();
                }   
            }
        }
        else
        {
            //Need to add a hint system
            Debug.Log(remainingWord);
        }
    }

    private bool IsCorrectLetter(char letter) // add in system to ignore capitals
    {
        return remainingWord.IndexOf(letter) == 0;
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
        wordOutput += typedLetter;
    }
    void AddSpaceToOutput()
    {
        wordOutput += " ";
    }

    void EndOutputText()
    {
        wordOutput += ".";
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
