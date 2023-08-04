using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadFinalScene : MonoBehaviour
{
    TMP_Text score, damage, godsQuiz, battlesQuiz, artefactQuiz, weaponsQuiz;
 
    void Start()
    {
        InitText();
    }

    void InitText()
    {
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "Total Score":
                    score = textComponent;
                    score.text = InitSentence(score.text, UIManager.Instance.GetScore());
                    break;

                case "Damage Taken":
                    damage = textComponent;
                    damage.text = InitSentence(damage.text,  PlayerManager.Instance.GetDamageTaken());
                    break;
                case "Artefact Score":
                    artefactQuiz = textComponent;
                    artefactQuiz.text = InitSentence(artefactQuiz.text, GameManager.Instance.ArtefactQuizScore);
                    break;
                case "Weapons Score":
                    weaponsQuiz = textComponent;
                    weaponsQuiz.text = InitSentence(weaponsQuiz.text, GameManager.Instance.WeaponsQuizScore);
                    break;
                case "Battle Score":
                    battlesQuiz = textComponent;
                    battlesQuiz.text = InitSentence(battlesQuiz.text, GameManager.Instance.BattleQuizScore);
                    break;
                case "Gods Score":
                    godsQuiz = textComponent;
                    godsQuiz.text = InitSentence(godsQuiz.text, GameManager.Instance.GodsQuizScore);
                    break;
            }

        }

    }

    string InitSentence(string scorefield, int points)
    {
       string Points = points.ToString();
       return scorefield + " " + Points;
    }

    string InitSentence(string scorefield, float points)
    {
        string Points = points.ToString();
        return scorefield + " " + Points + "%";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
