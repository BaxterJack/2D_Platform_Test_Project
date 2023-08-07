using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public Queue<string> sentences;

    TMP_Text npcName;
    TMP_Text dialogueText;

    Canvas dialogueCanvas;

    bool hasTabletPuzzle = false;

    NPC currentNPC;

    void Start()
    {
        sentences = new Queue<string>();
        DisableCanvas();
    }

    protected override void Awake()
    {
        base.Awake();
        dialogueCanvas = GetComponent<Canvas>();
        
        foreach (TMP_Text textComponent in GetComponentsInChildren<TMP_Text>())
        {
            switch (textComponent.name)
            {
                case "NPC Name":
                    npcName = textComponent;
                    break;
                case "Dialogue":
                    dialogueText = textComponent;
                    break;

            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        npcName.text = dialogue.name;
        sentences.Clear();
        hasTabletPuzzle = dialogue.HasTabletPuzzle;
        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }


    public void EnableCanvas()
    {
        dialogueCanvas.enabled = true;
        UIManager.Instance.HideUI();
    }

    public void DisableCanvas()
    {
        dialogueCanvas.enabled = false;
        UIManager.Instance.ShowUI();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            DisableCanvas();
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = senetence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        if (hasTabletPuzzle)
        {
            TabletManager.Instance.InitialiseTablet();
        }
        currentNPC.SetHasConversationCompleted(true) ;
        PlayerManager.Instance.InConversation = false;
    }

    public void AssignCurrentNPC(NPC npc)
    {
        currentNPC = npc;
    }
}
